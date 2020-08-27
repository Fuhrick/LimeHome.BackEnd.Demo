using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace LimeHome.BackEnd.Demo.Helpers
{
    /// <summary>
    /// Validates a complex object property.
    /// </summary>
    /// <remarks>
    /// Original source: https://searchcode.com/codesearch/raw/28022793/
    /// </remarks>
    public class ValidateObjectAttribute : ValidationAttribute
    {
        /// <inheritdoc/>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                // We cannot validate the properties of the given object when it is null
                return ValidationResult.Success;
            }

            switch (value)
            {
                case IDictionary dictionary:
                    return ValidateDictionary(dictionary, validationContext);
                case IEnumerable enumerable:
                    return ValidateEnumerable(enumerable, validationContext);
                default:
                    return ValidateObject(value, validationContext);
            }
        }

        ValidationResult ValidateDictionary(IDictionary dictionary, ValidationContext validationContext)
        {
            List<ValidationResult> resultList = null;

            var resultForKeys = ValidateEnumerable(dictionary.Keys, validationContext);
            if (resultForKeys != ValidationResult.Success)
            {
                (resultList ?? (resultList = new List<ValidationResult>())).AddRange(((CompositeValidationResult)resultForKeys).InnerResults);
            }

            var resultForValues = ValidateEnumerable(dictionary.Values, validationContext);
            if (resultForValues != ValidationResult.Success)
            {
                (resultList ?? (resultList = new List<ValidationResult>())).AddRange(((CompositeValidationResult)resultForValues).InnerResults);
            }

            return resultList == null ? ValidationResult.Success : new CompositeValidationResult(string.Format("Validation failed for '{0}'.", validationContext.DisplayName), resultList);
        }

        ValidationResult ValidateEnumerable(IEnumerable enumerable, ValidationContext validationContext)
        {
            var resultList = enumerable
                .Cast<object>()
                .Where(x => x != null && false == x is string && false == x.GetType().GetTypeInfo().IsValueType)
                .Select(item => IsValid(item, new ValidationContext(item, null, null)))
                .Where(result => result != ValidationResult.Success)
                .ToList();

            if (resultList.Count == 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new CompositeValidationResult(string.Format("Validation failed for '{0}'.", validationContext.DisplayName), resultList);
            }
        }

        ValidationResult ValidateObject(object value, ValidationContext validationContext)
        {
            var resultList = new List<ValidationResult>();

            if (Validator.TryValidateObject(value, new ValidationContext(value, null, null), resultList, true))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new CompositeValidationResult(string.Format("Validation failed for '{0}'.", validationContext.DisplayName), resultList);
            }
        }
    }
}
