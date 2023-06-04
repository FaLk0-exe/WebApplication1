using System.Collections.Generic;
using Pharm.DAL.entity;
using Pharm.DLL.Repositories;

namespace Pharm.DLL.Interfaces
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(long id);

        Product GetProduct(long id);

        List<Product> GetAllProducts();
        List<Product> GetList();
    }
}