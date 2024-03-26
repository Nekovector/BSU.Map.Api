using System.Threading.Tasks;
using BSU.Map.DAL.Interfaces;
using BSU.Map.DAL.Models;
using BSU.Map.DAL.Repositories;

namespace BSU.Map.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Building> _buildingRepository;

        private IRepository<StructuralObject> _structuralObjectsRepository;

        private IRepository<Photo> _photosRepository;

        private IRepository<Scientist> _scientistsRepository;

        private IRepository<MemoryPhoto> _memoryPhotosRepository;

        private readonly bsu_mapContext _context;


        public IRepository<Building> Buildings => GetRepository(ref _buildingRepository);

        public IRepository<StructuralObject> StructuralObjects => GetRepository(ref _structuralObjectsRepository);

        public IRepository<Photo> Photos => GetRepository(ref _photosRepository);

        public IRepository<Scientist> Scientists => GetRepository(ref _scientistsRepository);

        public IRepository<MemoryPhoto> MemoryPhotos => GetRepository(ref _memoryPhotosRepository);

        public UnitOfWork(bsu_mapContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            int changes = await _context.SaveChangesAsync();

            return changes > 0;
        }

        private IRepository<T> GetRepository<T>(ref IRepository<T> repositoryField) where T : class
        {
            return repositoryField ??= new Repository<T>(_context);
        }
    }
}
