using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using MongoDB.Driver;
using Catalog.Core.Entities;
namespace Catalog.Infrastructure.Data
{
    public static class TypeContextSeed
    {
        public static void SeedData(IMongoCollection<ProductType> typeCollection)
        {
            bool checkType = typeCollection.Find(p => true).Any();
            string path = Path.Combine("Data", "SeedData", "types.json");
            if (!checkType)
            {
                var typeData = File.ReadAllText(path);
                var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                if(types != null){
                    foreach(ProductType item in types){
                        typeCollection.InsertOneAsync(item);
                    }
                }
            }
        }
    }
}