using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroneNavigationSystem.Domain.Entities
{
    public class Waypoint
    {
         public double Latitude { get; }

        public double Longitude { get; }

        public double Altitude { get; }

        public Waypoint(
        double latitude,
        double longitude,
        double altitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }
    }
}