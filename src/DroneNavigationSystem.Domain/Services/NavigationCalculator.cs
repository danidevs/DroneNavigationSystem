using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroneNavigationSystem.Domain.Services
{
    public class NavigationCalculator
    {
        public double CalculateDistance(
            double latitude1,
            double longitude1,
            double altitude1,
            double latitude2,
            double longitude2,
            double altitude2)
        {
            double deltaLatitude = latitude2 - latitude1;
            double deltaLongitude = longitude2 - longitude1;
            double deltaAltitude = altitude2 - altitude1;

            return Math.Sqrt(
                Math.Pow(deltaLatitude, 2) +
                Math.Pow(deltaLongitude, 2) +
                Math.Pow(deltaAltitude, 2));
        }
    }
}