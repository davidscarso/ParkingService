using ParkingService.Models;
using ParkingService.Dto.Input;
using ParkingService.Dto.Output;
using ParkingService.Infrastructure.Interfaces;
using ParkingService.Services.Interfaces;

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

        public Task<OficialVehicleDto> AddOficialVehicle(AddOficialVehicleRequest request)
        {
            throw new NotImplementedException();


            _vehicleRepository.Add(new OficialVehicle(request.LicensePlate));

        }

        public Task<ResidentVehicleDto> AddResidentVehicle(AddResidentVehicleRequest request)
        {
            throw new NotImplementedException();

            _vehicleRepository.Add(new ResidentVehicle(request.LicensePlate));
        }

        public async Task<CheckInDto> CheckIn(CheckInRequest request)
        {
            var savedCheckIn = await _checkInRepository.Add(new CheckIn(request.LicensePlate));
            if (savedCheckIn != null)
            {
                return new CheckInDto(savedCheckIn.Id, savedCheckIn.LicensePlate, savedCheckIn.CheckInTime);
            }

            return null;
        }

        public Task<CheckOutDto> CheckOut(CheckOutRequest request)
        {
            throw new NotImplementedException();

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


        public Task<IEnumerable<PaymentReportDto>> GenerateResidentPayment()
        {
            throw new NotImplementedException();
        }

        public void StartMonth()
        {
            throw new NotImplementedException();
        }
    }
}
