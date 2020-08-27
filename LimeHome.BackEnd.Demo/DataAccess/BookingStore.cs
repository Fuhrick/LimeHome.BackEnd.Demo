using LimeHome.BackEnd.Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dawn.Guard;

namespace LimeHome.BackEnd.Demo.DataAccess
{
    public class BookingStore
    {
        private readonly BookingDbContext _bookingDb;

        public BookingStore(BookingDbContext bookingDb)
        {
            _bookingDb = bookingDb;
        }

        /// <summary>
        /// Creates new booking.
        /// </summary>
        /// <param name="model">Model.</param>
        /// <returns></returns>
        public async Task<Guid?> Create(BookingModel model)
        {
            Argument(model, nameof(model)).NotNull();

            if (string.IsNullOrEmpty(model.HotelId))
                return null;

            var publicId = Guid.NewGuid();

            Booking booking = new Booking
            {
                PublicId = publicId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                HotelId = model.HotelId,
                FromDate = model.FromDate,
                ToDate = model.ToDate
            };

            _bookingDb.Add(booking);
            await _bookingDb.SaveChangesAsync();

            return publicId;
        }

        /// <summary>
        /// Return bookings by id..
        /// </summary>
        /// <param name="hotelId">Id of the hotel.</param>
        /// <returns></returns>
        public async Task<IList<Booking>> GetBookingsByHotelId(string hotelId)
        {

            return await _bookingDb.Bookings.Where(t => t.HotelId == hotelId).ToListAsync();
        }
    }
}
