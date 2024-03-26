using System;
using System.Collections.Generic;

namespace BSU.Map.BLL.Dtos
{
    public class ScientistDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Biography { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime? DeathDate { get; set; }

        public ICollection<ScientistPhotoDto> ScientistPhotos { get; set; }

        public ICollection<ScientistDocDto> ScientistDocs { get; set; }

        public ICollection<MemoryPlaceDto> MemoryPlaces { get; set; }
    }
}
