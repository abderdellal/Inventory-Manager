using System;
using System.Collections.Generic;
using Logic.Core.Domain;
using Logic.Core.Repositories;
using System.Linq;

namespace Logic.Persistence.Repositories
{
    class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(InventoryManagerEntities context) : base(context)
        {
        }

        public InventoryManagerEntities InventoryManagerEntities
        {
            get { return Context as InventoryManagerEntities; }
        }

        public IEnumerable<Purchase> getPurchasesOf(DateTime minDate, DateTime maxDate, Product product, Store store)
        {
            var rslt = InventoryManagerEntities.Purchases.Where(s => (s.date >= minDate && s.date <= maxDate));
            if (product != null)
            {
                rslt = rslt.Where(s => s.productReference == product.reference);
            }
            if (store != null)
            {
                rslt = rslt.Where(s => s.storeName == store.storeName);
            }

            return rslt.ToList();
        }
    }
}