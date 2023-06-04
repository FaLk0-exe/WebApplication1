using System.Collections.Generic;
using Pharm.DLL.Repositories;

namespace Pharm.DLL.Interfaces
{
    public interface IOrderDetailsRepository
    {
        void CreateOrderDetails(OrderDetailsRep.OrderDetail orderDetail);

        void UpdateOrderDetails(OrderDetailsRep.OrderDetail orderDetail);

        void DeleteOrderDetails(long id);

        OrderDetailsRep.OrderDetail GetOrderDetails(long id);

        List<OrderDetailsRep.OrderDetail> GetAllOrderDetails();
    }

}