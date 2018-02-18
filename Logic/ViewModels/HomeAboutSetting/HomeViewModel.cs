using GalaSoft.MvvmLight;
using Logic.Core;
using Logic.Core.Repositories;
using Logic.Properties;
using System;
using System.Collections.Generic;

namespace Logic.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private IUnitOfWork _context;
        public IEnumerable<ProductSalesInfo> productSales { get; set; }
        public DateTime today { get; set; }
        public string UserName { get; set; }
        public int totalDayTarget { get; set; }
        public int totalMonthTarget { get; set; }
        public int totalDaySales { get; set; }
        public int totalMonthSales { get; set; }
        public int totalDailyPercentage { get; set; }
        public int totalMonthlyPercentage { get; set; }


        public HomeViewModel(IUnitOfWork ctx)
        {
            _context = ctx;
            today = DateTime.Now;
            productSales = _context.Products.GetProductsSalesInfo();
            UserName = Settings.Default["firstName"].ToString() + "   " + Settings.Default["lastName"].ToString();
            totalDayTarget = (int)Settings.Default["DailyTargetAll"];
            totalMonthTarget  = (int)Settings.Default["MonthlyTargetAll"];
            totalDaySales = _context.Sales.getTotalAmountOfSalesToday();
            totalMonthSales = _context.Sales.getTotalAmountOfSalesForTheMonth();
            totalDailyPercentage = (totalDaySales * 100) / totalDayTarget ;
            totalMonthlyPercentage = (totalMonthSales * 100) / totalMonthTarget ;
        }
    }
}
