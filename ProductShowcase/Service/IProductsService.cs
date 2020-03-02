using ProductShowcase.Entities;
using System.Collections.Generic;

namespace ProductShowcase.Service
{
    public interface IProductsService
    {
        IEnumerable<IProduct> GetAllProducts(CastingScheme scheme);
    }
}