using Logic.Core.Domain;
using Logic.Core.Repositories;

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
    }
}