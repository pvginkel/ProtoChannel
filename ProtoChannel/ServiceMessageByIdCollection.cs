﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoChannel.Util;

namespace ProtoChannel
{
    internal class ServiceMessageByIdCollection : KeyedCollection<int, ServiceMessage>
    {
        protected override int GetKeyForItem(ServiceMessage item)
        {
            return item.Id;
        }
    }
}