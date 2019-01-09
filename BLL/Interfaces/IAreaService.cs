using BLL.DTO;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IAreaService : IDisposable
    {
        AreaDTO Get(int id);
        IEnumerable<AreaDTO> Get();
        void Create(AreaDTO item);
        void Update(int id, AreaDTO item);
        void Delete(int id);
        //void Dispose();
    }
}
