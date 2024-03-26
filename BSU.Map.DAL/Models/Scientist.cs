using System;
using System.Collections.Generic;

#nullable disable

namespace BSU.Map.DAL.Models
{
    public class Scientist
    {
        public Scientist()
        {
            MemoryPlaces = new HashSet<MemoryPlace>();
            ScientistDocs = new HashSet<ScientistDoc>();
            ScientistPhotos = new HashSet<ScientistPhoto>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Biography { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }

        public virtual ICollection<MemoryPlace> MemoryPlaces { get; set; }
        public virtual ICollection<ScientistDoc> ScientistDocs { get; set; }
        public virtual ICollection<ScientistPhoto> ScientistPhotos { get; set; }
    }
}
