using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroneNavigationSystem.Domain.Telemetry
{
    public class DroneTelemetry
    {
        public double Latitude { get; }
        public double Longitude { get; }
        public double Altitude { get; }
        public double BatteryLevel { get; }
        public bool IsFlying { get; }

        public DroneTelemetry(
            double latitude,
            double longitude,
            double altitude,
            double batteryLevel,
            bool isFlying)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
            BatteryLevel = batteryLevel;
            IsFlying = isFlying;
        }
    }
}