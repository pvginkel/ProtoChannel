﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProtoChannel.Demo.ProtoService
{
    [global::System.CodeDom.Compiler.GeneratedCode("ProtoChannel.CodeGenerator", "1.0.0.0")]
    internal partial class ClientService : global::ProtoChannel.ProtoClient
    {
        [global::System.Diagnostics.DebuggerStepThrough]
        public ClientService(global::System.Net.IPEndPoint remoteEndPoint)
            : base(remoteEndPoint)
        {
        }

        [global::System.Diagnostics.DebuggerStepThrough]
        public ClientService(global::System.Net.IPEndPoint remoteEndPoint, global::ProtoChannel.ProtoClientConfiguration configuration)
            : base(remoteEndPoint, configuration)
        {
        }

        [global::System.Diagnostics.DebuggerStepThrough]
        public ClientService(global::System.Net.IPAddress address, int port)
            : base(address, port)
        {
        }

        [global::System.Diagnostics.DebuggerStepThrough]
        public ClientService(global::System.Net.IPAddress address, int port, global::ProtoChannel.ProtoClientConfiguration configuration)
            : base(address, port, configuration)
        {
        }

        [global::System.Diagnostics.DebuggerStepThrough]
        public ClientService(string hostname, int port)
            : base(hostname, port)
        {
        }

        [global::System.Diagnostics.DebuggerStepThrough]
        public ClientService(string hostname, int port, global::ProtoChannel.ProtoClientConfiguration configuration)
            : base(hostname, port, configuration)
        {
        }

        [global::System.Diagnostics.DebuggerStepThrough]
        public global::ProtoChannel.Demo.Shared.SimpleMessage SimpleMessage(global::ProtoChannel.Demo.Shared.SimpleMessage message)
        {
            return EndSimpleMessage(BeginSimpleMessage(message, null, null));
        }

        [global::System.Diagnostics.DebuggerStepThrough]
        public global::System.IAsyncResult BeginSimpleMessage(global::ProtoChannel.Demo.Shared.SimpleMessage message, global::System.AsyncCallback callback, object asyncState)
        {
            return BeginSendMessage(message, typeof(global::ProtoChannel.Demo.Shared.SimpleMessage), callback, asyncState);
        }

        [global::System.Diagnostics.DebuggerStepThrough]
        public global::ProtoChannel.Demo.Shared.SimpleMessage EndSimpleMessage(global::System.IAsyncResult asyncResult)
        {
            return (global::ProtoChannel.Demo.Shared.SimpleMessage)EndSendMessage(asyncResult);
        }

        [global::System.Diagnostics.DebuggerStepThrough]
        public global::ProtoChannel.Demo.Shared.ComplexMessage ComplexMessage(global::ProtoChannel.Demo.Shared.ComplexMessage message)
        {
            return EndComplexMessage(BeginComplexMessage(message, null, null));
        }

        [global::System.Diagnostics.DebuggerStepThrough]
        public global::System.IAsyncResult BeginComplexMessage(global::ProtoChannel.Demo.Shared.ComplexMessage message, global::System.AsyncCallback callback, object asyncState)
        {
            return BeginSendMessage(message, typeof(global::ProtoChannel.Demo.Shared.ComplexMessage), callback, asyncState);
        }

        [global::System.Diagnostics.DebuggerStepThrough]
        public global::ProtoChannel.Demo.Shared.ComplexMessage EndComplexMessage(global::System.IAsyncResult asyncResult)
        {
            return (global::ProtoChannel.Demo.Shared.ComplexMessage)EndSendMessage(asyncResult);
        }
    }
}
