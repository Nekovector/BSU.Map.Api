using System;
using System.Collections.Generic;

#nullable disable

namespace BSU.Map.DAL.Models
{
    public class Category
    {
        public Category()
        {
            StructuralObjects = new HashSet<StructuralObject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StructuralObject> StructuralObjects { get; set; }
    }
}
