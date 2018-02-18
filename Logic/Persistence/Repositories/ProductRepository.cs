using Logic.Core.Domain;
using Logic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Logic.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(InventoryManagerEntities context) : base(context)
        {
        }

        public IEnumerable<Product> GetProductsWithStockPerStore()
        {
            return InventoryManagerEntities.Products.Include(p => p.Stocks.Select(st => st.Store)).ToList();
        }

        public IEnumerable<ProductSalesInfo>  GetProductsSalesInfo()
        {
            //first day of the month at 00:00:00
            DateTime minDateMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            //today at 00:00:00
            DateTime minDateDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            try
            {
                return InventoryManagerEntities.Products.Join(InventoryManagerEntities.Sales.Where(s => s.date > minDateMonth), p => p.reference, s => s.productReference, (p, s) => new { prod = new { productReference = p.reference, dayTarget = p.dailyTarget, monthTarget = p.monthlyTarget }, sale = s }).GroupBy(r => r.prod).Select(g => new ProductSalesInfo()
                {
                    productReference = g.Key.productReference,
                    DayTarget = g.Key.dayTarget,
                    MonthTarget = g.Key.monthTarget,
                    TotalSaleMonth = g.Select(r => r.sale.amount).DefaultIfEmpty(0).Sum(),
                    TotalSaleDay = g.Where(r => r.sale.date > minDateDay).Select(r => r.sale.amount).DefaultIfEmpty(0).Sum()
                }).ToList();
            }
            catch(Exception e)
            {
                return new List<ProductSalesInfo>();
            }
        }

        public void deleteProductOnCascade(Product p)
        {
            InventoryManagerEntities.Stocks.RemoveRange(p.Stocks);
            InventoryManagerEntities.Products.Remove(p);
        }

        public InventoryManagerEntities InventoryManagerEntities
        {
            get { return Context as InventoryManagerEntities; }
        }
    }
}
