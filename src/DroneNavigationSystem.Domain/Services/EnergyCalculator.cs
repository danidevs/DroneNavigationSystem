using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroneNavigationSystem.Domain.Services
{
    public class EnergyCalculator
    {
        public double CalculateConsumption(double distance)
        {
            return distance * 0.5;
        }
        public double CalculateMissionConsumption(double totalDistance)
        {
            return CalculateConsumption(totalDistance);
        }
    }
}