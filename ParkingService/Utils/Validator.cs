using System.Text.RegularExpressions;

namespace ParkingService.Utils
{
    public static class Validator
    {
        public static bool IsValidLicensePlate(string value)
        {
            Regex regex = new Regex("^[A-Z]{3}-[0-9]{5}$");
            return regex.IsMatch(value);
        }
    }
}

