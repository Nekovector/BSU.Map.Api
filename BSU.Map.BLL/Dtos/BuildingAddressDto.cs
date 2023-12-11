namespace BSU.Map.BLL.Dtos
{
    public class BuildingAddressDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public CoordinatesDto Coordinates { get; set; }
    }
}
