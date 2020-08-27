using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LimeHome.BackEnd.Demo.Helpers.Attributes
{
    /// <summary>
    /// Checks if a value is plain-text (e.g. it does not contain HTML tags).
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class PlainTextAttribute : ValidationAttribute
    {
        /// <summary>
        /// Initializes a new instance of this type.
        /// </summary>
        public PlainTextAttribute() : base("'{0}' must not contain HTML tags.")
        {

        }

        /// <summary>
        /// Matches an (opening) HTML tag.
        /// </summary>
        /// <remarks>
        /// CAUTION: The regular expression should use single-line mode in order to match tags like:
        /// <![CDATA[
        /// <script
        ///     scr="..."
        /// >
        /// // HACK
        /// </script>
        /// ]]>
        /// </remarks>
        static readonly Regex HtmlTagRegex = new Regex(@"<(\w+?).*?>", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline);

        /// <inheritdoc/>
        public override bool IsValid(object value)
        {
            if (value is string text)
            {
                return false == HtmlTagRegex.IsMatch(text);
            }
            else
            {
                return true;
            }
        }

        /// <inheritdoc/>
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
        }
    }
}
