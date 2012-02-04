﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using NUnit.Framework;

namespace ProtoChannel.Test.ChannelSetup
{
    [TestFixture]
    internal class ProtocolNumberExchange
    {
        [Test]
        public void DefaultProtocolNumber()
        {
            var hostConfig = new ProtoHostConfiguration
            {
                MinimumProtocolNumber = 2,
                MaximumProtocolNumber = 3
            };

            int chosenProtocol = 0;

            using (var host = new ProtoHost(new IPEndPoint(IPAddress.Loopback, 0), hostConfig, p => chosenProtocol = p))
            using (new ClientService(host.LocalEndPoint, null))
            {
            }

            Assert.AreEqual(hostConfig.MaximumProtocolNumber, chosenProtocol);
        }

        [Test]
        [ExpectedException]
        public void InvalidChosenProtocol()
        {
            var clientConfig = new ClientConfiguration
            {
                ProtocolChooser = (min, max) => 1
            };

            using (var host = new ProtoHost(new IPEndPoint(IPAddress.Loopback, 0), null, null))
            using (new ClientService(host.LocalEndPoint, clientConfig))
            {
            }
        }

        private class ClientConfiguration : ProtoClientConfiguration
        {
            public Func<int, int, int> ProtocolChooser { get; set; }
        }

        private class ClientService : Services.PingPong.ClientService
        {
            public ClientService(IPEndPoint remoteEndPoint, ClientConfiguration configuration)
                : base(remoteEndPoint, configuration)
            {
            }

            private new ClientConfiguration Configuration
            {
                get { return base.Configuration as ClientConfiguration; }
            }

            protected override int ChooseProtocol(int minProtocol, int maxProtocol)
            {
                if (Configuration == null || Configuration.ProtocolChooser == null)
                    return base.ChooseProtocol(minProtocol, maxProtocol);
                else
                    return Configuration.ProtocolChooser(minProtocol, maxProtocol);
            }
        }

        private class ProtoHost : ProtoChannel.ProtoHost<Services.PingPong.ServerService>
        {
            private readonly Action<int> _chosenProtocol;

            public ProtoHost(IPEndPoint localEndPoint, ProtoHostConfiguration configuration, Action<int> chosenProtocol)
                : base(localEndPoint, configuration)
            {
                _chosenProtocol = chosenProtocol;
            }

            protected override Services.PingPong.ServerService CreateService(int protocolNumber)
            {
                if (_chosenProtocol != null)
                    _chosenProtocol(protocolNumber);

                return base.CreateService(protocolNumber);
            }
        }
    }
}