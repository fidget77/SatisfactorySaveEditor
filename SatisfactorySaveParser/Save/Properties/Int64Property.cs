﻿using System;
using System.IO;

using SatisfactorySaveParser.Save.Properties.Abstractions;

namespace SatisfactorySaveParser.Save.Properties
{
    public class Int64Property : SerializedProperty, IInt64PropertyValue
    {
        public const string TypeName = nameof(Int64Property);
        public override string PropertyType => TypeName;

        public override Type BackingType => typeof(long);
        public override object BackingObject => Value;

        public override int SerializedLength => 8;

        public long Value { get; set; }

        public Int64Property(string propertyName, int index = 0) : base(propertyName, index)
        {
        }

        public override string ToString()
        {
            return $"Int64 {PropertyName}: {Value}";
        }

        public static Int64Property Deserialize(BinaryReader reader, string propertyName, int index)
        {
            var result = new Int64Property(propertyName, index);

            result.ReadPropertyGuid(reader);
            result.Value = reader.ReadInt64();

            return result;
        }

        public override void Serialize(BinaryWriter writer)
        {
            WritePropertyGuid(writer);
            writer.Write(Value);
        }
    }
}
