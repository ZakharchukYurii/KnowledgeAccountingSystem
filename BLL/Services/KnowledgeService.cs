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
    public class KnowledgeService : IKnowledgeService
    {
        public IKnowledgeUnitOfWork Database { get; set; }

        public KnowledgeService(IKnowledgeUnitOfWork uow)
        {
            Database = uow;
        }

        public KnowledgeDTO Get(int id)
        {
            if(id < 1)
            {
                throw new ValidationException("Id is not Valid", "Id");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Knowledge, KnowledgeDTO>()).CreateMapper();
            var result = mapper.Map<Knowledge, KnowledgeDTO>(Database.Knowledges.Get(id));

            result.Area = Database.Areas.Get(result.AreaId).Name;

            return result;
        }

        public IEnumerable<KnowledgeDTO> Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Knowledge, KnowledgeDTO>()).CreateMapper();
            var result = mapper.Map<IEnumerable<Knowledge>, IEnumerable<KnowledgeDTO>>(Database.Knowledges.GetAll());

            foreach(var knowledge in result)
            {
                knowledge.Area = Database.Areas.Get(knowledge.AreaId).Name;
            }

            return result;
        }

        public void Create(KnowledgeDTO item)
        {
            if(item == null)
            {
                throw new ValidationException("Item is undefined", "");
            }

            var sameItemFromDb = Database.Knowledges.Find(
                x => x.Name == item.Name &&
                x.AreaId == item.AreaId).FirstOrDefault();

            if(sameItemFromDb != null)
            {
                throw new ValidationException("The same item is already exist", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeDTO, Knowledge>()).CreateMapper();
            var knowledge = mapper.Map<KnowledgeDTO, Knowledge>(item);

            Database.Knowledges.Create(knowledge);
            Database.Save();
        }

        public void Update(int id, KnowledgeDTO item)
        {
            if(item == null)
            {
                throw new ValidationException("Item is undefined", "");
            }

            var itemToUpdate = Database.Knowledges.Get(id);

            if(itemToUpdate == null)
            {
                throw new ValidationException("Knowledge is not found", "");
            }

            itemToUpdate.Name = item.Name;
            itemToUpdate.AreaId = item.AreaId;
            itemToUpdate.Area = Database.Areas.Get(item.AreaId);

            Database.Knowledges.Update(itemToUpdate);
            Database.Save();
        }

        public void Delete(int id)
        {
            if(id < 1)
            {
                throw new ValidationException("Id is not valid", "Id");
            }

            Database.Knowledges.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
