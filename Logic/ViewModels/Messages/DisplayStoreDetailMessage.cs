using Logic.Core.Domain;

namespace Logic.ViewModels.Messages
{
    public class DisplayStoreDetailMessage
    {
        public Store store { get; set; }

        public DisplayStoreDetailMessage(Store s)
        {
            this.store = s;
        }
    }
}
