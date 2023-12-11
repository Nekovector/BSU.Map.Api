using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BSU.Map.BLL.Dtos;
using BSU.Map.BLL.Interfaces;
using BSU.Map.DAL.Interfaces;
using BSU.Map.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BSU.Map.BLL.Services
{
    public class PhotoService : BaseService, IPhotoService
    {
        public PhotoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<PhotoDto>> GetBuildingPhotos(int buildingId)
        {
            IEnumerable<Photo> buildingPhotos = await UnitOfWork.Photos
                .GetAll(p => p.BuildingId == buildingId)
                .ToListAsync();

            IEnumerable<PhotoDto> result = Mapper.Map<IEnumerable<PhotoDto>>(buildingPhotos);

            return result;
        }
    }
}
