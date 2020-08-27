using System;
using System.ComponentModel.DataAnnotations;

namespace LimeHome.BackEnd.Demo.Models
{
    /// <summary>
    /// Contains data of the booking.
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Internal id if the booking.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Public id.
        /// </summary>
        public Guid PublicId { get; set; }

        /// <summary>
        /// First name of the customer.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the customer.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Id of the hotel.
        /// </summary>
        public string HotelId { get; set; }

        /// <summary>
        /// Date from which will be booked.
        /// </summary>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Date to which will be booked.
        /// </summary>
        public DateTime ToDate { get; set; }
    }
}
