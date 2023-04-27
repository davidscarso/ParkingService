using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingService.Models
{
    [Microsoft.EntityFrameworkCore.Index(nameof(LicensePlate), IsUnique = true)]

    abstract public class VehicleBase
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

        protected VehicleBase(string licensePlate)
        {
            Id = Guid.NewGuid();
            LicensePlate = licensePlate;
        }
    }

}
