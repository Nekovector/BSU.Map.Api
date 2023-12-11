using System.Threading.Tasks;
using BSU.Map.DAL.Models;

namespace BSU.Map.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Building> Buildings { get; }

        IRepository<StructuralObject> StructuralObjects  { get; }

        IRepository<Photo> Photos { get; }

        IRepository<Scientist> Scientists { get; }

        IRepository<MemoryPhoto> MemoryPhotos { get; }

        Task<bool> SaveChangesAsync();
    }
}
