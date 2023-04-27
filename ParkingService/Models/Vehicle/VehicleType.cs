using System.ComponentModel;

namespace ParkingService.Models
{
    public enum VehicleType
    {
        [Description("Oficial")]
        OFICIAL = 0,
        [Description("Resident")]
        RESIDENT = 1,
        [Description("Non Resident")]
        NON_RESIDENT = 2

    }
}
