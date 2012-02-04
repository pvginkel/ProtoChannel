﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProtoChannel
{
    internal class ServiceMethod
    {
        private readonly ProtoMethodAttribute _attribute;

        public bool IsOneWay
        {
            get { return _attribute.IsOneWay; }
        }

        public MethodInfo Method { get; private set; }

        public ServiceMessage Request { get; private set; }

        public ServiceMessage Response { get; private set; }

        public ServiceMethod(MethodInfo method, ProtoMethodAttribute attribute)
        {
            if (method == null)
                throw new ArgumentNullException("method");
            if (attribute == null)
                throw new ArgumentNullException("attribute");

            Method = method;

            _attribute = attribute;

            var parameters = method.GetParameters();

            if (parameters.Length != 1)
                throw new ProtoChannelException(String.Format("Invalid service method signature for method '{0}'; service methods must accept a ProtoMessage parameter and must return a ProtoMessage or void", method));

            Request = ServiceRegistry.GetMessageRegistration(parameters[0].ParameterType);

            if (method.ReturnType != typeof(void))
            {
                if (attribute.IsOneWay)
                    throw new ProtoChannelException(String.Format("Invalid service method signature for method '{0}'; IsOneWay methods must return void", method));

                Response = ServiceRegistry.GetMessageRegistration(method.ReturnType);
            }
        }
    }
}