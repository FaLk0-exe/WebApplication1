using System.Collections.Generic;

namespace Pharm.DLL.Repositories
{
    public interface IStatusRepository
    {
        void CreateStatus(StatusRep.OrderStatus orderStatus);

        void UpdateStatus(StatusRep.OrderStatus orderStatus);

        void DeleteStatus(long id);

        StatusRep.OrderStatus GetStatus(long id);
    }
}