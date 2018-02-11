using Logic.Core.Domain;

namespace Logic.ViewModels.Messages
{
    public class EditProductMessage
    {
        public Product product { get; set; }
        public EditProductMessage(Product p)
        {
            product = p;
        }
    }
}
