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

            Console.WriteLine();

            Console.WriteLine($"Model: {drone.Model}");
            Console.WriteLine($"Manufacturer: {drone.Manufacturer}");
            Console.WriteLine($"Battery: {drone.BatteryLevel}%");
            Console.WriteLine($"Altitude: {drone.Altitude} m");
            Console.WriteLine($"Flying: {drone.IsFlying}");
        }
    }
}