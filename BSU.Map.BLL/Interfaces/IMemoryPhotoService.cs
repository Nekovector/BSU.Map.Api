using System.Collections.Generic;
using System.Threading.Tasks;
using BSU.Map.BLL.Dtos;

namespace BSU.Map.BLL.Interfaces
{
    public interface IMemoryPhotoService
    {
        Task<IEnumerable<MemoryPhotoDto>> GetMemoryPhotos(int memoryPlaceId);
    }
}
