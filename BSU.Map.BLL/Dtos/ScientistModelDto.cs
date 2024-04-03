using System;

namespace BSU.Map.BLL.Dtos
{
    public class ScientistModelDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Biography { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime DeathDate { get; set; }
    }
}
