using Logic.Core.Domain;
using System;
using System.Collections.Generic;

namespace Logic.Core.Repositories
{
    public interface ISaleRepository : IRepository<Sale>
    {
        IEnumerable<Sale> getSalesOf(DateTime minDate, DateTime maxDate, Product product, Store store);
        int getTotalAmountOfSalesForTheMonth();
        int getTotalAmountOfSalesToday();
    }
}
