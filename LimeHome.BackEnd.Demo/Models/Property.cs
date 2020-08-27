using System.Collections.Generic;
using Newtonsoft.Json;

namespace LimeHome.BackEnd.Demo.Models
{
    public class Property
    {
        /// <summary>
        /// Id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Vicinity.
        /// </summary>
        [JsonProperty("vicinity")]
        public string Vicinity { get; set; }

        /// <summary>
        /// Position.
        /// </summary>
        [JsonProperty("position")]
        public IEnumerable<double> Position { get; set; }
    }
}
