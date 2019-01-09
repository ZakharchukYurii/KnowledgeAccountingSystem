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
            Database.Save();
        }

        public void Update(int id, KnowledgeRateDTO item)
        {
            if(item == null)
            {
                throw new ValidationException("Item is not Valid", "");
            }

            var itemToUpdate = Database.Rates.Get(id);

            if(itemToUpdate == null)
            {
                throw new ValidationException("Rate is not found", "");
            }

            //itemToUpdate.AreaId = item.AreaId;
            //itemToUpdate.Area = Database.Areas.Get(item.AreaId);
            itemToUpdate.KnowledgeId = item.KnowledgeId;
            itemToUpdate.Knowledge = Database.Knowledges.Get(item.KnowledgeId);
            itemToUpdate.UserId = item.UserId;
            itemToUpdate.User = Database.Users.Get(item.UserId);

            Database.Rates.Update(itemToUpdate);
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
