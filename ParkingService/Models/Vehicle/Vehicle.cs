using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingService.Models
{
    abstract public class Vehicle
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// XXX-00000
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(9)")]
        [RegularExpression(@"^[A-Z]{3}-[0-9]{5}$")]
        public string LicensePlate { get; set; } = "";

        [Required]
        public VehicleType VehicleType { get; protected set; }

        protected Vehicle(string licensePlate)
        {
            Id = Guid.NewGuid();
            LicensePlate = licensePlate;
        }
    }

}
