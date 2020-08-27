using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using LimeHome.BackEnd.Demo.DataAccess;
using LimeHome.BackEnd.Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace LimeHome.BackEnd.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BookingStore _bookingStore;
        public BookingsController(BookingStore bookingStore)
        {
            _bookingStore = bookingStore;
        }

        /// <summary>
        /// Creates a new booking.
        /// </summary>
        /// <param name="model">Data.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody, Required] BookingModel model
        )
        {
            var id = await _bookingStore.Create(model);

            if (id == null)
            {
                return NotFound();
            }

            return Ok(id);
        }
    }
}
