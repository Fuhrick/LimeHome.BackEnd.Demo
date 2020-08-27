using System;
using System.ComponentModel;

namespace LimeHome.BackEnd.Demo.Models
{
    /// <summary>
    /// Contains data about booking which returns from API.
    /// </summary>
    public class BookingLightModel
    {
        /// <summary>
        /// Public id.
        /// </summary>
        [ReadOnly(true)]
        public Guid PublicId { get; set; }

        /// <summary>
        /// First name of the customer.
        /// </summary>
        [ReadOnly(true)]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the customer.
        /// </summary>
        [ReadOnly(true)]
        public string LastName { get; set; }

        /// <summary>
        /// Id of the hotel.
        /// </summary>
        [ReadOnly(true)]
        public string HotelId { get; set; }

        /// <summary>
        /// Date from which will be booked.
        /// </summary>
        [ReadOnly(true)]
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Date to which will be booked.
        /// </summary>
        [ReadOnly(true)]
        public DateTime ToDate { get; set; }
    }
}
