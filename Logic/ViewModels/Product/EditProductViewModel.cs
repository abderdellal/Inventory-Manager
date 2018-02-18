using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Logic.Core;
using Logic.Core.Domain;
using Logic.ViewModels.Messages;
using System.Collections.Generic;

namespace Logic.ViewModels
{
    /// <summary>
    /// View model for editing a product or adding a new one
    /// </summary>
    public class EditProductViewModel : ViewModelBase
    {
        private IUnitOfWork _context;

        public RelayCommand SaveProductCommand { get; set; }

        /// <summary>
        /// the product that is displayed on the form
        /// </summary>
        public Product FormProduct { get; set; }

        private Product _Product;
        /// <summary>
        /// this is set from outside the class to specify the product we're editing
        /// if this is null then we are adding a new product
        /// </summary>
        public Product ProductToEdit
        {
            get
            {
                return _Product;
            }
            set
            {
                _Product = value;
                FormProduct.reference = value.reference;
                FormProduct.picture = value.picture;
                FormProduct.purchasingPrice = value.purchasingPrice;
                FormProduct.sellingPrice = value.sellingPrice;
                FormProduct.extraInformation = value.extraInformation;
                FormProduct.dailyTarget = value.dailyTarget;
                FormProduct.monthlyTarget = value.monthlyTarget;
            }
        }


        public EditProductViewModel(IUnitOfWork ctx)
        {
            FormProduct = new Product();
            _context = ctx;
            SaveProductCommand = new RelayCommand(saveProduct, CanSaveProduct);
            FormProduct.PropertyChanged += (s, e) => SaveProductCommand.RaiseCanExecuteChanged();
        }

        public void saveProduct()
        {
            if (CanSaveProduct())
            {
                //if the product to edit is null then we are adding a new product
                if (ProductToEdit == null)
                {
                    _Product = new Product();
                    MessengerInstance.Send(new Messages.ProductAddedMessage(_Product));
                    _context.Products.Add(ProductToEdit);
                    IEnumerable<Store> stores = _context.Stores.GetAll();
                    foreach (var str in stores)
                    {
                        Stock stk = new Stock() { amount = 0, Product = _Product, Store = str };
                        _context.Stocks.Add(stk);
                    }
                }

                ProductToEdit.reference = FormProduct.reference;
                ProductToEdit.picture = FormProduct.picture;
                ProductToEdit.purchasingPrice = FormProduct.purchasingPrice;
                ProductToEdit.sellingPrice = FormProduct.sellingPrice;
                ProductToEdit.extraInformation = FormProduct.extraInformation;
                ProductToEdit.dailyTarget = FormProduct.dailyTarget;
                ProductToEdit.monthlyTarget = FormProduct.monthlyTarget;

                _context.Complete();
                _Product = null;
                resetForm();
                MessengerInstance.Send(new DisplayProductListMessage());
            }
        }

        public bool CanSaveProduct()
        {
            if (FormProduct != null)
                return FormProduct.IsValid();
            else
                return false;
        }

        public void resetForm()
        {
            FormProduct.reference = "";
            FormProduct.picture = null;
            FormProduct.purchasingPrice = 0;
            FormProduct.sellingPrice = 0;
            FormProduct.extraInformation = "";
            FormProduct.dailyTarget = null;
            FormProduct.monthlyTarget = null;
        }
    }
}
