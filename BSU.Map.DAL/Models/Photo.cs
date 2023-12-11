using System;
using System.Collections.Generic;

#nullable disable

namespace BSU.Map.DAL.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int BuildingId { get; set; }

        public virtual Building Building { get; set; }
    }
}
