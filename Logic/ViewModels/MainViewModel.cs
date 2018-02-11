using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic.ViewModels.Messages;

namespace Logic.ViewModels
{
    /// <summary>
    /// ViewModel of the Main Window
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// View/ViewModel to be displayed in the main frame (the View will be selected according to this ViewModel type)
        /// </summary>
        public ViewModelBase SelectedViewModel { get; set; }

        /// <summary>
        /// the view model locaor
        /// </summary>
        public ViewModelLocator locator { get; set; }

        /// <summary>
        /// command to be called from the main window to change the selected View/ViewModel
        /// </summary>
        public RelayCommand<ViewModelBase> changeViewCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ViewModelLocator locator)
        {
            this.locator = locator;

            //Home view/viewModel will be selected at startup
            SelectedViewModel = locator.Home;



            changeViewCommand = new RelayCommand<ViewModelBase>(vm =>
                                                                        {
                                                                            SelectedViewModel = vm;
                                                                        }
                                                                );

            MessengerInstance.Register<DisplayStoreDetailMessage> (this, OnDisplayStoreDetailMessage);
            MessengerInstance.Register<DisplayStoreListMessage>(this, OnDisplayStoreListMessage);
            MessengerInstance.Register<EditStoreMessage>(this, OnEditStoreMessage);

            MessengerInstance.Register<DisplayProductDetailMessage>(this, OnDisplayProductDetailMessage);
            MessengerInstance.Register<DisplayProductListMessage>(this, OnDisplayProductListMessage);
            MessengerInstance.Register<EditProductMessage>(this, OnEditProductMessage);
        }
        public void OnDisplayStoreDetailMessage(DisplayStoreDetailMessage msg)
        {
            var vm = locator.StoreDetail;
            vm.store = msg.store;
            SelectedViewModel = vm;
        }
        public void OnDisplayStoreListMessage(DisplayStoreListMessage msg)
        {
            SelectedViewModel = locator.StoresList;
        }
        public void OnEditStoreMessage(EditStoreMessage msg)
        {
            var vm = locator.AddStore;
            vm.storeToEdit = msg.store;
            SelectedViewModel = vm;
        }

        public void OnDisplayProductDetailMessage(DisplayProductDetailMessage msg)
        {
            var vm = locator.ProductDetail;
            vm.product = msg.product;
            SelectedViewModel = vm;
        }
        public void OnDisplayProductListMessage(DisplayProductListMessage msg)
        {
            SelectedViewModel = locator.ProductList;
        }
        public void OnEditProductMessage(EditProductMessage msg)
        {
            var vm = locator.AddProduct;
            vm.ProductToEdit = msg.product;
            SelectedViewModel = vm;
        }
    }
}
