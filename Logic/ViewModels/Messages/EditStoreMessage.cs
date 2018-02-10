using Logic.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ViewModels.Messages
{
    public class EditStoreMessage
    {
        public Store store;

        public EditStoreMessage(Store s)
        {
            this.store = s;
        }
    }
}
