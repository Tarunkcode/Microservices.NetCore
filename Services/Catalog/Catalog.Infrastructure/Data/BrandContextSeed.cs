using System;
using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;
using System.IO;
using System.Collections.Generic;
namespace Catalog.Infrastructure.Data
{
    public static class BrandContextSeed
    {
        public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
        {
            bool checkBrands = brandCollection.Find(b => true).Any();

            string path = Path.Combine("Data", "SeedData", "brands.json");
            if (!checkBrands)
            {
                var brandsData = File.ReadAllText(path);
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands != null)
                {
                    foreach (ProductBrand item in brands)
                    {
                        brandCollection.InsertOneAsync(item);
                    }
                }
            }

        }
    }
}