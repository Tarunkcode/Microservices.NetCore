using System;
using MongoDB.Driver;
using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace Catalog.Infrastructure.Data{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products {get;}
        public IMongoCollection<ProductBrand> Brands {get;}

        public IMongoCollection<ProductType> Types {get;}

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Brands = database.GetCollection<ProductBrand>(configuration.GetValue<string>("DatabaseSettings:ProductBrands"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:Product"));
            Types = database.GetCollection<ProductType>(configuration.GetValue<string>("DatabaseSettings:ProductTypes"));
            BrandContextSeed.SeedData(Brands);
            TypeContextSeed.SeedData(Types);
            ProductContextSeed.SeedData(Products);
        }
        
    }
}