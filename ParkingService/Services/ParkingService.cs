using ParkingService.Models;
using ParkingService.Dto.Input;
using ParkingService.Dto.Output;
using ParkingService.Infrastructure.Interfaces;
using ParkingService.Services.Interfaces;
using System.Text.RegularExpressions;
using ParkingService.Services.Exceptions;
using ParkingService.Utils;
using System.Linq;

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

        public async Task<OficialVehicleDto> AddOficialVehicle(AddOficialVehicleRequest request)
        {
            if (request.LicensePlate == null)
                throw new AddVehicleLicensePlateNullException();

            if (string.IsNullOrWhiteSpace(request.LicensePlate))
                throw new AddVehicleLicensePlateEmptyException();

            if (!Validator.IsValidLicensePlate(request.LicensePlate))
                throw new AddVehicleLicensePlateInvalidException();

            if (_vehicleRepository.Exists(request.LicensePlate))
                throw new AddVehicleLicensePlateAlreadyExistsException();


            var added = (OficialVehicle)(await _vehicleRepository.Add(new OficialVehicle(request.LicensePlate)));

            if (added != null)
            {
                return new OficialVehicleDto(added.Id, added.LicensePlate);
            }

            return null;
        }

        public async Task<ResidentVehicleDto> AddResidentVehicle(AddResidentVehicleRequest request)
        {
            if (request.LicensePlate == null)
                throw new AddVehicleLicensePlateNullException();

            if (string.IsNullOrWhiteSpace(request.LicensePlate))
                throw new AddVehicleLicensePlateEmptyException();

            if (!Validator.IsValidLicensePlate(request.LicensePlate))
                throw new AddVehicleLicensePlateInvalidException();

            if (_vehicleRepository.Exists(request.LicensePlate))
                throw new AddVehicleLicensePlateAlreadyExistsException();

            var added = (ResidentVehicle)(await _vehicleRepository.Add(new ResidentVehicle(request.LicensePlate)));

            if (added != null)
            {
                return new ResidentVehicleDto(added.Id, added.LicensePlate, added.TotalTime);
            }

            return null;
        }

        public async Task<CheckInDto> CheckIn(CheckInRequest request)
        {
            if (request.LicensePlate == null)
                throw new CheckInLicensePlateNullException();

            if (string.IsNullOrWhiteSpace(request.LicensePlate))
                throw new CheckInLicensePlateEmptyException();

            if (!Validator.IsValidLicensePlate(request.LicensePlate))
                throw new CheckInLicensePlateInvalidException();

            if (_checkInRepository.Exists(request.LicensePlate))
                throw new CheckInLicensePlateAlreadyExistsException();


            var savedCheckIn = await _checkInRepository.Add(new CheckIn(request.LicensePlate));

            if (savedCheckIn != null)
            {
                return new CheckInDto(savedCheckIn.Id,
                                      savedCheckIn.LicensePlate,
                                      savedCheckIn.CheckInTime);
            }

            return null;
        }

        public async Task<CheckOutDto> CheckOut(CheckOutRequest request)
        {
            if (request.LicensePlate == null)
                throw new CheckOutLicensePlateNullException();

            if (string.IsNullOrWhiteSpace(request.LicensePlate))
                throw new CheckOutLicensePlateEmptyException();

            if (!Validator.IsValidLicensePlate(request.LicensePlate))
                throw new CheckOutLicensePlateInvalidException();

            if (!_checkInRepository.Exists(request.LicensePlate))
                throw new CheckOutCheckInNotFoundException();


            var aCheckIn = _checkInRepository
                .AsEnumerable()
                .Where(x => x.LicensePlate == request.LicensePlate)
                .SingleOrDefault();

            var aVehicle = _vehicleRepository
                .AsEnumerable()
                .Where(x => x.LicensePlate == request.LicensePlate)
                .SingleOrDefault();


            var checkOutTime = DateTime.Now;
            var totalMinutes = (int)checkOutTime.Subtract(aCheckIn.CheckInTime).TotalMinutes;

            var vehicleType = aVehicle == null ? VehicleType.NON_RESIDENT : aVehicle.VehicleType;

            var fees = _parkingFeeRepository.AsEnumerable();
            var fee = fees.Where(x => x.VehicleType == vehicleType).SingleOrDefault();

            if (fee == null) throw new CheckOutFeeNotExistsException("Parking Fee not found");

            var amount = fee.Fee * totalMinutes;

            var checkOutDto = new CheckOutDto(aCheckIn.LicensePlate, aCheckIn.CheckInTime, checkOutTime, totalMinutes, amount);

            if (vehicleType == VehicleType.RESIDENT)
            {
                ((ResidentVehicle)aVehicle).AddMinutes(totalMinutes);
                await _vehicleRepository.Update(aVehicle);
            }

            if (vehicleType == VehicleType.OFICIAL)
            {
                var addedStay = await _stayRepository.Add(new Stay(aCheckIn.CheckInTime, checkOutTime, aVehicle.Id));
            }

            await _checkInRepository.DeleteAsync(aCheckIn.Id);
            return checkOutDto;
        }


        public IEnumerable<PaymentReportDto> GenerateResidentPayment()
        {
            var fee = _parkingFeeRepository.AsEnumerable().Where(x => x.VehicleType == VehicleType.RESIDENT).SingleOrDefault();
            if (fee == null)
                throw new Exception("Parking Fee not found");
            else
            {
                var residents = _vehicleRepository.AsEnumerable().Where(x => x.VehicleType == VehicleType.RESIDENT);

                var records = residents.Select(x => new PaymentReportDto(x.LicensePlate, ((ResidentVehicle)x).TotalTime, ((ResidentVehicle)x).TotalTime * fee.Fee));

                return records;
            }
        }

        public void StartMonth()
        {
            //Delete all Stays
            _stayRepository.DeleteAll();

            //Update TotalTime to 0 y ResidenteVehicles
            var residents = _vehicleRepository.AsEnumerable().Where(x => x.VehicleType == VehicleType.RESIDENT);

            foreach (var residentVehicle in residents)
            {
                ((ResidentVehicle)residentVehicle).RestartMinutes();
                _vehicleRepository.Update(((ResidentVehicle)residentVehicle));
            }

        }
    }
}
