using Logic.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Logic.Core.Repositories
{
    public interface IStockRepository : IRepository<Stock>
    {
        IEnumerable<Stock> GetAllStocksWithStoresAndProduct();
        IEnumerable<Stock> GetStocksWithStoresAndProductWhere(Expression<Func<Stock, bool>> predicate);
    }
}
