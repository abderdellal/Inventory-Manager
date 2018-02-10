using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic.Core;
using Logic.Core.Domain;
using Logic.Desgin_Data;
using System;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Logic.ViewModels.Messages;
using Logic.Persistence;
using System.Linq;

namespace Logic.ViewModels
{
    public class StoresListViewModel : ViewModelBase, IDisposable
    {
        private IUnitOfWork _context;

        public ObservableCollection<Store> stores
        {
            get;
            private set;
        }

        public RelayCommand<Store> DeleteStoreCommande { get; private set; }
        public RelayCommand<StockWithAmount> UpdateStockCommande { get; private set; }
        public RelayCommand<Store> EditStoreCommande { get; private set; }
        public RelayCommand<Store> StoreDetailCommande { get; private set; }

        public StoresListViewModel(IUnitOfWork uow)
        {
            _context = uow; ;
            //fake data to display in design mode
            if (ViewModelBase.IsInDesignModeStatic)
            {
                var ctx = new DesignContext();
                stores = new ObservableCollection<Store>(ctx.Stores);
            }
            //real data
            else
            {
                stores = new ObservableCollection<Store>(_context.Stores.GetStoresWithStockPerProduct());
            }

            DeleteStoreCommande = new RelayCommand<Store>(s =>
            {
                _context.Stores.deleteStoreOnCascade(s);
                _context.Complete();
                stores.Remove(s);

            });
            UpdateStockCommande = new RelayCommand<StockWithAmount>(stkPair =>
            {
                if (stkPair != null)
                {
                    stkPair.stock.amount = stkPair.amount;
                    _context.Complete();
                    stkPair.stock.Store.NotifyPropertyChanged("StockTotal");
                }
            });

            EditStoreCommande = new RelayCommand<Store>(store =>
            {
                MessengerInstance.Send(new EditStoreMessage(store));
            });
            
            StoreDetailCommande = new RelayCommand<Store>(store =>
            {
                MessengerInstance.Send(new DisplayStoreDetailMessage(store));
            });

            MessengerInstance.Register<StoreAddedMessage>(this, msg =>
            {
                stores.Add(msg.store);
            });
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

    /// <summary>
    /// this class is used to pass two parrametre two the UpdateStockCommande 
    /// it holds a pair of parametre as it is the only way to pass two parametre to a command
    /// </summary>
    public class StockWithAmount
    {
        public Stock stock { get; set; }
        public long amount { get; set; }
    }

    /// <summary>
    /// this class is called by the save button to create a StockWithAmount instance and pass it as a parametre to the UpdateStockCommande
    /// </summary>
    public class TextBoxToStockWithAmountConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return new StockWithAmount()
                {
                    stock = (Stock)values[0],
                    amount = (long)double.Parse(values[1].ToString())
                };
            }
            catch 
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
