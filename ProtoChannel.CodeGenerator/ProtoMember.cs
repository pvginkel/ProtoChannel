﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtoChannel.CodeGenerator
{
    internal class ProtoMember
    {
        public string Name { get; private set; }
        public int Tag { get; private set; }
        public bool IsRequired { get; private set; }

        public ProtoMember(string name, int tag, bool isRequired)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            Name = name;
            Tag = tag;
            IsRequired = isRequired;
        }
    }
}
