using Microsoft.EntityFrameworkCore;

namespace ParkingService.Models
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CheckIn> CheckIns { get; set; }

    }
}
