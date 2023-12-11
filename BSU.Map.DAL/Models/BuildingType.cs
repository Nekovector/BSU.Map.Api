using System;
using System.Collections.Generic;

#nullable disable

namespace BSU.Map.DAL.Models
{
    public class BuildingType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string MarkerPath { get; set; }

        public virtual ICollection<Building> Buildings { get; set; }
    }
}
