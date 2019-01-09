using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;

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
                throw new ValidationException("Item is not Valid", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeDTO, Knowledge>()).CreateMapper();
            var knowledge = mapper.Map<KnowledgeDTO, Knowledge>(item);
            Database.Knowledges.Create(knowledge);
        }

        public void Update(KnowledgeDTO item)
        {
            if(item == null)
            {
                throw new ValidationException("Item is not Valid", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeDTO, Knowledge>()).CreateMapper();
            var knowledge = mapper.Map<KnowledgeDTO, Knowledge>(item);
            Database.Knowledges.Update(knowledge);
        }

        public void Delete(int id)
        {
            if(id < 1)
            {
                throw new ValidationException("Id is not valid", "Id");
            }

            Database.Areas.Delete(id);
        }

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

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
