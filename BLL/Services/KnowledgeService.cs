using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.UoW;
using System.Collections.Generic;

namespace BLL.Services
{
    public class KnowledgeService : IKnowledgeService
    {
        public IKnowledgeUnitOfWork Database { get; set; }

        public KnowledgeService(string connection)
        {
            Database = new KnowledgeUoW(connection);
        }

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
            return mapper.Map<Knowledge, KnowledgeDTO>(Database.Knowledges.Get(id));
        }

        public IEnumerable<KnowledgeDTO> Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Knowledge, KnowledgeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Knowledge>, IEnumerable<KnowledgeDTO>>(Database.Knowledges.GetAll());
        }

        public void Create(KnowledgeDTO item)
        {
            if(item == null)
            {
                throw new ValidationException("Item is undefined", "");
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

            Database.Areas.Delete(id);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
