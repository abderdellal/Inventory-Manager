﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Logic.Core.Domain
{
    public partial class Product : ModelBase
    {
        public Product()
        {
            this.Stocks = new HashSet<Stock>();
        }

        public Product(long id, string reference, long purchasingPrice, long sellingPrice, byte[] picture, string extraInformation)
        {
            this.Stocks = new HashSet<Stock>();

            this.id = id;
            this.reference = reference;
            this.purchasingPrice = purchasingPrice;
            this.sellingPrice = sellingPrice;
            this.picture = picture;
            this.extraInformation = extraInformation;
        }

        public long id { get; set; }

        [Required(ErrorMessage = "Reference is mandatory !")]
        public string reference { get; set; }
        [Required(ErrorMessage = "Purchase Price is mandatory !")]
        public long purchasingPrice { get; set; }
        [Required(ErrorMessage = "Selling Price is mandatory !")]
        public long sellingPrice { get; set; }

        [MaxLength]
        public byte[] picture { get; set; }
        public string extraInformation { get; set; }


        [NotMapped]
        public long StockTotal
        {
            get { return Stocks.Sum(s => s.amount); }
        }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
