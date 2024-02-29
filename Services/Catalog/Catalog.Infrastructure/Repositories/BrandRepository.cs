using System;
using Catalog.Core.Entities;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Catalog.Infrastructure.Data;
using Catalog.Core.IRepositories;

namespace Catalog.Infrastructure.Repository
{
    public class BrandRepository: IBrandRepository{
        private readonly ICatalogContext _context;
        public BrandRepository(ICatalogContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductBrand>> GetAllBrands(){
            return await _context.Brands.Find(p => true).ToListAsync();
        }
    }
}