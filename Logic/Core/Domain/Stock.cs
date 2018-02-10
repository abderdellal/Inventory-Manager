

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic.Core.Domain
{
    public class Stock : ModelBase
    {
        public Stock()
        {
        }

        public Stock(long amount, Product product, Store store)
        {
            this.amount = amount;
            Product = product;
            Store = store;
        }

        [Key]
        [Column(Order = 1)]
        public long storeID { get; set; }
        [Key]
        [Column(Order = 2)]
        public long productID { get; set; }

        public long amount { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
