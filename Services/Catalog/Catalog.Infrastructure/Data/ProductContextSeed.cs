using System;
using MongoDB.Driver;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Catalog.Core.Entities;

namespace Catalog.Infrastructure.Data{
    public static class ProductContextSeed{
        public static void SeedData(IMongoCollection<Product> productCollection){
           bool checkProduct = productCollection.Find(p => true).Any();
           string path = Path.Combine("Data", "Seed", "products.json");

           if(!checkProduct){
              var productData = File.ReadAllText(path);
              var products = JsonSerializer.Deserialize<List<Product>>(productData);

              if(products != null){
                foreach(var item in products){
                    productCollection.InsertOneAsync(item);
                }
              }
           }
        }
    }
}