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
            var result = mapper.Map<KnowledgeRate, KnowledgeRateDTO>(Database.Rates.Get(id));

            result.Knowledge = Database.Knowledges.Get(result.KnowledgeId).Name;
            result.User = Database.Users.Get(result.UserId).Name;

            return result;
        }

        public IEnumerable<KnowledgeRateDTO> Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeRate, KnowledgeRateDTO>()).CreateMapper();
            var result = mapper.Map<IEnumerable<KnowledgeRate>, IEnumerable<KnowledgeRateDTO>>(Database.Rates.GetAll());

            foreach(var rate in result)
            {
                rate.Knowledge = Database.Knowledges.Get(rate.KnowledgeId).Name;
                rate.User = Database.Users.Get(rate.UserId).Name;
            }

            return result;
        }

        public IEnumerable<KnowledgeRateDTO> GetByUser(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<KnowledgeRate, KnowledgeRateDTO>()).CreateMapper();
            var result = mapper.Map<IEnumerable<KnowledgeRate>, IEnumerable<KnowledgeRateDTO>>(
                Database.Rates.Find(x => x.UserId == id));

            foreach(var rate in result)
            {
                rate.Knowledge = Database.Knowledges.Get(rate.KnowledgeId).Name;
                rate.User = Database.Users.Get(rate.UserId).Name;
            }

            return result;
        }

        public void Create(KnowledgeRateDTO item)
        {
            if(item == null)
            {
                throw new ValidationException("Item is not Valid", "");
            }

            var sameItemFromDb = Database.Rates.Find(
                x => x.UserId == item.UserId &&
                x.KnowledgeId == item.KnowledgeId).FirstOrDefault();

            if(sameItemFromDb != null)
            {
                throw new ValidationException("The same item is already exist", "");
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

            itemToUpdate.Rate = item.Rate;
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

            Database.Rates.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
