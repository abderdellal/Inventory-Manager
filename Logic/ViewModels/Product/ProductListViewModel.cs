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
    public class ProductListViewModel : ViewModelBase
    {
        private IUnitOfWork _context;

        public ObservableCollection<Product> products
        {
            get;
            private set;
        }

        public RelayCommand<Product> DeleteProductCommande { get; private set; }
        public RelayCommand<StockWithAmount> UpdateStockCommande { get; private set; }
        public RelayCommand<Product> EditProductCommande { get; private set; }
        public RelayCommand<Product> ProductDetailCommande { get; private set; }

        public ProductListViewModel(IUnitOfWork uow)
        {
            _context = uow; ;
            //fake data to display in design mode
            if (ViewModelBase.IsInDesignModeStatic)
            {
                var ctx = new DesignContext();
                products = new ObservableCollection<Product>(ctx.Products);
            }
            //real data
            else
            {
                products = new ObservableCollection<Product>(_context.Products.GetProductsWithStockPerStore());
            }

            DeleteProductCommande = new RelayCommand<Product>(p =>
            {
                _context.Products.deleteProductOnCascade(p);
                _context.Complete();
                products.Remove(p);

            });
            UpdateStockCommande = new RelayCommand<StockWithAmount>(stkPair =>
            {
                if (stkPair != null)
                {
                    stkPair.stock.amount = stkPair.amount;
                    _context.Complete();
                    stkPair.stock.Product.NotifyPropertyChanged("StockTotal");
                    stkPair.stock.Store.NotifyPropertyChanged("StockTotal");
                }
            });

            EditProductCommande = new RelayCommand<Product>(product =>
            {
                MessengerInstance.Send(new EditProductMessage(product));
            });

            ProductDetailCommande = new RelayCommand<Product>(product =>
            {
                MessengerInstance.Send(new DisplayProductDetailMessage(product));
            });

            MessengerInstance.Register<ProductAddedMessage>(this, msg =>
            {
                products.Add(msg.product);
            });
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
