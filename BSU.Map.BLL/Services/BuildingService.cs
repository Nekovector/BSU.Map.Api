using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BSU.Map.BLL.Dtos;
using BSU.Map.BLL.Interfaces;
using BSU.Map.DAL.Interfaces;
using BSU.Map.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BSU.Map.BLL.Services
{
    public class BuildingService : BaseService, IBuildingService
    {
        public BuildingService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<ModernBuildingDto>> GetAllBuildingsInfoAsync()
        {
            IEnumerable<Building> buildings =  await UnitOfWork.Buildings
                .GetAll()
                .Include(b => b.Address)
                .ThenInclude(a => a.Coordinates)
                .Include(b => b.Type)
                .Include(b => b.StructuralObjects).ThenInclude(so => so.StructuralObjectsIcon)
                .Include(b => b.StructuralObjects).ThenInclude(b => b.Category)
                .ToListAsync();

            IEnumerable<ModernBuildingDto> result = Mapper.Map<IEnumerable<ModernBuildingDto>>(buildings);

            return result;
        }

        public async Task<IEnumerable<ModernBuildingDto>> GetModernBuildingsInfoAsync()
        {
            IEnumerable<Building> buildings = await UnitOfWork.Buildings
                .GetAll(b => !b.Type.Type.Equals("историческое"))
                .Include(b => b.Address)
                .ThenInclude(a => a.Coordinates)
                .Include(b => b.Type)
                .Include(b => b.StructuralObjects).ThenInclude(so => so.StructuralObjectsIcon)
                .Include(b => b.StructuralObjects).ThenInclude(b => b.Category)
                .ToListAsync();

            IEnumerable<ModernBuildingDto> result = Mapper.Map<IEnumerable<ModernBuildingDto>>(buildings);

            return result;
        }

        public async Task<IEnumerable<HistoricalBuildingDto>> GetHistoricalBuildingsInfoAsync()
        {
            IEnumerable<Building> buildings = await UnitOfWork.Buildings
                .GetAll(b => b.Type.Type.Equals("историческое"))
                .Include(b => b.Address)
                .ThenInclude(a => a.Coordinates)
                .Include(b => b.Type)
                .ToListAsync();

            IEnumerable<HistoricalBuildingDto> result = Mapper.Map<IEnumerable<HistoricalBuildingDto>>(buildings);

            return result;
        }
    }
}
