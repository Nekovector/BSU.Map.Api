using System;
using System.Collections.Generic;

#nullable disable

namespace BSU.Map.DAL.Models
{
    public class Building
    {
        public Building()
        {
            Photos = new HashSet<Photo>();
            StructuralObjects = new HashSet<StructuralObject>();
        }

        public int Id { get; set; }
        public string InventoryUsrreNumber { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int TypeId { get; set; }

        public virtual BuildingAddress Address { get; set; }
        public virtual BuildingType Type { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<StructuralObject> StructuralObjects { get; set; }
    }
}
