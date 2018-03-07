using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            InitializeComponent();
        }
    }
}
