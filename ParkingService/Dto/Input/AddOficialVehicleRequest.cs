using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkingService.Dto.Input
{
    public class AddOficialVehicleRequest
    {
        /// <summary>
        /// XXX-00000
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(9)")]
        [RegularExpression(@"^[A-Z]{3}-[0-9]{5}$")]
        public string LicensePlate { get; set; } = "";
    }
}
