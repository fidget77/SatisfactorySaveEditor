﻿using System;
using System.IO;

using SatisfactorySaveParser.Save.Properties.Abstractions;

namespace SatisfactorySaveParser.Save.Properties
{
    public class StrProperty : SerializedProperty, IStrPropertyValue
    {
        public const string TypeName = nameof(StrProperty);
        public override string PropertyType => TypeName;

        public override Type BackingType => typeof(string);
        public override object BackingObject => Value;

        public override int SerializedLength => Value.GetSerializedLength();

        public string Value { get; set; }

        public StrProperty(string propertyName, int index = 0) : base(propertyName, index)
        {
        }

        public override string ToString()
        {
            return $"String {PropertyName}: {Value}";
        }

        public static StrProperty Deserialize(BinaryReader reader, string propertyName, int index)
        {
            var result = new StrProperty(propertyName, index);

            result.ReadPropertyGuid(reader);
            result.Value = reader.ReadLengthPrefixedString();

            return result;
        }

        public override void Serialize(BinaryWriter writer)
        {
            WritePropertyGuid(writer);
            writer.WriteLengthPrefixedString(Value);
        }
    }
}
