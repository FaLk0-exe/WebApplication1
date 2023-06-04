using Pharm.DAL.entity;

namespace WebApplication1.VM
{
    public class ProductVM
    {

        public string Pname { get; set; } = null!;

        public string Description { get; set; } = null!;

        public double Price { get; set; }

        public long Quantity { get; set; }

        public Product CreateProduct()
        {
            return new Product
            {
                Pname = Pname,
                Description = Description,
                Price = Price,
                Quantity = Quantity
            };
        }

    }
}
