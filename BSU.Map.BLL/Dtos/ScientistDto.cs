using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSU.Map.BLL.Dtos
{
    public class ScientistDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime DeathDate { get; set; }

        public ICollection<AddMaterialDto> AddMaterials { get; set; }

        public ICollection<MemoryPlaceDto> MemoryPlaces { get; set; }
    }
}
