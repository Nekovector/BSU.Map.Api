using AutoMapper;
using BSU.Map.BLL.Dtos;
using BSU.Map.BLL.Interfaces;
using BSU.Map.DAL.Interfaces;
using BSU.Map.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BSU.Map.BLL.Services
{
    public class ScientistService : BaseService, IScientistService
    {
        public ScientistService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<ScientistDto>> GetAllScientists()
        {
            IEnumerable<Scientist> scientists = await UnitOfWork.Scientists
                .GetAll()
                .Include(sc => sc.ScientistPhotos)
                .Include(sc => sc.ScientistDocs)
                .Include(sc => sc.MemoryPlaces)
                .ThenInclude(sc => sc.Coordinates)
                .AsSplitQuery()
                .ToListAsync();

            IEnumerable<ScientistDto> result = Mapper.Map<IEnumerable<ScientistDto>>(scientists);

            return result;
        }

        public async Task<bool> CreateScientist(ScientistModelDto scientist)
        {
            var scientistEntity = Mapper.Map<Scientist>(scientist);
            UnitOfWork.Scientists.Add(scientistEntity);
            bool result = await UnitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> UpdateScientist(int scientistId, ScientistModelDto scientist)
        {
            var scientistEntity = UnitOfWork.Scientists.GetById(scientistId);
            Mapper.Map(scientist, scientistEntity);
            UnitOfWork.Scientists.Update(scientistEntity);
            bool result = await UnitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteScientist(int scientistId)
        {
            var scientistEntity = UnitOfWork.Scientists.GetById(scientistId);
            UnitOfWork.Scientists.Delete(scientistEntity);
            bool result = await UnitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
