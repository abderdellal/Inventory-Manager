using Logic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ui.Views
{
    /// <summary>
    /// Interaction logic for DailyReportView.xaml
    /// </summary>
    public partial class DailyReportView : UserControl
    {
        public DailyReportView()
        {
            InitializeComponent();
            string targetPercentage = (string)Application.Current.FindResource("targetPercentage");
            string product = (string)Application.Current.FindResource("Product");
            string sales = (string)Application.Current.FindResource("Sales");

            if (this.DataContext != null && this.DataContext is DailyReportViewModel)
            {
                DailyReportViewModel vm = this.DataContext as DailyReportViewModel;
                txtBox.Text = vm.userName + " \n\n";
                txtBox.Text += vm.TodayDate.ToString("dd/MM/yyyy") + " \n\n";

                foreach (var saleInfo in vm.salesInfos)
                {
                    txtBox.Text += product + " :  " + saleInfo.productReference + " \n";
                    txtBox.Text += sales + " :  " + saleInfo.TotalSaleDay + " / " + saleInfo.DayTarget + "             " + targetPercentage + " :  " + saleInfo.TargetPourcentageDay + "%\n\n";
                }
            }
        }
    }
}
