using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingService.Dto.Input;
using ParkingService.Dto.Output;
using ParkingService.Models;
using ParkingService.Services.Interfaces;

namespace ParkingService.Controllers
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
            return await _parkingService.CheckIn(request);
        }

        [HttpPost]
        [Route("CheckOut")]
        public async Task<ActionResult<CheckOutDto>> CheckOut(CheckOutRequest request)
        {
            return NotFound();
        }

        [HttpPost]
        [Route("AddResidentVehicle")]
        public async Task<ActionResult<ResidentVehicleDto>> AddResidentVehicle(AddResidentVehicleRequest request)
        {
            return NotFound();
        }

        [HttpPost]
        [Route("AddOficialVehicle")]
        public async Task<ActionResult<OficialVehicleDto>> AddOficialVehicle(AddOficialVehicleRequest request)
        {
            return NotFound();
        }

        [HttpPost]
        [Route("StartMonth")]
        public void StartMonth()
        {
        }

        [HttpGet]
        [Route("GenerateResidentPayment")]
        public async Task<ActionResult<IEnumerable<PaymentReportDto>>> GenerateResidentPayment()
        {
            var result = await _parkingService.GenerateResidentPayment();

            if (result == null) return NotFound();

            else return Ok(result);
        }

    }
}
