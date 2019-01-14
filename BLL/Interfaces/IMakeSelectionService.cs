using BLL.DTO;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IMakeSelectionService : IDisposable
    {
        IEnumerable<KnowledgeRateDTO> MakeSelection(SelectionRequestDTO selection);
    }
}
