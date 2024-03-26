using System;
using System.Collections.Generic;

#nullable disable

namespace BSU.Map.DAL.Models
{
    public class Coordinates
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public virtual BuildingAddress BuildingAddress { get; set; }
        public virtual MemoryPlace MemoryPlace { get; set; }
    }
}
