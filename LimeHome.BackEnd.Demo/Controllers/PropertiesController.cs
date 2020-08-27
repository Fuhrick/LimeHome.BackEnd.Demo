using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LimeHome.BackEnd.Demo.DataAccess;
using LimeHome.BackEnd.Demo.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace LimeHome.BackEnd.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IHereApi _hereApi;
        private readonly BookingStore _bookingStore;

        public PropertiesController(IHereApi hereApi, BookingStore bookingStore)
        {
            _hereApi = hereApi;
            _bookingStore = bookingStore;
        }

        /// <summary>
        /// Returns properties by coordinates.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetPropertiesByCoordinates(
            [FromQuery, Required, MinLength(2), MaxLength(2), CommaSeparated] IEnumerable<double> at
        )
        {
            var latitude = at.FirstOrDefault();
            var longitude = at.ElementAtOrDefault(1);

            var result = await _hereApi.GetProperties(latitude, longitude);

            return result != null ? Ok(result) : (IActionResult)NotFound();
        }

        /// <summary>
        /// Returns properties by hotel id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}/bookings")]
        public async Task<IActionResult> GetBookingsByHotelId(
            [FromRoute, Required] string id
        )
        {
            var result = await _bookingStore.GetBookingsByHotelId(id);

            return result != null ? Ok(result) : (IActionResult)NotFound();
        }
    }
}
