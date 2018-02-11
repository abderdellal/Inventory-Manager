using Logic.Core.Domain;

namespace Logic.ViewModels.Messages
{
    public class DisplayProductDetailMessage
    {
        public Product product { get; set; }
        public DisplayProductDetailMessage(Product p)
        {
            this.product = p;
        }
    }
}
