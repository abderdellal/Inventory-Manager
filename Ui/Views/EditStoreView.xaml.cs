using Logic.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using Ui.Views.Converters;

namespace Ui.Views
{
    /// <summary>
    /// Interaction logic for AddStoreView.xaml
    /// </summary>
    public partial class EditStoreView : UserControl
    {
        public EditStoreView()
        {
            InitializeComponent();
        }

        private void Border_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.Filter = "JPG|*.jpg|PNG|*.png|JPEG|*.jpg";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] fileNames = openFileDialog1.FileNames;
                Bitmap img = new Bitmap(fileNames[0]);

                if (DataContext != null && DataContext is EditStoreViewModel)
                {
                    EditStoreViewModel vm = (EditStoreViewModel)DataContext;
                    vm.FormStore.picture = NullToStoreImageConverter.ImageToByte(img);
                    imageText.Text = "Cliquez pour modifier la photo";
                }

            }
        }
        

        private void bordurePhoto_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //userImage.Visibility = System.Windows.Visibility.Visible;
            Mouse.OverrideCursor = Cursors.Arrow;
            bordurePhoto.BorderBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 0));
            imageText.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 0));

        }

        private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //userImage.Visibility = System.Windows.Visibility.Hidden;
            Mouse.OverrideCursor = Cursors.Hand;
            bordurePhoto.BorderBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 100, 20, 150));
            imageText.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 100, 20, 150));

        }
    }
}
