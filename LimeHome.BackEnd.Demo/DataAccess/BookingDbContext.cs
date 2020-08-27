using LimeHome.BackEnd.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace LimeHome.BackEnd.Demo.DataAccess
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
    }
}
