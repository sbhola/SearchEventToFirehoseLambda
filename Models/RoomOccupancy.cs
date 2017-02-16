using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class RoomOccupancy
    {
        public RoomOccupancy(IEnumerable<Occupant> occupants = null)
        {
            Occupants = occupants == null ? new List<Occupant>() : new List<Occupant>(occupants);
        }

        public List<Occupant> Occupants { get; }

    }

    public class Occupant
    {
        public Occupant(OccupantType type, int? age)
        {
            Type = type;
            Age = age;
        }

        public OccupantType Type { get; }

        public int? Age { get; }
    }
    public enum OccupantType
    {
        Adult,
        Child
    }
}