using BLL.DTO;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IKnowledgeService : IDisposable
    {
        KnowledgeDTO Get(int id);
        IEnumerable<KnowledgeDTO> Get();
        void Create(KnowledgeDTO item);
        void Update(int id, KnowledgeDTO item);
        void Delete(int id);
        //void Dispose();
    }
}
