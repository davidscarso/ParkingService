using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace ParkingService.Models
{
    public class CheckIn
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string LicensePlate { get; set; } = "";

        [Required]
        public DateTime CheckInTime { get; set; } = DateTime.Now;



        public CheckIn(string licensePlate)
        {
            Id = Guid.NewGuid();
            LicensePlate = licensePlate;
            CheckInTime = DateTime.Now;
        }
    }
}
