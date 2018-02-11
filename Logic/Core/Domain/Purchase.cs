

using System;
using System.ComponentModel.DataAnnotations;

namespace Logic.Core.Domain
{
    public class Purchase
    {
        public Purchase()
        {

        }

        public Purchase(int id, string DateTime, string storeName, string productReference, int amount, long unitPrice)
        {
            this.id = id;
            this.date = date;
            this.amount = amount;
            this.storeName = storeName;
            this.productReference = productReference;
            this.unitPrice = unitPrice;

        }

        public long id { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public string storeName { get; set; }
        [Required]
        public string productReference { get; set; }
        [Required]
        public long unitPrice { get; set; }
        [Required]
        public int amount { get; set; }
    }
}