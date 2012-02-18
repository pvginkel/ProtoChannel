﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace ProtoChannel.HttpProxy.Service.PingPong
{
    [ProtoMessage(1), ProtoContract]
    public class Ping
    {
        [ProtoMember(1, IsRequired = true)]
        public string Payload { get; set; }
    }

    [ProtoMessage(2), ProtoContract]
    public class Pong
    {
        [ProtoMember(1, IsRequired = true)]
        public string Payload { get; set; }
    }

    [ProtoMessage(5), ProtoContract]
    public class OneWayPing
    {
        [ProtoMember(1, IsRequired = true)]
        public string Payload { get; set; }
    }
}