﻿using System;
using System.IO;

namespace EmptyBox.IO.Serializator.Rules
{
    public class TimeSpanRule : IBinarySerializatorRule
    {
        public BinarySerializer BinarySerializer { get; set; }

        public SuitabilityDegree CheckSuitability(Type type)
        {
            if (type == typeof(TimeSpan))
            {
                return SuitabilityDegree.Equal;
            }
            else
            {
                return SuitabilityDegree.NotAssignable;
            }
        }

        public bool TryDeserialize(BinaryReader reader, Type type, out dynamic value)
        {
            bool result = BinarySerializer.TryDeserialize(reader, out long data);
            if (result)
            {
                value = TimeSpan.FromTicks(data);
            }
            else
            {
                value = null;
            }
            return result;
        }

        public bool TryGetLength(dynamic variable, out uint length)
        {
            return BinarySerializer.TryGetLength(TimeSpan.Zero.Ticks, out length);
        }

        public bool TrySerialize(BinaryWriter writer, dynamic variable)
        {
            return TrySerialize(writer, variable.Ticks);
        }
    }
}