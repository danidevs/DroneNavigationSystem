using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DroneNavigationSystem.Domain.Entities;

namespace DroneNavigationSystem.Application.Services
{
    public class GroundControlService
    {
        private readonly Drone _drone;

        public GroundControlService(Drone drone)
        {
            _drone = drone;
        }

        public void TakeOff()
        {
            _drone.TakeOff();
        }

        public void Land()
        {
            _drone.Land();
        }

        public void MoveNorth()
        {
            _drone.MoveNorth();
        }

        public void MoveSouth()
        {
            _drone.MoveSouth();
        }

        public void MoveEast()
        {
            _drone.MoveEast();
        }

        public void MoveWest()
        {
            _drone.MoveWest();
        }

        public void Ascend()
        {
            _drone.Ascend();
        }

        public void Descend()
        {
            _drone.Descend();
        }
        public void ShowTelemetry()
        {
            Console.WriteLine();
            Console.WriteLine("===== GROUND CONTROL TELEMETRY =====");
            Console.WriteLine($"Drone        : {_drone.Model}");
            Console.WriteLine($"Manufacturer : {_drone.Manufacturer}");
            Console.WriteLine($"Latitude     : {_drone.Latitude}");
            Console.WriteLine($"Longitude    : {_drone.Longitude}");
            Console.WriteLine($"Altitude     : {_drone.Altitude}");
            Console.WriteLine($"Battery      : {_drone.BatteryLevel}%");
            Console.WriteLine($"Flying       : {_drone.IsFlying}");
            Console.WriteLine("====================================");
        }
    }
}