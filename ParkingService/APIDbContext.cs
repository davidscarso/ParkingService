using Microsoft.EntityFrameworkCore;
using ParkingService.Models;

namespace ParkingService
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<ParkingFee> ParkingFees { get; set; }
        public DbSet<Stay> Stays { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Vehicle>(b =>
            {

                b.HasDiscriminator(b => b.VehicleType)
                                .HasValue<OficialVehicle>(VehicleType.OFICIAL)
                                .HasValue<ResidentVehicle>(VehicleType.RESIDENT);

                b.Property(e => e.VehicleType).HasMaxLength(50);

            });
        }
    }
}