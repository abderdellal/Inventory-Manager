using GalaSoft.MvvmLight;
using Logic.Core;
using Logic.Core.Domain;
using Logic.Core.Repositories;
using Logic.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ViewModels
{
    public class MonthlyReportViewModel : ViewModelBase
    {
        private IUnitOfWork _context;
        public string userName { get; set; }
        public DateTime TodayDate { get; set; }
        public IEnumerable<ProductSalesInfo> salesInfos { get; set; }

        public MonthlyReportViewModel(IUnitOfWork ctx)
        {
            _context = ctx;

            TodayDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            userName = Settings.Default["firstName"] + " " + Settings.Default["lastName"];
            salesInfos = ctx.Products.GetProductsSalesInfo();
        }
    }
}
