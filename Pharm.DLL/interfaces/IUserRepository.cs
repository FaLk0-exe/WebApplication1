using System.Collections.Generic;
using Pharm.DLL.Repositories;

namespace Pharm.DLL.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(UserRep.User user);

        void UpdateUser(UserRep.User user);

        void DeleteUser(long id);

        UserRep.User GetUserById(long id);

        List<UserRep.User> GetAllUsers();
    }
}
