namespace BSU.Map.BLL.Dtos
{
    public class StructuralObjectDto
    {
        public int Id { get; set; }

        public string Subdivision { get; set; }

        public string Description { get; set; }

        public string Website { get; set; }

        public int BuildingId { get; set; }

        public StructuralObjectCategoryDto Category { get; set; }

        public StructuralObjectIconDto Icon { get; set; }
    }
}
