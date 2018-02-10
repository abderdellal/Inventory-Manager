using System.Data.Entity;
using Logic.Migrations;
using System.Data.Entity.Infrastructure;
using Logic.Core.Domain;

namespace Logic.Persistence
{
    public class InventoryManagerEntities : DbContext
    {
        public InventoryManagerEntities()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InventoryManagerEntities, Configuration>());
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
    }
}
