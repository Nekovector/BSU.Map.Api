using System;
using System.Collections.Generic;

#nullable disable

namespace BSU.Map.DAL.Models
{
    public class BuildingAddress
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CoordinatesId { get; set; }

        public virtual Coordinates Coordinates { get; set; }
        public virtual Building Building { get; set; }
    }
}
