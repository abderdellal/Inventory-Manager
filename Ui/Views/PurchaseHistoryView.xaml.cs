using Logic.ViewModels;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Controls;

namespace Ui.Views
{
    /// <summary>
    /// Interaction logic for PurchaseHistoryView.xaml
    /// </summary>
    public partial class PurchaseHistoryView : UserControl
    {
        public PurchaseHistoryView()
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            Thread.CurrentThread.CurrentCulture = ci;
            InitializeComponent();
        }

        public override void EndInit()
        {
            base.EndInit();
            if (DataContext != null && DataContext is PurchaseHistoryViewModel)
            {
                var viewModel = DataContext as PurchaseHistoryViewModel;
                DateTime minDate = viewModel.minDate;
                DateTime maxDate = viewModel.maxDate;

                minDatePicker.SelectedDate = minDate;
                maxDatePicker.SelectedDate = maxDate;

                MyDataGird.SelectionChanged += (s, e) => viewModel.DeleteSelectedCommand.RaiseCanExecuteChanged();
            }
        }

        private void minDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext != null && DataContext is PurchaseHistoryViewModel)
            {
                var viewModel = DataContext as PurchaseHistoryViewModel;

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
            if (DataContext != null && DataContext is PurchaseHistoryViewModel)
            {
                var viewModel = DataContext as PurchaseHistoryViewModel;

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
