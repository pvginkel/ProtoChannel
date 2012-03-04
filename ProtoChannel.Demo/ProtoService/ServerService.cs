﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using ProtoChannel.Demo.Shared;

namespace ProtoChannel.Demo.ProtoService
{
    public class ServerService
    {
        [ProtoMethod]
        public SimpleMessage SimpleMessage(SimpleMessage message)
        {
            return message;
        }

        [ProtoMethod]
        public ComplexMessage ComplexMessage(ComplexMessage message)
        {
            return message;
        }
    }
}
