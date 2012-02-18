﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtoChannel.HttpProxy.Service.PingPong
{
    [ProtoCallbackContract(typeof(ServerCallbackService))]
    public class ServerService
    {
        [ProtoMethod]
        public Pong Ping(Ping message)
        {
            return new Pong { Payload = message.Payload };
        }

        [ProtoMethod(IsOneWay = true)]
        public void OneWayPing(OneWayPing message)
        {
            Console.WriteLine("One way ping received");

            OperationContext.Current.GetCallbackChannel<ServerCallbackService>().OneWayPing(new OneWayPing
            {
                Payload = message.Payload
            });
        }
    }
}