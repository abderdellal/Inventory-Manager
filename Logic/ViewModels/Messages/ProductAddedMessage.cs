using Logic.Core.Domain;


namespace Logic.ViewModels.Messages
{
    public class ProductAddedMessage
    {
        public Product product { get; set; }
        public ProductAddedMessage(Product p)
        {
            product = p;
        }
    }
}
