using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
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

        #region Get Methods
        public AreaDTO GetArea(int id)
        {
            if(id < 1)
            {
                throw new ValidationException("Id is not Valid", "Id");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Area, AreaDTO>()).CreateMapper();
            return mapper.Map<Area, AreaDTO>(Database.Areas.Get(id));
        }

        public IEnumerable<AreaDTO> GetArea()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Area, AreaDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Area>, IEnumerable<AreaDTO>>(Database.Areas.GetAll());
        }

        public KnowledgeDTO GetKnowledge(int id)
        {
            if(id < 1)
            {
                throw new ValidationException("Id is not Valid", "Id");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Knowledge, KnowledgeDTO>()).CreateMapper();
            return mapper.Map<Knowledge, KnowledgeDTO>(Database.Knowledges.Get(id));
        }

        public IEnumerable<KnowledgeDTO> GetKnowledge()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Knowledge, KnowledgeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Knowledge>, IEnumerable<KnowledgeDTO>>(Database.Knowledges.GetAll());
        }

        public KnowledgeRateDTO GetRate(int id)
        {
            if(id < 1)
            {
                throw new ValidationException("Id is not Valid", "Id");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeRate, KnowledgeRateDTO>()).CreateMapper();
            return mapper.Map<KnowledgeRate, KnowledgeRateDTO>(Database.Rates.Get(id));
        }

        public IEnumerable<KnowledgeRateDTO> GetRate()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeRate, KnowledgeRateDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<KnowledgeRate>, IEnumerable<KnowledgeRateDTO>>(Database.Rates.GetAll());
        }

        public UserDTO GetUser(int id)
        {
            if(id < 1)
            {
                throw new ValidationException("Id is not Valid", "Id");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(Database.Users.Get(id));
        }

        public IEnumerable<UserDTO> GetUser()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(Database.Users.GetAll());
        }
        #endregion

        public IEnumerable<SelectionDTO> MakeSelection(SelectionDTO selection)
        {
            var knowledgeId = Database.Knowledges.Find(x => x.Name == selection.Knowledge).FirstOrDefault().Id;

            var rates = Database.Rates.Find(x =>
                x.KnowledgeId == knowledgeId &&
                x.Rate >= selection.Rate);

            var result = from r in rates
                         select new SelectionDTO()
                         {
                             User = r.User.Name,
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
