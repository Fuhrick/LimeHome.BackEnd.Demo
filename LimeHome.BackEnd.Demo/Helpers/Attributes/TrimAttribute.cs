using Newtonsoft.Json;

namespace LimeHome.BackEnd.Demo.Helpers.Attributes
{
    /// <summary>
    /// Trims string values during deserialization.
    /// </summary>
    public sealed class TrimAttribute : JsonConverterProviderAttribute
    {
        /// <summary>
        /// Indicates if empty string values should be converted to <c>null</c>. The default is <c>true</c>.
        /// </summary>
        public bool TrimToNull { get; set; } = true;

        /// <summary>
        /// Replaces whitespace longer than a single character with a single white space. Also replace all whitespace
        /// characters (like '\n', '\t', etc.) with the interval character ' ' (0x20). The default is <c>false</c>.
        /// </summary>
        public bool NormalizeWhitespace { get; set; } = false;

        /// <summary>
        /// Returns the converter to use.
        /// </summary>
        /// <returns>A converter.</returns>
        public override JsonConverter GetConverter()
        {
            return new TrimConverter()
            {
                TrimToNull = this.TrimToNull,
                NormalizeWhitespace = this.NormalizeWhitespace,
            };
        }
    }
}
