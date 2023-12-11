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
    public class StructuralObjectService: BaseService, IStructuralObjectService
    {
        public StructuralObjectService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Method to retrieve all bsu complex objects, which exist at a modern time.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StructuralObjectDto>> GetBsuComplex()
        {
            IEnumerable<StructuralObject> structuralObjects = await UnitOfWork.StructuralObjects
                .GetAll()
                .Include(so => so.Category)
                .Include(so => so.StructuralObjectsIcon)
                .ToListAsync();

            IEnumerable<StructuralObjectDto> result = Mapper.Map<IEnumerable<StructuralObjectDto>>(structuralObjects);

            return result;
        }
    }
}
