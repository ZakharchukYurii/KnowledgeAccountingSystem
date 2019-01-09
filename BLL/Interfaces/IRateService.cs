using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IRateService
    {
        KnowledgeRateDTO Get(int id);
        IEnumerable<KnowledgeRateDTO> Get();
        void Create(KnowledgeRateDTO item);
        void Update(KnowledgeRateDTO item);
        void Delete(int id);
        void Dispose();
    }
}
