using System;
using Newtonsoft.Json;

namespace LimeHome.BackEnd.Demo.Helpers.Attributes
{
    /// <summary>
    /// Provides a way to specify a JSON converter by using an attribute instead of using an instance class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public abstract class JsonConverterProviderAttribute : Attribute
    {
        /// <summary>
        /// Indicates if the convert should be applied to collection items or to the property itself.
        /// </summary>
        internal virtual bool IsItemConverter => false;

        /// <summary>
        /// Initializes a new instance of this type.
        /// </summary>
        protected JsonConverterProviderAttribute() { }

        /// <summary>
        /// Returns the converter to use.
        /// </summary>
        /// <returns>A converter.</returns>
        public abstract JsonConverter GetConverter();
    }
}
