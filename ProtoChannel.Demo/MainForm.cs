﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;

namespace ProtoChannel.Demo
{
    public partial class MainForm : Form
    {
        private readonly ProtoHost<ProtoService.ServerService> _protoServer;
        private ServiceHost _wcfServer;

        public MainForm()
        {
            InitializeComponent();

            _protoServer = new ProtoHost<ProtoService.ServerService>(new IPEndPoint(IPAddress.Any, Constants.ProtoChannelPort));

            _protoChannelPort.Text = Constants.ProtoChannelPort.ToString();

            var waitEvent = new ManualResetEvent(false);

            ThreadPool.QueueUserWorkItem(p =>
            {
                _wcfServer = new ServiceHost(typeof(Wcf.ServerService));

                _wcfServer.Open();

                waitEvent.Set();
            });

            waitEvent.WaitOne();

            _wcfPort.Text = Constants.WcfPort.ToString();
        }

        private void _acceptButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                ClientMessageType messageType;

                if (_messageSimple.Checked)
                    messageType = ClientMessageType.Simple;
                else if (_messageComplex.Checked)
                    messageType = ClientMessageType.Complex;
                else if (_messageSmallStream.Checked)
                    messageType = ClientMessageType.SmallStream;
                else
                    messageType = ClientMessageType.LargeStream;

                var settings = new TestClientSettings(
                    _host.Text,
                    int.Parse(_concurrentClients.Text),
                    int.Parse(_totalClients.Text),
                    int.Parse(_requestPerClient.Text),
                    messageType
                    );

                using (var form = new TestForm(settings, _modeProtoChannel.Checked ? TestMode.ProtoChannel : TestMode.Wcf))
                {
                    form.ShowDialog(this);
                }
            }
        }

        private void _concurrentClients_Validating(object sender, CancelEventArgs e)
        {
            int result;
            string error = null;

            if (!int.TryParse(_concurrentClients.Text, out result) || result < 0)
                error = "Concurrent clients must be an integer greater than zero";

            _errorProvider.SetError(_concurrentClients, error);
        }

        private void _totalClients_Validating(object sender, CancelEventArgs e)
        {
            int result;
            string error = null;

            if (!int.TryParse(_totalClients.Text, out result) || result < 0)
                error = "Total clients must be an integer greater than zero";

            _errorProvider.SetError(_totalClients, error);
        }

        private void _requestPerClient_Validating(object sender, CancelEventArgs e)
        {
            int result;
            string error = null;

            if (!int.TryParse(_requestPerClient.Text, out result) || result < 0)
                error = "Requests per client must be an integer greater than zero";

            _errorProvider.SetError(_requestPerClient, error);
        }

        public void AddSendMessage(long ticks)
        {
            throw new NotImplementedException();
        }
    }
}
