

namespace Logic.Core.Domain
{
    public class Purchase
    {
        public Purchase()
        {

        }

        public Purchase(int id, string date, Store store, Product product, int amount)
        {
            this.id = id;
            this.date = date;
            this.Store = store;
            this.Product = product;
            this.amount = amount;
        }


        public long id { get; set; }
        public string date { get; set; }
        public long storeID { get; set; }
        public long productID { get; set; }
        public long amount { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}