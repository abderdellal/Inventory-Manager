using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Logic.ValidationAttributes;

namespace Logic.Core.Domain
{
    public class Store : ModelBase
    {
        public Store()
        {
            this.Stocks = new HashSet<Stock>();
        }

        public Store(long id, string firstName, string lastName, string storeName, string phoneNumber, byte[] picture, string extraInformation)
        {
            this.Stocks = new HashSet<Stock>();

            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.storeName = storeName;
            this.phoneNumber = phoneNumber;
            this.picture = picture;
            this.extraInformation = extraInformation;
        }

        public long id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        [Required(ErrorMessage = "Store name is mandatory !")]
        public string storeName { get; set; }
        [MyPhone(ErrorMessage = "phone number isn't valid!")]
        public string phoneNumber { get; set; }

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
