using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DroneNavigationSystem.Domain.Services;
using DroneNavigationSystem.Domain.Telemetry;

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

        public Drone(string model, string manufacturer)
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
            ConsumeBattery(2);

            Console.WriteLine("Drone taking off...");
        } 
       public void MoveNorth()
        {
            if (!IsFlying)
            {
                Console.WriteLine("The drone must take off first.");
                return;
            }
            if (!HasEnoughBattery(1))
            {
                Console.WriteLine("Battery too low.");
                return;
            }

                Latitude += 1;
                ConsumeBattery(1);
        }

        public void MoveSouth()
        {
            if (!IsFlying)
            {
                Console.WriteLine("The drone must take off first.");
                return;
            }
            if (!HasEnoughBattery(1))
            {
                Console.WriteLine("Battery too low.");
                return;
            }

            Latitude -= 1;
            ConsumeBattery(1);
        }

        public void MoveEast()
        {
            if (!IsFlying)
            {
                Console.WriteLine("The drone must take off first.");
                return;
            }
            if (!HasEnoughBattery(1))
            {
                Console.WriteLine("Battery too low.");
                return;
            }

            Longitude += 1;
            ConsumeBattery(1);
        }
        
        public void MoveWest()
        {
            if (!IsFlying)
            {
                Console.WriteLine("The drone must take off first.");
                return;
            }
            if (!HasEnoughBattery(1))
            {
                Console.WriteLine("Battery too low.");
                return;
            }

            Longitude -= 1;
            ConsumeBattery(1);
        }

        public void Ascend()
        {
            if (!IsFlying)
            {
                Console.WriteLine("The drone must take off first.");
                return;
            }
            if (!HasEnoughBattery(2))
            {
                Console.WriteLine("Battery too low.");
                return;
            }
            Altitude += 10;
            ConsumeBattery(2);
        }

        public void Descend()
        {
            if (!IsFlying)
            {
                Console.WriteLine("The drone must take off first.");
                return;
            }
            if (!HasEnoughBattery(1))
            {
                Console.WriteLine("Battery too low.");
                return;
            }
            if (Altitude >= 10)
            {
                Altitude -= 10;
                ConsumeBattery(1);
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
            ConsumeBattery(1);

            Console.WriteLine("Drone landing...");
        }
        private void ConsumeBattery(double amount)
        {
            BatteryLevel -= amount;

            if (BatteryLevel < 0)
            {
                BatteryLevel = 0;
            }
        }
        private bool HasEnoughBattery(double required)
        {
            return BatteryLevel >= required;
        }
       public void ExecuteMission(Mission mission)
{
    Console.WriteLine();
    Console.WriteLine($"Starting mission: {mission.Name}");
    Console.WriteLine();

    var calculator = new NavigationCalculator();

    double totalDistance = 0;

    double currentLatitude = Latitude;
    double currentLongitude = Longitude;
    double currentAltitude = Altitude;

    foreach (var waypoint in mission.Waypoints)
    {
        double distance = calculator.CalculateDistance(
            currentLatitude,
            currentLongitude,
            currentAltitude,
            waypoint.Latitude,
            waypoint.Longitude,
            waypoint.Altitude);

        totalDistance += distance;

        currentLatitude = waypoint.Latitude;
        currentLongitude = waypoint.Longitude;
        currentAltitude = waypoint.Altitude;
    }

    Console.WriteLine(
        $"Total mission distance: {totalDistance:F2}");

    var energyCalculator = new EnergyCalculator();

    double estimatedMissionConsumption =
        energyCalculator.CalculateMissionConsumption(totalDistance);

    Console.WriteLine(
        $"Estimated mission energy consumption: {estimatedMissionConsumption:F2}%");

    const double minimumSafetyBattery = 20;

    double estimatedBatteryAfterMission =
        BatteryLevel - estimatedMissionConsumption;

    Console.WriteLine(
        $"Estimated battery after mission: {estimatedBatteryAfterMission:F2}%");

    if (estimatedBatteryAfterMission < minimumSafetyBattery)
    {
        Console.WriteLine(
            "Mission aborted: insufficient battery reserve.");

        return;
    }

    if (!IsFlying)
    {
        TakeOff();
    }

    foreach (var waypoint in mission.Waypoints)
    {
        MoveToWaypoint(waypoint);
    }

    Land();

    Console.WriteLine();
    Console.WriteLine("Mission completed successfully.");
}
        private void MoveToWaypoint(Waypoint waypoint)
        {

            var calculator = new NavigationCalculator();

            double distance = calculator.CalculateDistance(
                Latitude,
                Longitude,
                Altitude,
                waypoint.Latitude,
                waypoint.Longitude,
                waypoint.Altitude);

                Console.WriteLine();
                Console.WriteLine($"Distance to waypoint: {distance:F2}");
                Console.WriteLine();
            var energyCalculator = new EnergyCalculator();

            double estimatedConsumption =
            energyCalculator.CalculateConsumption(distance);

            Console.WriteLine($"Estimated energy consumption: {estimatedConsumption:F2}%");
            while (Latitude != waypoint.Latitude)
            {
                if (Latitude < waypoint.Latitude)
        {
            Latitude += 1;
        }
        else
        {
            Latitude -= 1;
        }

        ConsumeBattery(1);

        Console.WriteLine(
            $"Moving -> Lat:{Latitude} Lon:{Longitude} Alt:{Altitude} Battery:{BatteryLevel}%");
        }

        while (Longitude != waypoint.Longitude)
        {
            if (Longitude < waypoint.Longitude)
            {
                Longitude += 1;
            }
            else
            {
                Longitude -= 1;
        }

        ConsumeBattery(1);

            Console.WriteLine(
            $"Moving -> Lat:{Latitude} Lon:{Longitude} Alt:{Altitude} Battery:{BatteryLevel}%");
        }

        while (Altitude != waypoint.Altitude)
        {
            if (Altitude < waypoint.Altitude)
            {
                Altitude += 10;
            }
            else
            {
            Altitude -= 10;
        }

        ConsumeBattery(1);

        Console.WriteLine(
            $"Moving -> Lat:{Latitude} Lon:{Longitude} Alt:{Altitude} Battery:{BatteryLevel}%");
    }

    Console.WriteLine(
        $"Waypoint reached -> Lat:{Latitude} Lon:{Longitude} Alt:{Altitude}");
}
        public DroneTelemetry GetTelemetry()
        {
            return new DroneTelemetry(
                Latitude,
                Longitude,
                Altitude,
                BatteryLevel,
                IsFlying);
        }
       
    }
}