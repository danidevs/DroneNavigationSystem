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
            Console.WriteLine("Ground Control: takeoff command sent.");
            _drone.TakeOff();
        }

        public void Land()
        {
            Console.WriteLine("Ground Control: landing command sent.");
            _drone.Land();
        }

        public void MoveNorth()
        {
            Console.WriteLine("Ground Control: moving north.");
            _drone.MoveNorth();
        }

        public void MoveSouth()
        {
            Console.WriteLine("Ground Control: moving south.");
            _drone.MoveSouth();
        }

        public void MoveEast()
        {
            Console.WriteLine("Ground Control: moving east.");
            _drone.MoveEast();
        }

        public void MoveWest()
        {
            Console.WriteLine("Ground Control: moving west.");
            _drone.MoveWest();
        }

        public void Ascend()
        {
            Console.WriteLine("Ground Control: ascending.");
            _drone.Ascend();
        }

        public void Descend()
        {
            Console.WriteLine("Ground Control: descending.");
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
        public void ExecuteMission(Mission mission)
        {
            Console.WriteLine();
            Console.WriteLine("Ground Control: sending mission to drone...");

            _drone.ExecuteMission(mission);
        }
        public void RunManualControl()
        {
            string? option;

            do
            {
                Console.WriteLine();
                Console.WriteLine("===== MANUAL CONTROL MODE =====");
                Console.WriteLine("1 - Take Off");
                Console.WriteLine("2 - Land");
                Console.WriteLine("3 - Move North");
                Console.WriteLine("4 - Move South");
                Console.WriteLine("5 - Move East");
                Console.WriteLine("6 - Move West");
                Console.WriteLine("7 - Ascend");
                Console.WriteLine("8 - Descend");
                Console.WriteLine("9 - Show Telemetry");
                Console.WriteLine("0 - Exit");
                Console.Write("Option: ");

                option = Console.ReadLine();

                switch (option)
                {
                case "1":
                TakeOff();
                break;

                case "2":
                Land();
                break;

                case "3":
                MoveNorth();
                break;

                case "4":
                MoveSouth();
                break;

                case "5":
                MoveEast();
                break;

                case "6":
                MoveWest();
                break;

                case "7":
                Ascend();
                break;

                case "8":
                Descend();
                break;

                case "9":
                ShowTelemetry();
                break;

                case "0":
                Console.WriteLine("Leaving manual control mode...");
                break;

                default:
                Console.WriteLine("Invalid option.");
                break;
                }

            } while (option != "0");
        }
    }
}