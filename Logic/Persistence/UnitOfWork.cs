using Logic.Core;
using Logic.Core.Repositories;
using Logic.Persistence.Repositories;
using System.Data.Entity;
using System;
using System.Linq;

namespace Logic.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryManagerEntities _context;

        public UnitOfWork(InventoryManagerEntities context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Stores = new StoreRepository(_context);
            Sales = new SaleRepository(_context);
            Purchases = new PurchaseRepository(_context);
            Stocks = new StockRepository(_context);
        }

        public IProductRepository Products { get; private set; }
        public IStoreRepository Stores { get; private set; }
        public ISaleRepository Sales { get; private set; }
        public IPurchaseRepository Purchases { get; private set; }
        public IStockRepository Stocks { get; private set; }

        

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public bool hasPendingChanges()
        {
            try
            {
                return _context.ChangeTracker.Entries().Any(e => e.State == EntityState.Added
                                                          || e.State == EntityState.Modified
                                                          || e.State == EntityState.Deleted);
            }
            catch (System.InvalidOperationException)
            {
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        ///// <summary>
        ///// update a single entity with a new dbContext ignoring the change to the rest of the data.
        ///// </summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entity"></param>
        //public void UpdateSingleWithNewContext<TEntity>(TEntity entity) where TEntity : class
        //{
        //    using (var ctx = new InventoryManagerEntities())
        //    {
        //        var dbset = ctx.Set<TEntity>();
        //        dbset.Attach(entity);
        //        ctx.Entry(entity).State = EntityState.Modified;
        //        ctx.SaveChanges();
        //    }
        //}

        ///// <summary>
        ///// delete an entity from the database and save with a new dbcontext ignoring the change to the rest of the data.
        ///// </summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entity"></param>
        //public void DeleteSingleWithNewContext<TEntity>(TEntity entity) where TEntity : class
        //{
        //    //using (var ctx = new InventoryManagerEntities())
        //    //{
        //    //    var dbset = ctx.Set<TEntity>();
        //    //    dbset.Remove(entity);
        //    //    ctx.SaveChanges();
        //    //}
        //}
    }
}