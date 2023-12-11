using System.Collections.Generic;
using System.Threading.Tasks;
using BSU.Map.BLL.Dtos;

namespace BSU.Map.BLL.Interfaces
{
    public interface IPhotoService
    {
        Task<IEnumerable<PhotoDto>> GetBuildingPhotos(int buildingId);
    }
}
