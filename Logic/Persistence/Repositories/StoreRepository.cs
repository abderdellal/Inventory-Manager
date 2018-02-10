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
    class StoreRepository : Repository<Store>, IStoreRepository
    {
        public StoreRepository(InventoryManagerEntities context) : base(context)
        {
            
        }

        public IEnumerable<Store> GetStoresWithStockPerProduct()
        {
            return InventoryManagerEntities.Stores.Include(s => s.Stocks.Select(st => st.Product)).ToList();
        }


        public InventoryManagerEntities InventoryManagerEntities
        {
            get { return Context as InventoryManagerEntities; }
        }

        public void deleteStoreOnCascade(Store s)
        {
            InventoryManagerEntities.Purchases.RemoveRange(s.Purchases);
            InventoryManagerEntities.Sales.RemoveRange(s.Sales);
            InventoryManagerEntities.Stocks.RemoveRange(s.Stocks);
            InventoryManagerEntities.Stores.Remove(s);
        }
    }
}
