using System.Collections.Generic;
using Pharm.DLL.Repositories;

namespace Pharm.DLL.Interfaces
{
    public interface IUserOrderRepository
    {
        void CreateUserOrder(UserOrderRep.UserOrder userOrder);

        void UpdateUserOrder(UserOrderRep.UserOrder userOrder);

        void DeleteUserOrder(long id);

        UserOrderRep.UserOrder GetUserOrder(long id);

        List<UserOrderRep.UserOrder> GetAllUserOrders();
    }

}