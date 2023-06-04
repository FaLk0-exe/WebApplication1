using System.Collections.Generic;
using Pharm.DAL.entity;
using Pharm.DLL.Repositories;

namespace Pharm.DLL.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);

        void UpdateUser(User user);

        void DeleteUser(long id);

        User GetUserById(long id);

        List<User> GetAllUsers();
    }
}
