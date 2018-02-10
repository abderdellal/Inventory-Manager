using System;
using Logic.Core.Repositories;

namespace Logic.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IStoreRepository Stores { get; }
        ISaleRepository Sales { get; }
        IPurchaseRepository Purchases { get; }
        IStockRepository Stocks { get; }

        ///// <summary>
        ///// update a single entity with a new dbContext ignoring the change to the rest of the data.
        ///// </summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entity"></param>
        //void UpdateSingleWithNewContext<TEntity>(TEntity entity) where TEntity : class;

        ///// <summary>
        ///// delete an entity from the database and save with a new dbcontext ignoring the change to the rest of the data.
        ///// </summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entity"></param>
        //void DeleteSingleWithNewContext<TEntity>(TEntity entity) where TEntity : class;

        int Complete();
    }
}