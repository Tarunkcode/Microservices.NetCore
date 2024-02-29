using System;
using Catalog.Core.Entities;
using Catalog.Core.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using Catalog.Infrastructure.Data;
namespace Catalog.Infrastructure.Repository
{
    public class TypeRepository: ITypeRepository{
        private readonly ICatalogContext _context;
        public TypeRepository(ICatalogContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductType>> GetAllTypes(){
            return await _context.Types.Find(p => true).ToListAsync();
        }
    }
}