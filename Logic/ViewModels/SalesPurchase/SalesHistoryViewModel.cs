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
    public class SalesHistoryViewModel : ViewModelBase
    {
        private IUnitOfWork _context;

        public ObservableCollection<Sale> Sales { get; set; } = new ObservableCollection<Sale>();
        public Sale selectedSale { get; set; }

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
                return Sales.Sum(s => (s.totalPrice));
            }
        }

        public int TotalAmount
        {
            get
            {
                return Sales.Sum(s => s.amount);
            }
        }

        public RelayCommand refreshCommand { get; set; }
        public RelayCommand resetCommand { get; set; }
        public RelayCommand saveChangesCommand { get; set; }
        public RelayCommand<object> DeleteSelectedCommand { get; set; }

        //this two fields are used to reset the comboBox
        private Store NullStore;
        private Product NullProduct;

        public SalesHistoryViewModel(IUnitOfWork ctx)
        {
            this._context = ctx;

            stores = new ObservableCollection<Store>(_context.Stores.GetAll());
            products = new ObservableCollection<Product>(_context.Products.GetAll());
            NullStore = new Store() { id = -1, storeName = "" };
            NullProduct = new Product() { id = -1, reference = "" };
            stores.Insert(0, NullStore);
            products.Insert(0, NullProduct);

            ResetFeilds();

            populateSales();

            refreshCommand = new RelayCommand(() =>
            {
                populateSales();
            });
            resetCommand = new RelayCommand(() =>
            {
                ResetFeilds();
                populateSales();
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
                    var selection = items?.Cast<Sale>().ToList();
                    _context.Sales.RemoveRange(selection);
                    foreach (var sale in selection)
                    {
                        Sales.Remove(sale);
                    }
                    saveChangesCommand.RaiseCanExecuteChanged();
                }
                //_context.Sales.Remove(selectedSale);
                //Sales.Remove(selectedSale);
                //selectedSale = null;
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
        }

        private void ResetFeilds()
        {
            maxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 0, 0, 0);
            minDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);

            selectedStore = NullStore;
            selectedProduct = NullProduct;
        }

        private void populateSales()
        {
            if (Sales != null)
                Sales.Clear();
            else
                Sales = new ObservableCollection<Sale>();

            IEnumerable<Sale> sales = _context.Sales.getSalesOf(minDate, maxDate, selectedProduct != NullProduct ? selectedProduct : null, selectedStore != NullStore ? selectedStore : null);

            foreach (Sale sale in sales)
            {
                sale.PropertyChanged +=  (s, e) => saveChangesCommand.RaiseCanExecuteChanged();
                Sales.Add(sale);
            }
            RaisePropertyChanged("TotalSum");
            RaisePropertyChanged("TotalAmount");

        }
    }
}
