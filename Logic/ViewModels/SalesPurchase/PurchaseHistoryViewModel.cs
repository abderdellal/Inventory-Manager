using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic.Core;
using Logic.Core.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Logic.ViewModels
{
    public class PurchaseHistoryViewModel : ViewModelBase
    {
        private IUnitOfWork _context;

        public ObservableCollection<Purchase> Purchases { get; set; } = new ObservableCollection<Purchase>();
        public Purchase selectedPurchase { get; set; }

        public DateTime maxDate { get; set; }
        public DateTime minDate { get; set; }
        public ObservableCollection<Store> stores { get; set; }
        public ObservableCollection<Product> products { get; set; }
        public Store selectedStore { get; set; }
        public Product selectedProduct { get; set; }

        public long TotalSum
        {
            get
            {
                return Purchases.Sum(s => (s.totalPrice));
            }
        }

        public int TotalAmount
        {
            get
            {
                return Purchases.Sum(s => s.amount);
            }
        }

        public RelayCommand refreshCommand { get; set; }
        public RelayCommand resetCommand { get; set; }
        public RelayCommand saveChangesCommand { get; set; }
        public RelayCommand<object> DeleteSelectedCommand { get; set; }

        //this two fields are used to reset the comboBox
        private Store NullStore;
        private Product NullProduct;

        public PurchaseHistoryViewModel(IUnitOfWork ctx)
        {
            this._context = ctx;

            stores = new ObservableCollection<Store>(_context.Stores.GetAll());
            products = new ObservableCollection<Product>(_context.Products.GetAll());
            NullStore = new Store() { id = -1, storeName = "" };
            NullProduct = new Product() { id = -1, reference = "" };
            stores.Insert(0, NullStore);
            products.Insert(0, NullProduct);

            ResetFeilds();

            populatePurchases();

            refreshCommand = new RelayCommand(() =>
            {
                populatePurchases();
            });
            resetCommand = new RelayCommand(() =>
            {
                ResetFeilds();
                populatePurchases();
            });
            saveChangesCommand = new RelayCommand(() =>
            {
                _context.Complete();
                saveChangesCommand.RaiseCanExecuteChanged();
            },
            () =>
            {
                return _context.hasPendingChanges();
            });
            DeleteSelectedCommand = new RelayCommand<object>(parameter =>
            {
                if (parameter != null)
                {
                    System.Collections.IList items = (System.Collections.IList)parameter;
                    var selection = items?.Cast<Purchase>().ToList();
                    _context.Purchases.RemoveRange(selection);
                    foreach (var purchase in selection)
                    {
                        Purchases.Remove(purchase);
                    }
                    saveChangesCommand.RaiseCanExecuteChanged();
                }
                //_context.Purchases.Remove(selectedPurchase);
                //Purchases.Remove(selectedPurchase);
                //selectedPurchase = null;
            }, parameter =>
            {
                if (parameter != null)
                {
                    System.Collections.IList items = (System.Collections.IList)parameter;
                    if (items.Count > 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            );
            MessengerInstance.Register<Messages.ProductAddedMessage>(this, (msg) =>
            {
                products.Add(msg.product);
            });
            MessengerInstance.Register<Messages.StoreAddedMessage>(this, (msg) =>
            {
                stores.Add(msg.store);
            });
        }

        private void ResetFeilds()
        {
            maxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1);
            minDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);

            selectedStore = NullStore;
            selectedProduct = NullProduct;
        }

        private void populatePurchases()
        {
            if (Purchases != null)
                Purchases.Clear();
            else
                Purchases = new ObservableCollection<Purchase>();

            IEnumerable<Purchase> purchases = _context.Purchases.getPurchasesOf(minDate, maxDate, selectedProduct != NullProduct ? selectedProduct : null, selectedStore != NullStore ? selectedStore : null);

            foreach (Purchase purchase in purchases)
            {
                purchase.PropertyChanged += (s, e) => saveChangesCommand.RaiseCanExecuteChanged();
                Purchases.Add(purchase);
            }
            RaisePropertyChanged("TotalSum");
            RaisePropertyChanged("TotalAmount");

        }
    }
}
