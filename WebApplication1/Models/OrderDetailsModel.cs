using Pharm.DAL.entity;

namespace WebApplication1.Models
{
    public class OrderDetailsModel
    {
        public List<OrderDetail> Items { get; set; }
        public UserOrder UserOrder { get; set; }
        public List<Product> Products { get; set; }
    }
}
