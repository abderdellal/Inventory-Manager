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
    /// Interaction logic for MonthlyReportView.xaml
    /// </summary>
    public partial class MonthlyReportView : UserControl
    {
        public MonthlyReportView()
        {
            InitializeComponent();
            string targetPercentage = (string) Application.Current.FindResource("targetPercentage");
            string product = (string) Application.Current.FindResource("Product");
            string sales = (string) Application.Current.FindResource("Sales");

            if(this.DataContext != null && this.DataContext is MonthlyReportViewModel)
            {
                MonthlyReportViewModel vm = this.DataContext as MonthlyReportViewModel;
                txtBox.Text = vm.userName + " \n\n";
                txtBox.Text += vm.TodayDate.ToString("dd/MM/yyyy") + " \n\n";

                foreach (var saleInfo in vm.salesInfos)
                {
                    txtBox.Text += product + " :  " + saleInfo.productReference + " \n";
                    txtBox.Text += sales + " :  " + saleInfo.TotalSaleMonth + " / " + saleInfo.MonthTarget + "             "+ targetPercentage + " :  " + saleInfo.TargetPourcentageMonth + " %\n\n";
                }
            }
        }
    }
}
