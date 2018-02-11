using System;
using System.Collections.Generic;
using Logic.Core.Domain;
using Logic.Core.Repositories;
using System.Linq;
using System.Data.Entity;

namespace Logic.Persistence.Repositories
{
    class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(InventoryManagerEntities context) : base(context)
        {
        }

        public InventoryManagerEntities InventoryManagerEntities
        {
            get { return Context as InventoryManagerEntities; }
        }

        public IEnumerable<Sale> getSalesOf(DateTime minDate, DateTime maxDate, Product product, Store store)
        {
            var rslt = InventoryManagerEntities.Sales.Where(s => (s.date >= minDate && s.date <= maxDate));
            if(product != null)
            {
                rslt = rslt.Where(s => s.productReference == product.reference);
            }
            if(store != null)
            {
                rslt = rslt.Where(s => s.storeName == store.storeName);
            }

            return rslt.ToList();
        }
    }
}