using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DroneNavigationSystem.Domain.Entities;

namespace DroneNavigationSystem.Simulator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================");
            Console.WriteLine(" Drone Navigation Simulator");
            Console.WriteLine(" Projeto Fênix");
            Console.WriteLine("=================================");

            var drone = new Drone(
                "Fênix X1",
                "OpenAI Aerospace");

            drone.TakeOff();

            drone.MoveNorth();
            drone.MoveNorth();

            drone.MoveEast();

            drone.Ascend();

            drone.MoveEast();

            drone.Descend();

            drone.Land();

            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("===== Final Drone Status =====");

            Console.WriteLine($"Latitude : {drone.Latitude}");

            Console.WriteLine($"Longitude: {drone.Longitude}");

            Console.WriteLine($"Altitude : {drone.Altitude}");

            Console.WriteLine($"Battery  : {drone.BatteryLevel}%");

            Console.WriteLine($"Flying   : {drone.IsFlying}");
        }
    }
}