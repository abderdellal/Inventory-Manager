using Logic.Core.Domain;

namespace Logic.ViewModels.Messages
{
    public class EditStoreMessage
    {
        public Store store { get; set; }

        public EditStoreMessage(Store s)
        {
            this.store = s;
        }
    }
}
