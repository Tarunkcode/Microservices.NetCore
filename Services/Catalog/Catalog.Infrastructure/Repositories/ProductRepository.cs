using System;
using Catalog.Core.IRepositories;
using Catalog.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using Catalog.Infrastructure.Data;

namespace Catalog.Infrastructure.Repository{
    public class ProductRepository : IProductRepository{
        private readonly ICatalogContext _context;
        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>>GetProducts(){
            return await _context.Products.Find(p => true).ToListAsync();
        }
        public async Task<Product> GetProduct(string id){
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Product>>GetProductByName (string name ){
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);
            return await _context.Products.Find(filter).ToListAsync();
        }
        public async Task<IEnumerable<Product>>GetProductByBrand (string name ){
             FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Brands.Name, name);
            return await _context.Products.Find(filter).ToListAsync();
        }
        public async Task<Product> CreateProduct(Product pdt){
           await _context.Products.InsertOneAsync(pdt);
           return pdt;
        }
        public async Task<bool> UpdateProduct(Product pdt){
            ReplaceOneResult updatedResult = await this._context.Products.ReplaceOneAsync(x => x.Id == pdt.Id, pdt);
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0 ? true : false;
            // return true;
        }
        public async Task<bool> DeleteProduct (string id){
           FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id ,id);
            DeleteResult result = await this._context.Products.DeleteOneAsync(filter);
           return result.IsAcknowledged && result.DeletedCount > 0 ;
        }
    }
}