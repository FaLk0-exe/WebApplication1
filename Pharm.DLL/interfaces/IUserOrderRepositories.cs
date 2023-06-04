using System.Collections.Generic;
using Pharm.DAL.entity;
using Pharm.DLL.Repositories;

namespace Pharm.DLL.Interfaces
{
    public interface IUserOrderRepository
    {
        void CreateUserOrder(UserOrder userOrder);

        void UpdateUserOrder(UserOrder userOrder);

        void DeleteUserOrder(long id);

        UserOrder GetUserOrder(long id);

        List<UserOrder> GetAllUserOrders();
    }

}