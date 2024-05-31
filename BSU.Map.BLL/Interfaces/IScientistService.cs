using System.Collections.Generic;
using System.Threading.Tasks;
using BSU.Map.BLL.Dtos.ScientistDtos;

namespace BSU.Map.BLL.Interfaces
{
    public interface IScientistService
    {
        Task<IEnumerable<ScientistDto>> GetAllScientists();
        Task<IEnumerable<ScientistLightDto>> GetScientistsNames();
        Task<ScientistDto> GetScientistById(int id);
        Task<bool> CreateScientist(ScientistModelDto scientist);
        Task<bool> UpdateScientist(int scientistId, ScientistModelDto scientist);
        Task<bool> DeleteScientist(int scientistId);
    }
}