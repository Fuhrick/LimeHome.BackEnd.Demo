using System.Collections.Generic;
using Newtonsoft.Json;

namespace LimeHome.BackEnd.Demo.Models
{
    public class Properties
    {
        [JsonProperty("results")] 
        public PropertyResults Results { get; set; }

        public class PropertyResults
        {
            [JsonProperty("items")]
            public IEnumerable<Property> PropertyList { get; set; }
        }
    }
}
