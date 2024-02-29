using System;
using Catalog.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Core.IRepositories
{
    public interface IBrandRepository{
        Task<IEnumerable<ProductBrand>> GetAllBrands();
    }
}