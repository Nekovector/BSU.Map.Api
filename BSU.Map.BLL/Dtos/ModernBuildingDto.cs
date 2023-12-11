using System.Collections.Generic;

namespace BSU.Map.BLL.Dtos
{
    public class ModernBuildingDto : HistoricalBuildingDto
    {
        public ICollection<StructuralObjectDto> StructuralObjects { get; set; }
    }
}
