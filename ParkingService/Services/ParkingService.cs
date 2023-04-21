using ParkingService.Domain;
using ParkingService.Dto.Input;
using ParkingService.Dto.Output;
using ParkingService.Interfaces;

namespace ParkingService.Services
{
    public class ParkingService : IParkingService
    {
        private readonly ICheckInRepository _checkInRepository;
        private readonly IParkingFeeRepository _parkingFeeRepository;
        private readonly IStayRepository _stayRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public ParkingService(ICheckInRepository checkInRepository,
                              IParkingFeeRepository parkingFeeRepository,
                              IStayRepository stayRepository,
                              IVehicleRepository vehicleRepository)
        {
            _checkInRepository = checkInRepository;
            _parkingFeeRepository = parkingFeeRepository;
            _stayRepository = stayRepository;
            _vehicleRepository = vehicleRepository;
        }

        public void AddOficialVehicle(AddOficialVehicleRequest request)
        {
            _vehicleRepository.Add(new OficialVehicle(request.LicensePlate));
        }

        public void AddResidentVehicle(AddResidentVehicleRequest request)
        {
            _vehicleRepository.Add(new ResidentVehicle(request.LicensePlate));
        }

        public void CheckIn(CheckInRequest request)
        {
            _checkInRepository.Add(new CheckIn(request.LicensePlate));
        }

        public void CheckOut(CheckOutRequest request)
        {
            var aCheckIn = _checkInRepository
                .AsEnumerable()
                .Where(x => x.LicensePlate == request.LicensePlate)
                .SingleOrDefault();

            var aVehicle = _vehicleRepository
                .AsEnumerable()
                .Where(x => x.LicensePlate == request.LicensePlate)
                .SingleOrDefault();

            aVehicle.ProcessCheckOut();
        }

        public IEnumerable<PaymentReportDto> GenerateResidentPayment()
        {
            throw new NotImplementedException();
        }

        public void StartMonth()
        {
            throw new NotImplementedException();
        }
    }
}
