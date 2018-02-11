using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic.Core.Domain;
using Logic.ViewModels.Messages;

namespace Logic.ViewModels
{
    public class ProductDetailViewModel : ViewModelBase
    {
        public Product product { get; set; }
        public RelayCommand BackClickCommand { get; set; }

        public ProductDetailViewModel()
        {
            BackClickCommand = new RelayCommand(() =>
            {
                MessengerInstance.Send(new DisplayProductListMessage());
            });
        }
    }
}
