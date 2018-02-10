using Logic.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ViewModels.Messages
{
    class StoreAddedMessage
    {
        public Store store;
        public StoreAddedMessage(Store str)
        {
            this.store = str;
        }
    }
}
