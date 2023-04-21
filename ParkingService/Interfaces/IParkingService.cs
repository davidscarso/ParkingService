using ParkingService.Dto.Input;
using ParkingService.Dto.Output;

namespace ParkingService.Interfaces
{
    public interface IParkingService
    {
        public void CheckIn(CheckInRequest request);
        public void CheckOut(CheckOutRequest request);
        public void AddResidentVehicle(AddResidentVehicleRequest request);
        public void AddOficialVehicle(AddOficialVehicleRequest request);

        public void StartMonth();
        public IEnumerable<PaymentReportDto> GenerateResidentPayment();
    }
}
