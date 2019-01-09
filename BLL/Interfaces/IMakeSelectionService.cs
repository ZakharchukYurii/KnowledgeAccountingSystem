using BLL.DTO;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IMakeSelectionService : IDisposable
    {
        UserDTO GetUser(int id);
        IEnumerable<UserDTO> GetUser();

        AreaDTO GetArea(int id);
        IEnumerable<AreaDTO> GetArea();

        KnowledgeDTO GetKnowledge(int id);
        IEnumerable<KnowledgeDTO> GetKnowledge();

        KnowledgeRateDTO GetRate(int id);
        IEnumerable<KnowledgeRateDTO> GetRate();

        IEnumerable<SelectionDTO> MakeSelection(SelectionDTO selection);

        //void Dispose();
    }
}
