﻿using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        public IKnowledgeUnitOfWork Database { get; set; }

        public UserService(IKnowledgeUnitOfWork uow)
        {
            Database = uow;
        }

        public UserDTO Get(int id)
        {
            if(id < 1)
            {
                throw new ValidationException("Id is not Valid", "Id");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(Database.Users.Get(id));
        }

        public IEnumerable<UserDTO> Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(Database.Users.GetAll());
        }

        public void Create(UserDTO item)
        {
            if(item == null)
            {
                throw new ValidationException("Item is not Valid", "");
            }

            var sameItemFromDb = Database.Users.Find(x => x.Name == item.Name).FirstOrDefault();

            if(sameItemFromDb != null)
            {
                throw new ValidationException("The same user is already exist", "");
            }

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
            var user = mapper.Map<UserDTO, User>(item);

            Database.Users.Create(user);
            Database.Save();
        }

        public void Update(int id, UserDTO item)
        {
            if(item == null)
            {
                throw new ValidationException("Item is not Valid", "");
            }

            var itemToUpdate = Database.Users.Get(id);

            if(itemToUpdate == null)
            {
                throw new ValidationException("User is not found", "");
            }

            itemToUpdate.Name = item.Name;
            itemToUpdate.FullName = item.FullName;
            itemToUpdate.EMail = item.EMail;
            itemToUpdate.Password = item.Password;

            Database.Users.Update(itemToUpdate);
            Database.Save();
        }

        public void Delete(int id)
        {
            if(id < 1)
            {
                throw new ValidationException("Id is not valid", "Id");
            }

            Database.Users.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
