using System.Collections.Generic;
using System.Threading.Tasks;
using BSU.Map.BLL.Dtos;

namespace BSU.Map.BLL.Interfaces
{
    public interface IStructuralObjectService
    {
        Task<IEnumerable<StructuralObjectDto>> GetBsuComplex();
    }
}
