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
       
        public bool IsFlying { get; private set; }

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
            
            IsFlying = false;
        } 
        public void TakeOff()
        {
            if (IsFlying)
            {
                Console.WriteLine("The drone is already flying.");
                return;
            }

            if (BatteryLevel < 20)
            {
                Console.WriteLine("Battery level is too low for takeoff.");
                return;
            }

            Altitude = 10;
            IsFlying = true;

            Console.WriteLine("Drone taking off...");
        } 
       public void MoveNorth()
        {
            if (!IsFlying)
            {
                Console.WriteLine("The drone must take off first.");
                return;
            }

                Latitude += 1;
        }

        public void MoveSouth()
        {
            Latitude -= 1;
        }

        public void MoveEast()
        {
            Longitude += 1;
        }

        public void MoveWest()
        {
            Longitude -= 1;
    }

        public void Ascend()
        {
            Altitude += 10;
        }

        public void Descend()
        {
            if (Altitude >= 10)
            {
                Altitude -= 10;
            }
        }
       public void Land()
        {
            if (!IsFlying)
            {
                Console.WriteLine("The drone is already on the ground.");
                return;
            }

            Altitude = 0;
            IsFlying = false;

            Console.WriteLine("Drone landing...");
        }
    }
}