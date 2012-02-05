﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ProtoBuf.Meta;
using ProtoChannel.Util;

namespace ProtoChannel
{
    internal abstract class TcpConnection : IDisposable
    {
        private readonly object _syncRoot = new object();
        private bool _sending;
        private SslStream _sslStream;
        private readonly RingMemoryStream _receiveStream;
        private readonly RingMemoryStream _sendStream;
        private Stream _stream;
        private TcpClient _tcpClient;

        public bool IsDisposed { get; private set; }

        protected bool IsAsync { get; set; }

        protected long DataAvailable
        {
            get { return _receiveStream.Length - _receiveStream.Position; }
        }

        protected long WritePosition
        {
            get { return _sendStream.Position; }
            set { _sendStream.Position = value; }
        }

        protected TcpConnection(TcpClient tcpClient)
        {
            if (tcpClient == null)
                throw new ArgumentNullException("tcpClient");

            _sendStream = new RingMemoryStream(Constants.RingBufferBlockSize);
            _receiveStream = new RingMemoryStream(Constants.RingBufferBlockSize);

            _tcpClient = tcpClient;

            _tcpClient.Client.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);

            _stream = _tcpClient.GetStream();
        }

        protected void AuthenticateAsClient(RemoteCertificateValidationCallback validationCallback, string targetHost)
        {
            _sslStream = new SslStream(_stream, false, validationCallback ?? DummyValidationCallback);

            _sslStream.AuthenticateAsClient(
                targetHost,
                null,
                SslProtocols.Tls,
                false /* checkCertificateRevocation */
            );

            _stream = _sslStream;
        }

        protected void BeginAuthenticateAsServer(X509Certificate certificate, RemoteCertificateValidationCallback validationCallback, AsyncCallback callback, object asyncState)
        {
            _sslStream = new SslStream(_stream, false, validationCallback ?? DummyValidationCallback);

            _stream = null;

            _sslStream.BeginAuthenticateAsServer(
                certificate,
                false /* clientCertificateRequired */,
                SslProtocols.Tls,
                false /* checkCertificateRevocation */,
                callback,
                asyncState
            );
        }

        protected void EndAuthenticateAsServer(IAsyncResult asyncResult)
        {
            _sslStream.EndAuthenticateAsServer(asyncResult);

            _stream = _sslStream;
        }

        private bool DummyValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        protected int Read(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
                throw new ArgumentNullException("buffer");

            return _receiveStream.Read(buffer, offset, count);
        }

        protected object ReadMessage(RuntimeTypeModel typeModel, Type messageType, int length)
        {
            if (typeModel == null)
                throw new ArgumentNullException("typeModel");
            if (messageType == null)
                throw new ArgumentNullException("messageType");

            return typeModel.Deserialize(_receiveStream, null, messageType, length);
        }

        protected void ReadStream(Stream stream, int length)
        {
            // We read directly from the back buffers.

            while (length > 0)
            {
                // Get a page where we can read from.

                long pageSize = Math.Min(
                    _receiveStream.BlockSize - _receiveStream.Position % _receiveStream.BlockSize, // Maximum size to stay on the page
                    length
                );

                var page = _receiveStream.GetPage(_receiveStream.Position, pageSize);

                // Write the page to our stream.

                stream.Write(page.Buffer, page.Offset, page.Count);

                // Move the buffers position.

                _receiveStream.Position += page.Count;

                length -= page.Count;
            }
        }

        protected void Write(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
                throw new ArgumentNullException("buffer");

            _sendStream.Write(buffer, offset, count);
        }

        protected void WriteMessage(RuntimeTypeModel typeModel, object message)
        {
            if (typeModel == null)
                throw new ArgumentNullException("typeModel");
            if (message == null)
                throw new ArgumentNullException("message");

            typeModel.Serialize(_sendStream, message);
        }

        protected void WriteStream(Stream stream, long length)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            while (length > 0)
            {
                Debug.Assert(_sendStream.Length == _sendStream.Position);

                // We write directly into the back buffers of the send buffer.

                long pageSize = Math.Min(
                    _sendStream.BlockSize - _sendStream.Position % _sendStream.BlockSize, // Maximum size to stay on the page
                    length
                );

                // Make room for the page.

                _sendStream.SetLength(_sendStream.Length + pageSize);

                // Get the page we're using to write the stream data on.

                var page = _sendStream.GetPage(_sendStream.Position, pageSize);

                int read = stream.Read(page.Buffer, page.Offset, page.Count);

                Debug.Assert(read == page.Count);

                // Move the position forward to correspond with the data
                // we've just written.

                _sendStream.Position += pageSize;

                length -= page.Count;
            }
        }

        protected void Read()
        {
            if (IsAsync)
                ReadAsync();
            else
                ReadSync();
        }

        private void ReadSync()
        {
            lock (_syncRoot)
            {
                VerifyNotDisposed();

                var page = _receiveStream.GetWriteBuffer();

                ProcessReceivedData(
                    _stream.Read(page.Buffer, page.Offset, page.Count)
                );
            }
        }

        private void ReadAsync()
        {
            if (!IsDisposed)
            {
                var page = _receiveStream.GetWriteBuffer();

                _stream.BeginRead(page.Buffer, page.Offset, page.Count, ReadCallback, null);
            }
        }

        private void ReadCallback(IAsyncResult asyncResult)
        {
            lock (_syncRoot)
            {
                if (IsDisposed)
                    return;

                // Add the read bytes to the input buffer.

                try
                {
                    ProcessReceivedData(_stream.EndRead(asyncResult));

                    ReadAsync();
                }
                catch
                {
                    Dispose();
                }
            }
        }

        private void ProcessReceivedData(int read)
        {
            // Zero input means that the remote socket closed the connection.

            if (read == 0)
            {
                Dispose();
                return;
            }

            _receiveStream.SetLength(_receiveStream.Length + read);

            // Process all messages currently in the input buffer.

            _receiveStream.Position = _receiveStream.Head;

            while (!IsDisposed)
            {
                if (!ProcessInput())
                    break;
            }

            if (IsDisposed)
                return;

            // Set the position to the end so new data is appended to the end
            // of the buffer, and update the head to free unused pages.

            _receiveStream.Head = _receiveStream.Position;
            _receiveStream.Position = _receiveStream.Length;
        }

        protected abstract bool ProcessInput();

        protected void Send()
        {
            lock (_syncRoot)
            {
                if (IsAsync)
                    SendAsync();
                else
                    SendSync();
            }
        }

        private void SendSync()
        {
            // SendSync is only used in the connection phase of client connections.
            // We do not support sending streams here.

            RingMemoryPage page;

            while (TryGetSendPage(out page))
            {
                _stream.Write(page.Buffer, page.Offset, page.Count);

                _sendStream.Head += page.Count;
            }
        }

        private void SendAsync()
        {
            ProcessSendRequests();
        }

        private void ProcessSendRequests()
        {
            if (_stream == null)
                return;

            if (!_sending)
            {
                if (_sendStream.Head == _sendStream.Length)
                    BeforeSend();

                if (_sendStream.Head != _sendStream.Length)
                {
                    _sending = true;

                    var page = GetSendPage();

                    _stream.BeginWrite(
                        page.Buffer, page.Offset, page.Count, WriteCallback, page
                    );
                }
            }
        }

        protected virtual void BeforeSend()
        {
        }

        private RingMemoryPage GetSendPage()
        {
            RingMemoryPage result;

            if (!TryGetSendPage(out result))
                throw new InvalidOperationException("No data to send");

            return result;
        }

        private bool TryGetSendPage(out RingMemoryPage page)
        {
            long pageSize = Math.Min(
                _sendStream.BlockSize - _sendStream.Head % _sendStream.BlockSize, // Maximum size to stay on the page
                _sendStream.Length - _sendStream.Head // Maximum size to send at all
            );

            if (pageSize == 0)
            {
                page = new RingMemoryPage();

                return false;
            }
            else
            {
                page = _sendStream.GetPage(_sendStream.Head, pageSize);

                Debug.Assert(_sendStream.Head + pageSize <= _sendStream.Length);

                return true;
            }
        }

        private void WriteCallback(IAsyncResult asyncResult)
        {
            lock (_syncRoot)
            {
                if (IsDisposed)
                    return;

                _sending = false;

                if (_stream != null)
                {
                    try
                    {
                        _stream.EndWrite(asyncResult);

                        _sendStream.Head += ((RingMemoryPage)asyncResult.AsyncState).Count;

                        ProcessSendRequests();
                    }
                    catch
                    {
                        Dispose();
                    }
                }
            }
        }

        private void VerifyNotDisposed()
        {
            if (IsDisposed)
                throw new ObjectDisposedException(GetType().Name);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (_tcpClient != null)
                {
                    _tcpClient.Close();
                    _tcpClient = null;
                }

                if (_sslStream != null)
                {
                    _sslStream.Dispose();
                    _sslStream = null;

                    // When we have an SslStream, _stream is set to the same
                    // stream.

                    _stream = null;
                }

                if (_stream != null)
                {
                    _stream.Dispose();
                    _stream = null;
                }

                IsDisposed = true;
            }
        }
    }
}