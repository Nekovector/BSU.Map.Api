using AutoMapper;
using BSU.Map.DAL.Interfaces;

namespace BSU.Map.BLL.Services
{
    public abstract class BaseService
    {
        protected IUnitOfWork UnitOfWork { get; }

        protected IMapper Mapper { get; }

        protected BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
    }
}
