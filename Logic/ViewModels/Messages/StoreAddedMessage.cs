using Logic.Core.Domain;

namespace Logic.ViewModels.Messages
{
    public class StoreAddedMessage
    {
        public Store store { get; set; }
        public StoreAddedMessage(Store str)
        {
            store = str;
        }
    }
}
