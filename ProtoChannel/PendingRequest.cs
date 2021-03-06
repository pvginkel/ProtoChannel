﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoChannel
{
    internal class PendingRequest
    {
        private readonly object _message;
        private readonly bool _isOneWay;
        private readonly uint _associationId;
        private readonly ServiceMethod _method;

        public PendingRequest(object message, bool isOneWay, uint associationId, ServiceMethod method)
        {
            Require.NotNull(message, "message");
            Require.NotNull(method, "method");

            _message = message;
            _isOneWay = isOneWay;
            _associationId = associationId;
            _method = method;
        }

        public object Message
        {
            get { return _message; }
        }

        public bool IsOneWay
        {
            get { return _isOneWay; }
        }

        public uint AssociationId
        {
            get { return _associationId; }
        }

        public ServiceMethod Method
        {
            get { return _method; }
        }
    }
}
