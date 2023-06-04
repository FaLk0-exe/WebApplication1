using System.Collections.Generic;
using Pharm.DAL.entity;
using Pharm.DLL.Repositories;

namespace Pharm.DLL.Interfaces
{
    public interface IOrderDetailsRepository
    {
        void CreateOrderDetails(OrderDetail orderDetail);

        void UpdateOrderDetails(OrderDetail orderDetail);

        void DeleteOrderDetails(long id);

        OrderDetail GetOrderDetails(long id);

        List<OrderDetail> GetAllOrderDetails();
    }

}