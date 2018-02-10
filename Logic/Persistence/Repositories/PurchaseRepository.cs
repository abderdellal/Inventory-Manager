using Logic.Core.Domain;
using Logic.Core.Repositories;

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
    }
}