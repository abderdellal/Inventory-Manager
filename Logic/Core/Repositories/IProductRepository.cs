using Logic.Core.Domain;
using System.Collections.Generic;

namespace Logic.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsWithStockPerStore();
        void deleteProductOnCascade(Product p);
    }
}
