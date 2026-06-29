using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroneNavigationSystem.Domain.Entities
{
    public class Drone
    {
        public Guid Id { get; private set; }

        public string Model { get; private set; }

        public string Manufacturer { get; private set; }

        public double BatteryLevel { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public double Altitude { get; private set; }

        public Drone(
        string model,
        string manufacturer)
        {
            Id = Guid.NewGuid();

            Model = model;

            Manufacturer = manufacturer;

            BatteryLevel = 100;

            Latitude = 0;

            Longitude = 0;

            Altitude = 0;
        }  
    }
}