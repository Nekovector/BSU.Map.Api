using AutoMapper;
using BSU.Map.BLL.Dtos;
using BSU.Map.BLL.Interfaces;
using BSU.Map.DAL.Interfaces;
using BSU.Map.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSU.Map.BLL.Services
{
    public class MemoryPhotoService : BaseService, IMemoryPhotoService
    {
        public MemoryPhotoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<MemoryPhotoDto>> GetMemoryPhotos(int memoryPlaceId)
        {
            IEnumerable<MemoryPhoto> memoryPhotos = await UnitOfWork.MemoryPhotos
                .GetAll(p => p.MemoryPlaceId == memoryPlaceId)
                .ToListAsync();

            IEnumerable<MemoryPhotoDto> result = Mapper.Map<IEnumerable<MemoryPhotoDto>>(memoryPhotos);

            return result;
        }
    }
}
