﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace ProtoChannel.Test.Services.PingPong
{
    [ProtoContract]
    [ProtoMessage(1)]
    internal class Ping
    {
        [ProtoMember(1, IsRequired = true)]
        public string Payload { get; set; }
    }

    [ProtoContract]
    [ProtoMessage(2)]
    internal class Pong
    {
        [ProtoMember(1, IsRequired = true)]
        public string Payload { get; set; }
    }
}