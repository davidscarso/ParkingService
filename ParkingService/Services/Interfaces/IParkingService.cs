using ParkingService.Dto.Input;
using ParkingService.Dto.Output;

namespace ParkingService.Services.Interfaces
{
    public interface IParkingService
    {
        public Task<CheckInDto> CheckIn(CheckInRequest request);
        public Task<CheckOutDto> CheckOut(CheckOutRequest request);
        public Task<ResidentVehicleDto> AddResidentVehicle(AddResidentVehicleRequest request);
        public Task<OficialVehicleDto> AddOficialVehicle(AddOficialVehicleRequest request);

        public void StartMonth();
        public Task<IEnumerable<PaymentReportDto>> GenerateResidentPayment();
    }
}
