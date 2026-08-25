using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroneNavigationSystem.Domain.Telemetry
{
    public class DroneTelemetry
    {
        public string Model { get; }
        public string Manufacturer { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public double Altitude { get; }
        public double BatteryLevel { get; }
        public bool IsFlying { get; }

        public DroneTelemetry(
            string model,
            string manufacturer,
            double latitude,
            double longitude,
            double altitude,
            double batteryLevel,
            bool isFlying)
        {
            Model = model;
            Manufacturer = manufacturer;
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
            BatteryLevel = batteryLevel;
            IsFlying = isFlying;
        }
    }
}