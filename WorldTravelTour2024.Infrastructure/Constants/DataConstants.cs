using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldTravelTour2024.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const int FirstNameMaxLength = 20;
        public const int FirstNameMinLength = 0;

        public const int LastNameMaxLength = 20;
        public const int LastNameMinLength = 0;

        public const int PhoneNumberMaxLength = 10;

        public const string MoneyMaxValue = "10000.00";
        public const string MoneyMinValue = "0.00";

        public const int EmailMaxLength = 25;
        public const int EmailMinLength = 5;

        public const int MaxNumberOfHostRooms = 10;
        public const int MinNumberOfHostRooms = 0;

        public const int AddressMaxLength = 35;
        public const int AddressMinLength = 10;

        public const string PricePerNightMaxValue = "500.00";
        public const string PricePerNightMinValue = "0.00";

        public const int CountryToTransportGuestNameMaxLength = 20;
        public const int CountryToTransportGuestNameMinLength = 0;

    }
}
