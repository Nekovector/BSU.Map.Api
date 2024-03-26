using System;
using System.Collections.Generic;

#nullable disable

namespace BSU.Map.DAL.Models
{
    public class MemoryDoc
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public int MemoryPlaceId { get; set; }

        public virtual MemoryPlace MemoryPlace { get; set; }
    }
}
