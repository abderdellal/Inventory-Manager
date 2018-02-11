using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic.Core;
using Logic.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.ViewModels
{
    public class NewSaleViewModel : ViewModelBase
    {
        private IUnitOfWork _context;

        public IEnumerable<Store> stores { get; set; }
        public IEnumerable<Product> products { get; set; }
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
                if (!int.TryParse(value, out amount))
                {
                    amount = 0;
                }
            }
        }


        public RelayCommand SaveCommand { get; set; }

        public NewSaleViewModel(IUnitOfWork ctx)
        {
            _context = ctx;
            stores = _context.Stores.GetAll();
            products = _context.Products.GetAll();
            selectedProduct = null;
            selectedStore = null;
            amount = 0;
            SaveCommand = new RelayCommand(SaveSale, canSave);
            this.PropertyChanged += (s, e) => SaveCommand.RaiseCanExecuteChanged();
        }
        public void SaveSale()
        {
            Sale p = new Sale();
            p.Store = selectedStore;
            p.Product = selectedProduct;
            p.amount = amount;
            p.date = DateTime.Now.ToString("DD/MM/YYYY");
            _context.Sales.Add(p);
            var stks = _context.Stocks.GetStocksWithStoresAndProductWhere(stk => (stk.Product.id == selectedProduct.id && stk.Store.id == selectedStore.id));
            if (stks != null && stks.Count() > 0)
            {
                var stk = stks.FirstOrDefault();
                stk.amount -= amount;
                _context.Complete();
                selectedProduct = null;
                selectedStore = null;
                stringAmount = "0";
            }
        }

        public bool canSave()
        {

            if (selectedStore != null && selectedProduct != null &&  amount > 0)
            {
                var stks = _context.Stocks.GetStocksWithStoresAndProductWhere(stk => (stk.Product.id == selectedProduct.id && stk.Store.id == selectedStore.id));
                if (stks.Count() > 0 && stks.FirstOrDefault().amount >= amount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
