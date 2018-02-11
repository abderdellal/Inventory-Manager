using Logic.Core.Domain;
using Logic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Logic.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(InventoryManagerEntities context) : base(context)
        {
        }

        public IEnumerable<Product> GetProductsWithStockPerStore()
        {
            return InventoryManagerEntities.Products.Include(p => p.Stocks.Select(st => st.Store)).ToList();
        }

        public void deleteProductOnCascade(Product p)
        {
            InventoryManagerEntities.Stocks.RemoveRange(p.Stocks);
            InventoryManagerEntities.Products.Remove(p);
        }

        public InventoryManagerEntities InventoryManagerEntities
        {
            get { return Context as InventoryManagerEntities; }
        }
    }
}
