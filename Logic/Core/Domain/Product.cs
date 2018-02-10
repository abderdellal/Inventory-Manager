using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Logic.Core.Domain
{
    public partial class Product
    {
        public Product()
        {
            this.Purchases = new HashSet<Purchase>();
            this.Stocks = new HashSet<Stock>();
            this.Sales = new HashSet<Sale>();
        }

        public Product(long id, string reference, long purchasingPrice, long sellingPrice, byte[] picture, string extraInformation)
        {
            this.Purchases = new HashSet<Purchase>();
            this.Stocks = new HashSet<Stock>();
            this.Sales = new HashSet<Sale>();

            this.id = id;
            this.reference = reference;
            this.purchasingPrice = purchasingPrice;
            this.sellingPrice = sellingPrice;
            this.picture = picture;
            this.extraInformation = extraInformation;
        }

        public long id { get; set; }
        public string reference { get; set; }
        public long purchasingPrice { get; set; }
        public long sellingPrice { get; set; }

        [MaxLength]
        public byte[] picture { get; set; }
        public string extraInformation { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
