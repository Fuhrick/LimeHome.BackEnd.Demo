using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using LimeHome.BackEnd.Demo.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LimeHome.BackEnd.Demo.DataAccess
{
    public class HereApi: IHereApi
    {
        private readonly string _apiKey;

        public HereApi(IOptions<ApplicationOptions> applicationOptions)
        {
            _apiKey = applicationOptions.Value.Data.HereApi.ApiKey;
        }

        public async Task<IEnumerable<Property>> GetProperties(double latitude, double longitude)
        {
            var url = "https://places.ls.hereapi.com/places/v1/discover/explore";
            var rawResponse = await url
                .SetQueryParam("at", $"{latitude},{longitude}", true)
                .SetQueryParam("cat", "hotel")
                .SetQueryParam("apiKey", _apiKey, true)
                .GetAsync();

            var responseProperties = await rawResponse.Content.ReadAsStringAsync();

            var properties = JsonConvert.DeserializeObject<Properties>(responseProperties);

            return properties.Results.PropertyList;
        }
    }
}
