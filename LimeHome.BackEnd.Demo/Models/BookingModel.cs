using System;
using System.ComponentModel.DataAnnotations;
using LimeHome.BackEnd.Demo.Helpers.Attributes;

namespace LimeHome.BackEnd.Demo.Models
{
    /// <summary>
    /// Contains data required for creating booking.
    /// </summary>
    public class BookingModel
    {
        /// <summary>
        /// First name of the customer.
        /// </summary>
        [StringLength(50, MinimumLength = 2)]
        [Required]
        [Trim, PlainText]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the customer.
        /// </summary>
        [StringLength(50, MinimumLength = 2)]
        [Required]
        [Trim, PlainText]
        public string LastName { get; set; }

        /// <summary>
        /// Id of the hotel.
        /// </summary>
        [Required]
        public string HotelId { get; set; }

        /// <summary>
        /// Date from which will be booked.
        /// </summary>
        [Required]
        [DateMustBeEqualOrGreaterThanCurrentDate]
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Date to which will be booked.
        /// </summary>
        [Required]
        [DateMustBeEqualOrGreaterThanCurrentDate]
        public DateTime ToDate { get; set; }
    }
}
