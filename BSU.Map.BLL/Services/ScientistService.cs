using AutoMapper;
using BSU.Map.BLL.Dtos;
using BSU.Map.BLL.Interfaces;
using BSU.Map.DAL.Interfaces;
using BSU.Map.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BSU.Map.BLL.Services
{
    public class ScientistService : BaseService, IScientistService
    {
        public ScientistService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<ScientistDto>> GetScientistInfo(int scientistId)
        {
            IEnumerable<Scientist> scientist = await UnitOfWork.Scientists
                .GetAll(sc => sc.Id == scientistId)
                .Include(sc => sc.MemoryPlaces)
                .ThenInclude(mp => mp.Coordinates)
                .Include(sc => sc.AddMaterials)
                .ToListAsync();
            
            IEnumerable<ScientistDto> result = Mapper.Map<IEnumerable<ScientistDto>>(scientist);

            return result;
        }
    }
}
