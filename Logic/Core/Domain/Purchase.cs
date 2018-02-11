
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic.Core.Domain
{
    public class Purchase : ModelBase
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
        private long _unitPrice;
        [Required]
        public long unitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                _unitPrice = value;
                NotifyPropertyChanged("totalPrice");
            }
        }

        private int _amount;
        [Required]
        public int amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                NotifyPropertyChanged("totalPrice");
            }
        }

        [NotMapped]
        public long totalPrice
        {
            get
            {
                return amount * unitPrice;
            }
        }
    }
}