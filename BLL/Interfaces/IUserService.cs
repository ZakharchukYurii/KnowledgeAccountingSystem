using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        UserDTO Get(int id);
        IEnumerable<UserDTO> Get();
        void Create(UserDTO item);
        void Update(UserDTO item);
        void Delete(int id);
        void Dispose();
    }
}
