﻿namespace ParkingService.Models
{
    public class ResidentVehicle : Vehicle
    {
        public int TotalTime { get; set; }

        public ResidentVehicle(string licensePlate) : base(licensePlate)
        {
            TotalTime = 0;
            VehicleType = VehicleType.RESIDENT;
        }
        public void AddMinutes(int minutes)
        {
            TotalTime += minutes;
        }
    }
}