using Logic.Core.Domain;
using Logic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Logic.Persistence.Repositories
{
    class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(InventoryManagerEntities context) : base(context)
        {
        }
        
        public InventoryManagerEntities InventoryManagerEntities
        {
            get { return Context as InventoryManagerEntities; }
        }

        public IEnumerable<Stock> GetAllStocksWithStoresAndProduct()
        {
            return InventoryManagerEntities.Stocks.Include(stk => stk.Product).Include(stk => stk.Store).ToList();
        }
        public IEnumerable<Stock> GetStocksWithStoresAndProductWhere(Expression<Func<Stock, bool>> predicate)
        {
            return  InventoryManagerEntities.Stocks.Include(stk => stk.Product).Include(stk => stk.Store).Where(predicate).ToList();
        }
    }
}
