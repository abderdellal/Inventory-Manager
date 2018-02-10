using Logic.Core.Domain;
using Logic.Core.Repositories;

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
    }
}
