using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<AboutViewModel>();
            SimpleIoc.Default.Register<AddProductViewModel>();
            SimpleIoc.Default.Register<AddStoreViewModel>();
            SimpleIoc.Default.Register<DailyReportViewModel>();
            SimpleIoc.Default.Register<MonthlyReportViewModel>();
            SimpleIoc.Default.Register<NewPurchaseViewModel>();
            SimpleIoc.Default.Register<NewSaleViewModel>();
            SimpleIoc.Default.Register<ProductListViewModel>();
            SimpleIoc.Default.Register<PurchaseHistoryViewModel>();
            SimpleIoc.Default.Register<SalesHistoryViewModel>();
            SimpleIoc.Default.Register<SettingViewModel>();
            SimpleIoc.Default.Register<StoresListViewModel>();
            SimpleIoc.Default.Register<WeeklyReportViewModel>();
            SimpleIoc.Default.Register<MainViewModel>(() => new MainViewModel(this));
        }

        public MainViewModel Main
        {
            get
            {
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

        public AddProductViewModel AddProduct
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddProductViewModel>();
            }
        }

        public AddStoreViewModel AddStore
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddStoreViewModel>();
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
                return ServiceLocator.Current.GetInstance<NewPurchaseViewModel>();
            }
        }
        public NewSaleViewModel NewSale
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NewSaleViewModel>();
            }
        }
        public ProductListViewModel ProductList
        {
            get
            {
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

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
