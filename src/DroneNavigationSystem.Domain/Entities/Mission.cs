using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroneNavigationSystem.Domain.Entities
{
    public class Mission
    {
         public Guid Id { get; }

        public string Name { get; }

        public List<Waypoint> Waypoints { get; }

        public Mission(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Waypoints = new List<Waypoint>();
        }

        public void AddWaypoint(Waypoint waypoint)
        {
            Waypoints.Add(waypoint);
        }
    }
}