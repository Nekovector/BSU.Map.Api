using System;
using System.Collections.Generic;

#nullable disable

namespace BSU.Map.DAL.Models
{
    public class StructuralObject
    {
        public int Id { get; set; }
        public string Subdivision { get; set; }
        public int CategoryId { get; set; }
        public int BuildingId { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }

        public virtual Building Building { get; set; }
        public virtual Category Category { get; set; }
        public virtual StructuralObjectsIcon StructuralObjectsIcon { get; set; }
    }
}
