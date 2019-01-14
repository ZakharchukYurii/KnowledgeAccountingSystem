using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class MakeSelectionService : IMakeSelectionService
    {
        public IKnowledgeUnitOfWork Database { get; set; }

        public MakeSelectionService(IKnowledgeUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<KnowledgeRateDTO> MakeSelection(SelectionRequestDTO selection)
        {
            var knowledgeId = Database.Knowledges.Find(x => x.Name == selection.Knowledge).FirstOrDefault().Id;

            var rates = Database.Rates.Find(x =>
                x.KnowledgeId == knowledgeId &&
                x.Rate >= selection.Rate);

            var result = from r in rates
                         select new KnowledgeRateDTO()
                         {
                             Id = r.Id,
                             UserId = r.UserId,
                             User = r.User.Name,
                             KnowledgeId = r.KnowledgeId,
                             Knowledge = r.Knowledge.Name,
                             Rate = r.Rate
                         };

            return result;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
