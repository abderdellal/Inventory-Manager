using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic.Core.Domain;
using Logic.ViewModels.Messages;
namespace Logic.ViewModels
{
    public class StoreDetailViewModel : ViewModelBase
    {
        public Store store { get; set; }
        public RelayCommand BackClickCommand { get; set; }

        public StoreDetailViewModel()
        {
            BackClickCommand = new RelayCommand(() =>
            {
                MessengerInstance.Send(new DisplayStoreListMessage());
            });
        }
    }
}
