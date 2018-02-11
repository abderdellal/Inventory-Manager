using Logic.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for SaleHistoryView.xaml
    /// </summary>
    public partial class SaleHistoryView : UserControl
    {
        public SaleHistoryView()
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            Thread.CurrentThread.CurrentCulture = ci;
            InitializeComponent();
        }

        public override void EndInit()
        {
            base.EndInit();
            if (DataContext != null && DataContext is SalesHistoryViewModel)
            {
                var viewModel = DataContext as SalesHistoryViewModel;
                DateTime minDate = viewModel.minDate;
                DateTime maxDate = viewModel.maxDate;

                minDatePicker.SelectedDate = minDate;
                maxDatePicker.SelectedDate = maxDate;

                MyDataGird.SelectionChanged += (s, e) => viewModel.DeleteSelectedCommand.RaiseCanExecuteChanged();
            }
        }

        private void minDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext != null && DataContext is SalesHistoryViewModel)
            {
                var viewModel = DataContext as SalesHistoryViewModel;

                var picker = sender as DatePicker;
                DateTime? date = picker.SelectedDate;

                if (date != null)
                {
                    viewModel.minDate = (DateTime)date;
                }
            }
        }

        private void maxDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext != null && DataContext is SalesHistoryViewModel)
            {
                var viewModel = DataContext as SalesHistoryViewModel;

                var picker = sender as DatePicker;
                DateTime? date = picker.SelectedDate;

                if (date != null)
                {
                    viewModel.maxDate = (DateTime)date;
                }
            }
        }

    }
}
