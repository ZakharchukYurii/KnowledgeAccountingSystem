using BLL.DTO;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        UserDTO Get(int id);
        IEnumerable<UserDTO> Get();
        void Create(UserDTO item);
        void Update(int id, UserDTO item);
        void Delete(int id);
        //void Dispose();
    }
}
