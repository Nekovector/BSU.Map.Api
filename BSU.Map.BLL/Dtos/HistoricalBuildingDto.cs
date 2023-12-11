namespace BSU.Map.BLL.Dtos
{
    public class HistoricalBuildingDto
    {
        public int Id { get; set; }

        public string InventoryUsrreNumber { get; set; }

        public string Name { get; set; }

        public bool isModern { get; set; }

        public BuildingAddressDto Address { get; set; }

        public BuildingTypeDto Type { get; set; }
    }
}
