using System;
using System.Collections.Generic;

#nullable disable

namespace BSU.Map.DAL.Models
{
    public class StructuralObjectsIcon
    {
        public int StructuralObjectId { get; set; }
        public string Subdivision { get; set; }
        public string LogoPath { get; set; }

        public virtual StructuralObject StructuralObject { get; set; }
    }
}
