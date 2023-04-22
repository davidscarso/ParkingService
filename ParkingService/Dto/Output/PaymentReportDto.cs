using System.Diagnostics.Contracts;

namespace ParkingService.Dto.Output
{
    public class PaymentReportDto
    {
        public string LicensePlate { get; set; }

        public int TotalTime { get; set; }

        public decimal TotalAmount { get; set; }

        public PaymentReportDto(string licensePlate, int totalTime, decimal totalAmount)
        {
            LicensePlate = licensePlate;
            TotalTime = totalTime;
            TotalAmount = totalAmount;
        }
    }
}
