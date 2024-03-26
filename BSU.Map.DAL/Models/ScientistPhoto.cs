using System;
using System.Collections.Generic;

#nullable disable

namespace BSU.Map.DAL.Models
{
    public class ScientistPhoto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public int ScientistId { get; set; }

        public virtual Scientist Scientist { get; set; }
    }
}
