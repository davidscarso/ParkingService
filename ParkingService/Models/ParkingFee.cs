using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ParkingService.Models
{
    public class ParkingFee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public decimal Fee { get; set; } = 0;

        [Required]
        public VehicleType VehicleType { get; set; }

        public ParkingFee(decimal fee, VehicleType vehicleType)
        {
            Id = Guid.NewGuid();

            Fee = fee;
            VehicleType = vehicleType;
        }
    }
}
