using System.ComponentModel.DataAnnotations;
using LimeHome.BackEnd.Demo.Helpers;

namespace LimeHome.BackEnd.Demo.DataAccess
{
    /// <summary>
    /// Application options.
    /// </summary>
    public class ApplicationOptions
    {
        /// <summary>
        /// Connection string.
        /// </summary>
        [Required]
        [ValidateObject]
        public ApplicationOptionsData Data { get; set; }
    }

    /// <summary>
    /// Data options.
    /// </summary>
    public class ApplicationOptionsData
    {
        /// <summary>
        /// Here api options.
        /// </summary>
        [Required, ValidateObject]
        public HereApiOptions HereApi { get; set; }
    }

    /// <summary>
    /// Here api options.
    /// </summary>
    public class HereApiOptions
    {
        /// <summary>
        /// Api key.
        /// </summary>
        [Required]
        public string ApiKey { get; set; }
    }
}
