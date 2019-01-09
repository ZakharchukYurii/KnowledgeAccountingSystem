using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
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

        public IEnumerable<UserDTO> MakeSelection(string knowledge, int rate)
        {
            return MakeSelection(new KnowledgeRateDTO() { Knowledge = new KnowledgeDTO() { Name = knowledge }, Rate = rate });
        }

        public IEnumerable<UserDTO> MakeSelection(KnowledgeRateDTO knowledgeRate)
        {
            var rates = Database.Rates.Find(
                x => x.Knowledge.Name == knowledgeRate.Knowledge.Name
                && x.Rate >= knowledgeRate.Rate);

            var users = from r in rates
                        select r.User;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
