using Logic.Core.Domain;
using System.Collections.Generic;

namespace Logic.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsWithStockPerStore();
        IEnumerable<ProductSalesInfo> GetProductsSalesInfo();
        void deleteProductOnCascade(Product p);
    }
    public class ProductSalesInfo
    {
        public string productReference { get; set; }
        public int? DayTarget { get; set; }
        public int? MonthTarget {get; set;}
        public int TotalSaleDay { get; set; }
        public int TotalSaleMonth { get; set; }

        public int? TargetPourcentageDay
        {
            get
            {
                if (DayTarget != null && DayTarget > 0)
                {
                    return (TotalSaleDay * 100 )/ DayTarget;
                }
                else
                    return null;
            }
        }
        public int? TargetPourcentageMonth
        {
            get
            {
                if (MonthTarget != null && MonthTarget > 0)
                {
                    return (TotalSaleMonth * 100 ) / MonthTarget;
                }
                else
                    return null;
            }
        }

    }
}
