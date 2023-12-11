using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BSU.Map.DAL.Models
{
    public class Scientist
    { 
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }

        public virtual ICollection<AddMaterial> AddMaterials { get; set; }
        public virtual ICollection<MemoryPlace> MemoryPlaces { get; set; }
    }
}
