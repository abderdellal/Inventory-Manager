using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight;
using Logic.Persistence;
using Logic.Desgin_Data;
using Logic.Core;

namespace Logic.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator : ViewModelBase
    {
        private DesignContext _designContext;
        private IUnitOfWork _context;
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic)
            {
                _designContext = new DesignContext();
            }
            else
            {
                _context = new UnitOfWork(new InventoryManagerEntities());
                SimpleIoc.Default.Register<MainViewModel>(() => new MainViewModel(this));
                SimpleIoc.Default.Register<StoresListViewModel>(() => new StoresListViewModel(_context));
                SimpleIoc.Default.Register<ProductListViewModel>(() => new ProductListViewModel(_context));
                SimpleIoc.Default.Register<EditStoreViewModel>(() => new EditStoreViewModel(_context));
                SimpleIoc.Default.Register<EditProductViewModel>(() => new EditProductViewModel(_context));
                SimpleIoc.Default.Register<NewPurchaseViewModel>(() => new NewPurchaseViewModel(_context));
                SimpleIoc.Default.Register<NewSaleViewModel>(() => new NewSaleViewModel(_context));
                SimpleIoc.Default.Register<SalesHistoryViewModel>(() => new SalesHistoryViewModel(new UnitOfWork(new InventoryManagerEntities())));
            }

            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<AboutViewModel>();
            SimpleIoc.Default.Register<DailyReportViewModel>();
            SimpleIoc.Default.Register<MonthlyReportViewModel>();
            SimpleIoc.Default.Register<PurchaseHistoryViewModel>();
            SimpleIoc.Default.Register<SettingViewModel>();
            SimpleIoc.Default.Register<WeeklyReportViewModel>();
            SimpleIoc.Default.Register<StoreDetailViewModel>();
            SimpleIoc.Default.Register<ProductDetailViewModel>();

        }

        public MainViewModel Main
        {
            get
            {
                if (ViewModelBase.IsInDesignModeStatic)
                    return new MainViewModel(this);
                else
                    return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public HomeViewModel Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }
        public AboutViewModel About
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AboutViewModel>();
            }
        }

        public EditProductViewModel AddProduct
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditProductViewModel>();
            }
        }

        public EditStoreViewModel AddStore
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditStoreViewModel>();
            }
        }

        public DailyReportViewModel DailyReport
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DailyReportViewModel>();
            }
        }

        public MonthlyReportViewModel MonthlyReport
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MonthlyReportViewModel>();
            }
        }

        public NewPurchaseViewModel NewPurchase
        {
            get
            {
                if(ViewModelBase.IsInDesignModeStatic)
                {
                    return new NewPurchaseViewModel(null);
                }
                else
                { 
                    return ServiceLocator.Current.GetInstance<NewPurchaseViewModel>();
                }
            }
        }
        public NewSaleViewModel NewSale
        {
            get
            {
                if (ViewModelBase.IsInDesignModeStatic)
                {
                    return new NewSaleViewModel(null);
                }
                else
                {
                    return ServiceLocator.Current.GetInstance<NewSaleViewModel>();
                }
            }
        }
        public ProductListViewModel ProductList
        {
            get
            {
                if (ViewModelBase.IsInDesignModeStatic)
                    return new ProductListViewModel(null);

                else
                    return ServiceLocator.Current.GetInstance<ProductListViewModel>();
            }
        }
        public PurchaseHistoryViewModel PurchaseHistory
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PurchaseHistoryViewModel>();
            }
        }
        public SalesHistoryViewModel SalesHistory
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SalesHistoryViewModel>();
            }
        }
        public SettingViewModel Setting
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingViewModel>();
            }
        }
        public StoresListViewModel StoresList
        {
            get
            {
                if (ViewModelBase.IsInDesignModeStatic)
                    return new StoresListViewModel(null);

                else
                    return ServiceLocator.Current.GetInstance<StoresListViewModel>();
            }
        }
        public WeeklyReportViewModel WeeklyReport
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WeeklyReportViewModel>();
            }
        }
        public StoreDetailViewModel StoreDetail
        {
            get
            {
                StoreDetailViewModel vm;
                if (ViewModelBase.IsInDesignModeStatic)
                {
                    vm = new StoreDetailViewModel();
                    vm.store = _designContext.Stores[0];
                }
                else
                {
                    vm = ServiceLocator.Current.GetInstance<StoreDetailViewModel>();
                }
                return vm;
            }
        }

        public ProductDetailViewModel ProductDetail
        {
            get
            {
                ProductDetailViewModel vm;
                if (ViewModelBase.IsInDesignModeStatic)
                {
                    vm = new ProductDetailViewModel();
                    vm.product = _designContext.Products[0];
                }
                else
                {
                    vm = ServiceLocator.Current.GetInstance<ProductDetailViewModel>();
                }
                return vm;
            }
        }
        //public static void Cleanup()
        //{
        //    // TODO Clear the ViewModels
        //}
    }
}
