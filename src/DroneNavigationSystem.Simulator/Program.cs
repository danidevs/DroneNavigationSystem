using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DroneNavigationSystem.Domain.Entities;
using DroneNavigationSystem.Application.Services;


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
    
            var groundControl = new GroundControlService(drone);
            groundControl.ShowTelemetry();
            var mission = new Mission("First Autonomous Mission");
           

            mission.AddWaypoint(
            new Waypoint(2, 2, 20));

            mission.AddWaypoint(
            new Waypoint(4, 3, 30));

            mission.AddWaypoint(
            new Waypoint(5, 5, 10));

            groundControl.ExecuteMission(mission);

            groundControl.ShowTelemetry();
        }
    }
}