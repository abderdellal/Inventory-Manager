using Logic.Core.Repositories;
using Logic.Core.Domain;
using System.Data.Entity;
using System;
using System.Collections.Generic;

namespace Logic.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(InventoryManagerEntities context) : base(context)
        {
        }

        public IEnumerable<Product> GetProductsWithStockPerStore()
        {
            throw new NotImplementedException();
        }

        public InventoryManagerEntities InventoryManagerEntities
        {
            get { return Context as InventoryManagerEntities; }
        }
    }
}
