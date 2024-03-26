using System;
using System.Collections.Generic;

#nullable disable

namespace BSU.Map.DAL.Models
{
    public class MemoryPlace
    {
        public MemoryPlace()
        {
            MemoryDocs = new HashSet<MemoryDoc>();
            MemoryPhotos = new HashSet<MemoryPhoto>();
        }

        public int Id { get; set; }
        public int OrdinalNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoordinatesId { get; set; }
        public int ScientistId { get; set; }

        public virtual Coordinates Coordinates { get; set; }
        public virtual Scientist Scientist { get; set; }
        public virtual ICollection<MemoryDoc> MemoryDocs { get; set; }
        public virtual ICollection<MemoryPhoto> MemoryPhotos { get; set; }
    }
}
