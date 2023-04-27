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
            //if (_context.OficialVehicles == null)
            //{
            //    return Problem("Entity set 'APIDbContext.OficialVehicle'  is null.");
            //}
            //_context.OficialVehicles.Add(oficialVehicle);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetOficialVehicle", new { id = oficialVehicle.Id }, oficialVehicle);

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!StayExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

        }

        [HttpPost]
        [Route("CheckOut")]
        public async Task<ActionResult<CheckOutDto>> CheckOut(CheckOutRequest request)
        {
            return await _parkingService.CheckOut(request);
        }

        [HttpPost]
        [Route("AddResidentVehicle")]
        public async Task<ActionResult<ResidentVehicleDto>> AddResidentVehicle(AddResidentVehicleRequest request)
        {
            return await _parkingService.AddResidentVehicle(request);

        }

        [HttpPost]
        [Route("AddOficialVehicle")]
        public async Task<ActionResult<OficialVehicleDto>> AddOficialVehicle(AddOficialVehicleRequest request)
        {
            return await _parkingService.AddOficialVehicle(request);

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
