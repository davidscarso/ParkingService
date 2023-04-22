using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingService.Models
{
    abstract public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// XXX-00000
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string LicensePlate { get; set; } = "";

        [Required]
        public VehicleType VehicleType { get; protected set; }

        protected Vehicle(string licensePlate)
        {
            LicensePlate = licensePlate;
        }

        public abstract void ProcessCheckOut();
    }

}
