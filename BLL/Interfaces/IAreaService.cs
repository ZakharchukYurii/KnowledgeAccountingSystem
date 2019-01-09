using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IAreaService
    {
        AreaDTO Get(int id);
        IEnumerable<AreaDTO> Get();
        void Create(AreaDTO item);
        void Update(AreaDTO item);
        void Delete(int id);
        void Dispose();
    }
}
