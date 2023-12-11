using System;
using System.Collections.Generic;

#nullable disable

namespace BSU.Map.DAL.Models
{
    public class MemoryPhoto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int MemoryPlaceId { get; set; }

        public virtual MemoryPlace MemoryPlace { get; set; }
    }
}
