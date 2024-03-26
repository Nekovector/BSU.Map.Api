namespace BSU.Map.BLL.Dtos
{
    public class MemoryPlaceDto
    {
        public int Id { get; set; }

        public int OrdinalNumber { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CoordinatesDto Coordinates { get; set; }
    }
}
