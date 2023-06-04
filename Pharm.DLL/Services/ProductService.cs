using Pharm.DLL.Interfaces;
using Pharm.DAL.entity;

namespace Pharm.DLL.Services
{
    public class ProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            
            _productRepository = productRepository;
        }

        public void Validate(Product product)
        {
            double price = product.Price;
            string pname = product.Pname;
            string description = product.Description;

            if (product is null || string.IsNullOrEmpty(pname) || string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Product or description is null");
            }

            if (price <= 0)
            {
                throw new ArgumentException("Price cannot be 0 or less than it");
            }

            if (description.Length > 256 || pname.Length > 32)
            {
                throw new ArgumentException("Description or name is too large");
            }
        }

        public void CreateProduct(Product product)
        {
            try
            {
                Validate(product);
            }
            catch
            {
                throw;
            }
            _productRepository.CreateProduct(product);
        }

        public void EditProduct(Product product)
        {
            try
            {
                Validate(product);
            }
            catch
            {
                throw;
            }
            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(long id)
        {
            var product = _productRepository.GetProduct(id);
            if (product == null)
            {
                throw new InvalidOperationException($"Product {id} id not found");
            }
            _productRepository.DeleteProduct(id);
        }


    }
}
