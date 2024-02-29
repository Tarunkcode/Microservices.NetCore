using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Catalog.Core.Entities;

namespace Catalog.Core.IRepositories{
    public interface IProductRepository{
        Task<IEnumerable<Product>>GetProducts();
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Product>>GetProductByName (string name );
        Task<IEnumerable<Product>>GetProductByBrand (string name );
        Task<Product> CreateProduct(Product pdt);
        Task<bool> UpdateProduct(Product pdt);
        Task<bool> DeleteProduct (string id);

    }
}