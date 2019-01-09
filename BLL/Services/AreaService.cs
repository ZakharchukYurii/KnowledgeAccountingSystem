using System.Collections.Generic;
using DAL.Entities;
using DAL.Interfaces;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure;
using AutoMapper;

namespace BLL.Services
{
    public class AreaService : IAreaService
    {
        public IKnowledgeUnitOfWork Database { get; set; }

        public AreaService(IKnowledgeUnitOfWork uow)
        {
            Database = uow;
        }

        public AreaDTO Get(int id)
        {
            if(id < 1)
            {
                throw new ValidationException("Id is not Valid", "Id");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Area, AreaDTO>()).CreateMapper();
            return mapper.Map<Area, AreaDTO>(Database.Areas.Get(id));
        }

        public IEnumerable<AreaDTO> Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Area, AreaDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Area>, IEnumerable<AreaDTO>>(Database.Areas.GetAll());
        }

        public void Create(AreaDTO item)
        {
            if(item == null)
            {
                throw new ValidationException("Item is not Valid", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaDTO, Area>()).CreateMapper();
            var area = mapper.Map<AreaDTO, Area>(item);
            Database.Areas.Create(area);
        }

        public void Update(AreaDTO item)
        {
            if(item == null)
            {
                throw new ValidationException("Item is not Valid", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AreaDTO, Area>()).CreateMapper();
            var area = mapper.Map<AreaDTO, Area>(item);
            Database.Areas.Update(area);
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
