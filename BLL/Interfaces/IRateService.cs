using BLL.DTO;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IRateService : IDisposable
    {
        KnowledgeRateDTO Get(int id);
        IEnumerable<KnowledgeRateDTO> Get();
        void Create(KnowledgeRateDTO item);
        void Update(int id, KnowledgeRateDTO item);
        void Delete(int id);
        //void Dispose();
    }
}
