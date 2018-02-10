using Logic.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Core.Repositories
{
    public interface IStoreRepository : IRepository<Store>
    {
        IEnumerable<Store> GetStoresWithStockPerProduct();
        void deleteStoreOnCascade(Store s);
    }
}
