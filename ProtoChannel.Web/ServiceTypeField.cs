﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
﻿using ProtoChannel.Web.Util;

namespace ProtoChannel.Web
{
    internal class ServiceTypeField
    {
        public ReflectionOptimizer.Getter Getter { get; private set; }

        public ReflectionOptimizer.Setter Setter { get; private set; }

        public int Tag { get; private set; }

        public bool IsRequired { get; private set; }

        public ServiceType ServiceType { get; private set; }

        public Type Type { get; private set; }

        public Type CollectionType { get; private set; }

        public ServiceTypeField(ReflectionOptimizer.Getter getter, ReflectionOptimizer.Setter setter, int tag, bool isRequired, Type type)
        {
            if (getter == null)
                throw new ArgumentNullException("getter");
            if (setter == null)
                throw new ArgumentNullException("setter");
            if (type == null)
                throw new ArgumentNullException("type");

            Getter = getter;
            Setter = setter;
            Tag = tag;
            IsRequired = isRequired;
            Type = type;

            // See whether the field is a collection type.

            if (type != typeof(string) && type != typeof(byte[]))
            {
                Type listItemType = null;

                if (type.IsInterface && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    listItemType = type.GetGenericArguments()[0];
                }
                else
                {
                    foreach (var @interface in type.GetInterfaces())
                    {
                        if (@interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                        {
                            listItemType = @interface.GetGenericArguments()[0];
                        }
                    }
                }

                if (listItemType != null)
                {
                    // We handle two collection types: List<> and the rest.
                    // The rest we handle as an array.

                    bool isList = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);

                    if (isList)
                        CollectionType = type;
                    else
                        CollectionType = listItemType.MakeArrayType();

                    Type = listItemType;
                }
            }

            // Build the service type if the field type is a protobuf type.

            var typeAttributes = Type.GetCustomAttributes(typeof(ProtoContractAttribute), true);

            if (typeAttributes.Length > 0)
                ServiceType = new ServiceType(Type);
        }
    }
}