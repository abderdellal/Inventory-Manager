using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic.Core;
using Logic.Core.Domain;

namespace Logic.ViewModels
{

    /// <summary>
    /// View model for editing a store or adding a new one
    /// </summary>
    public class EditStoreViewModel : ViewModelBase
    {


        private IUnitOfWork _context;

        public RelayCommand SaveStoreCommand { get; set; }

        //the store that is displayed on the form
        public Store FormStore { get; set; }

        private Store _store;
        //this is set from outside the class to specify the store we're editing
        //if this is null then we are adding a new store
        public Store storeToEdit
        {
            get
            {
                return _store;
            }
            set
            {
                _store = value;
                FormStore.storeName = value.storeName;
                FormStore.picture = value.picture;
                FormStore.firstName = value.firstName;
                FormStore.lastName = value.lastName;
                FormStore.phoneNumber = value.phoneNumber;
                FormStore.extraInformation = value.extraInformation;
            }
        }


        public EditStoreViewModel(IUnitOfWork ctx)
        {
            FormStore = new Store();
            _context = ctx;
            SaveStoreCommand = new RelayCommand(saveStore, CanSaveStore);
            FormStore.PropertyChanged += (s, e) => SaveStoreCommand.RaiseCanExecuteChanged();
        }

        public void saveStore()
        {
            if (CanSaveStore())
            {
                //if the store to edit is null then we are adding a new store
                if (storeToEdit == null)
                {
                    _store = new Store();
                    MessengerInstance.Send(new Messages.StoreAddedMessage(_store));
                    _context.Stores.Add(storeToEdit);
                }
                 
                storeToEdit.storeName = FormStore.storeName;
                storeToEdit.picture = FormStore.picture;
                storeToEdit.firstName = FormStore.firstName;
                storeToEdit.lastName = FormStore.lastName;
                storeToEdit.phoneNumber = FormStore.phoneNumber;
                storeToEdit.extraInformation = FormStore.extraInformation;

                _context.Complete();
                _store = null;
                resetForm();
            }
        }

        public bool CanSaveStore()
        {
            if (FormStore != null)
                return FormStore.IsValid();
            else
                return false;
        }

        public void resetForm()
        {
            FormStore.storeName = "";
            FormStore.picture = null;
            FormStore.firstName = "";
            FormStore.lastName = "";
            FormStore.phoneNumber = "";
            FormStore.extraInformation = "";
        }
    }
}
