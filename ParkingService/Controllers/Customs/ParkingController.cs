using Microsoft.AspNetCore.Mvc;
using ParkingService.Dto.Input;
using ParkingService.Dto.Output;
using ParkingService.Services.Exceptions;
using ParkingService.Services.Interfaces;

namespace ParkingService.Controllers.Customs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _parkingService;

        public ParkingController(IParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        [HttpPost]
        [Route("CheckIn")]
        public async Task<ActionResult<CheckInDto>> CheckIn(CheckInRequest request)
        {
            try
            {
                return await _parkingService.CheckIn(request);
            }
            catch (CheckInLicensePlateNullException)
            {
                return BadRequest("Request.LicensePlate' is null.");
            }
            catch (CheckInLicensePlateEmptyException)
            {
                return BadRequest("'Request.LicensePlate' is Empty or White Space.");
            }
            catch (CheckInLicensePlateAlreadyExistsException)
            {
                return BadRequest("'nRequest.LicensePlate' already exist.");
            }
            catch (CheckInLicensePlateInvalidException)
            {
                return BadRequest("'Request.LicensePlate' is invalid.");
            }
        }

        [HttpPost]
        [Route("CheckOut")]
        public async Task<ActionResult<CheckOutDto>> CheckOut(CheckOutRequest request)
        {
            try
            {
                return await _parkingService.CheckOut(request);
            }
            catch (CheckOutLicensePlateNullException)
            {
                return BadRequest("Request.LicensePlate' is null.");
            }
            catch (CheckOutLicensePlateEmptyException)
            {
                return BadRequest("'Request.LicensePlate' is Empty or White Space.");
            }
            catch (CheckOutLicensePlateInvalidException)
            {
                return BadRequest("'Request.LicensePlate' is invalid.");
            }
            catch (CheckOutCheckInNotFoundException)
            {
                return NotFound("'Request.CheckIn' does not exist.");
            }
            catch (CheckOutFeeNotExistsException)
            {
                return NotFound("'Request.ParkingFee' does not exist.");
            }
        }

        [HttpPost]
        [Route("AddResidentVehicle")]
        public async Task<ActionResult<ResidentVehicleDto>> AddResidentVehicle(AddResidentVehicleRequest request)
        {
            try
            {
                return await _parkingService.AddResidentVehicle(request);
            }
            catch (AddVehicleLicensePlateNullException)
            {
                return BadRequest("'Request.LicensePlate' is null.");
            }
            catch (AddVehicleLicensePlateEmptyException)
            {
                return BadRequest("'Request.LicensePlate' is Empty or White Space.");
            }
            catch (AddVehicleLicensePlateAlreadyExistsException)
            {
                return BadRequest("'Request.LicensePlate' already exist.");
            }
            catch (AddVehicleLicensePlateInvalidException)
            {
                return BadRequest("'Request.LicensePlate' is invalid.");
            }
        }

        [HttpPost]
        [Route("AddOficialVehicle")]
        public async Task<ActionResult<OficialVehicleDto>> AddOficialVehicle(AddOficialVehicleRequest request)
        {
            try
            {
                return await _parkingService.AddOficialVehicle(request);
            }
            catch (AddVehicleLicensePlateNullException)
            {
                return BadRequest("'Request.LicensePlate' is null.");
            }
            catch (AddVehicleLicensePlateEmptyException)
            {
                return BadRequest("Request.LicensePlate' is Empty or White Space.");
            }
            catch (AddVehicleLicensePlateAlreadyExistsException)
            {
                return BadRequest("nRequest.LicensePlate' already exist.");
            }
            catch (AddVehicleLicensePlateInvalidException)
            {
                return BadRequest("'Request.LicensePlate' is invalid.");
            }
        }

        [HttpPost]
        [Route("StartMonth")]
        public void StartMonth()
        {
            _parkingService.StartMonth();
        }

        [HttpGet]
        [Route("GenerateResidentPayment")]
        public async Task<ActionResult<IEnumerable<PaymentReportDto>>> GenerateResidentPayment()
        {
            var result = _parkingService.GenerateResidentPayment();

            if (result == null) return NotFound();

            else return Ok(result);
        }

    }
}
