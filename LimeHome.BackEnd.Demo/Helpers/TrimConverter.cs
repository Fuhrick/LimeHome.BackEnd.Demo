using System;
using Newtonsoft.Json;

namespace LimeHome.BackEnd.Demo.Helpers
{
    /// <summary>
    /// Trims string values during deserialization.
    /// </summary>
    public class TrimConverter : JsonConverter
    {
        /// <summary>
        /// Gets a value indicating whether this Newtonsoft.Json.JsonConverter can read JSON.
        /// </summary>
        public override bool CanRead => true;

        /// <summary>
        /// Gets a value indicating whether this Newtonsoft.Json.JsonConverter can read JSON.
        /// </summary>
        public override bool CanWrite => false;

        /// <summary>
        /// Indicates if empty string values should be converted to <c>null</c>. The default is <c>true</c>.
        /// </summary>
        public bool TrimToNull { get; set; } = true;

        /// <summary>
        /// Replaces whitespace longer than a single character with a single white space. Also replace all whitespace
        /// characters with the interval character ' ' (0x20). The default is <c>false</c>.
        /// </summary>
        public bool NormalizeWhitespace { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of this type.
        /// </summary>
        public TrimConverter() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            // CAUTION: JSON.NET does not call the "CanConvert" method when the converter is applied on a property.
            // Source: https://stackoverflow.com/questions/26016119/jsonconverter-canconvert-does-not-receive-type
            // > CanConvert does not get called when you mark something with[JsonConverter]. When you use the attribute, 
            // > Json.Net assumes you have provided the correct converter, so it doesn't bother with the  CanConvert check. 
            // > If you remove the attribute, then it will get called by virtue of you passing the converter instance to the settings. 
            // > What you are seeing is Json.Net testing your converter for all the other property types.
            return objectType == typeof(string);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value is string text)
            {
                return text.TrimExt(TrimToNull, NormalizeWhitespace);
            }
            else
            {
                return reader.Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
