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
    public class NewPurchaseViewModel : ViewModelBase
    {
        private IUnitOfWork _context;

        public ObservableCollection<Store> stores { get; set; }
        public ObservableCollection<Product> products { get; set; }
        public Store selectedStore { get; set; }
        public Product selectedProduct { get; set; }
        private int amount;
        public string stringAmount
        {
            get
            {
                return amount + "";
            }
            set
            {
                if(!int.TryParse(value, out amount))
                {
                    amount = 0;
                }
            }
        }


        public RelayCommand SaveCommand { get; set; }

        public NewPurchaseViewModel(IUnitOfWork ctx)
        {
            _context = ctx;
            stores = new ObservableCollection<Store>(_context.Stores.GetAll());
            products = new ObservableCollection<Product>(_context.Products.GetAll());
            selectedProduct = null;
            selectedStore = null;
            amount = 0;
            SaveCommand = new RelayCommand(SavePurshase, canSave);
            this.PropertyChanged += (s, e) => SaveCommand.RaiseCanExecuteChanged();

            MessengerInstance.Register<Messages.ProductAddedMessage>(this, (msg) =>
            {
                products.Add(msg.product);
            });
            MessengerInstance.Register<Messages.StoreAddedMessage>(this, (msg) =>
            {
                stores.Add(msg.store);
            });
        }
        public void SavePurshase()
        {
            Purchase p = new Purchase();
            p.storeName = selectedStore.storeName;
            p.productReference = selectedProduct.reference;
            p.amount = amount;
            p.unitPrice = selectedProduct.purchasingPrice;
            //p.date = DateTime.Now.ToString("dd/MM/yyyy");
            p.date = DateTime.Now;
            _context.Purchases.Add(p);
            var stks = _context.Stocks.GetStocksWithStoresAndProductWhere(stk => (stk.Product.id == selectedProduct.id && stk.Store.id == selectedStore.id));
            if(stks != null && stks.Count() > 0)
            {
                var stk = stks.FirstOrDefault();
                stk.amount += amount;
            }
            else
            {
                var stk = new Stock(amount, selectedProduct, selectedStore);
                _context.Stocks.Add(stk);
            }
            _context.Complete();
            selectedProduct = null;
            selectedStore = null;
            stringAmount = "0";
         }
        
        public bool canSave()
        {
            if(selectedStore != null && selectedProduct != null && amount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
