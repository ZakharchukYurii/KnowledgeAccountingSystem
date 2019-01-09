using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class RateService : IRateService
    {
        public IKnowledgeUnitOfWork Database { get; set; }

        public RateService(IKnowledgeUnitOfWork uow)
        {
            Database = uow;
        }

        public KnowledgeRateDTO Get(int id)
        {
            if(id < 1)
            {
                throw new ValidationException("Id is not Valid", "Id");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeRate, KnowledgeRateDTO>()).CreateMapper();
            return mapper.Map<KnowledgeRate, KnowledgeRateDTO>(Database.Rates.Get(id));
        }

        public IEnumerable<KnowledgeRateDTO> Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeRate, KnowledgeRateDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<KnowledgeRate>, IEnumerable<KnowledgeRateDTO>>(Database.Rates.GetAll());
        }

        public void Create(KnowledgeRateDTO item)
        {
            if(item == null)
            {
                throw new ValidationException("Item is not Valid", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeRateDTO, KnowledgeRate>()).CreateMapper();
            var rate = mapper.Map<KnowledgeRateDTO, KnowledgeRate>(item);
            Database.Rates.Create(rate);
        }

        public void Update(KnowledgeRateDTO item)
        {
            if(item == null)
            {
                throw new ValidationException("Item is not Valid", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeRateDTO, KnowledgeRate>()).CreateMapper();
            var rate = mapper.Map<KnowledgeRateDTO, KnowledgeRate>(item);
            Database.Rates.Update(rate);
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
