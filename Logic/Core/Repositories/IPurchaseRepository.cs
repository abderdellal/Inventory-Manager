using System;
using System.Collections.Generic;
using Logic.Core.Domain;

namespace Logic.Core.Repositories
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        IEnumerable<Purchase> getPurchasesOf(DateTime minDate, DateTime maxDate, Product product, Store store);
    }
}
