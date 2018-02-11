using Logic.ViewModels;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Ui.Views.Converters;

namespace Ui.Views
{
    /// <summary>
    /// Interaction logic for AddProductView.xaml
    /// </summary>
    public partial class EditProductView : UserControl
    {
        public EditProductView()
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

                if (DataContext != null && DataContext is EditProductViewModel)
                {
                    EditProductViewModel vm = (EditProductViewModel)DataContext;
                    vm.FormProduct.picture = NullToProductImageConverter.ImageToByte(img);
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
