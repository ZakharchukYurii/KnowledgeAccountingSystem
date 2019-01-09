using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IKnowledgeService
    {
        KnowledgeDTO Get(int id);
        IEnumerable<KnowledgeDTO> Get();
        void Create(KnowledgeDTO item);
        void Update(KnowledgeDTO item);
        void Delete(int id);

        AreaDTO GetArea(int id);
        IEnumerable<AreaDTO> GetArea();
        //void CreateArea(AreaDTO item);

        void Dispose();
    }
}
