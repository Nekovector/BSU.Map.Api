using System.Collections.Generic;
using System.Threading.Tasks;
using BSU.Map.BLL.Dtos;

namespace BSU.Map.BLL.Interfaces
{
    public interface IBuildingService
    {
        Task<IEnumerable<ModernBuildingDto>> GetAllBuildingsInfoAsync();

        Task<IEnumerable<ModernBuildingDto>> GetModernBuildingsInfoAsync();

        Task<IEnumerable<HistoricalBuildingDto>> GetHistoricalBuildingsInfoAsync();
    }
}
