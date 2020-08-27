using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LimeHome.BackEnd.Demo.Helpers
{
    /// <summary>
    /// Represents a container for the results of a validation request.
    /// </summary>
    /// <remarks>
    /// Original source: https://searchcode.com/codesearch/raw/28022792/
    /// </remarks>
    public class CompositeValidationResult : ValidationResult
    {
        /// <summary>
        /// Validation results.
        /// </summary>
        public IReadOnlyCollection<ValidationResult> InnerResults { get; }

        /// <summary>
        /// Initializes a new instance of this type.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="innerResults"></param>
        public CompositeValidationResult(string errorMessage, IReadOnlyCollection<ValidationResult> innerResults)
            : base(errorMessage)
        {
            this.InnerResults = innerResults;
        }

        /// <summary>
        /// Initializes a new instance of this type.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="memberNames"></param>
        /// <param name="innerResults"></param>
        public CompositeValidationResult(string errorMessage, IEnumerable<string> memberNames, IReadOnlyCollection<ValidationResult> innerResults)
            : base(errorMessage, memberNames)
        {
            this.InnerResults = innerResults;
        }
    }
}
