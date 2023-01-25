using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Yeraly.Manager.PL.WPF
{
    public partial class MainWindow : Window
    {
        private readonly string PATH_TO_IMAGES = $"{Directory.GetCurrentDirectory()}";
        private int _id = 0;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClick_Start(object sender, RoutedEventArgs e)
        {
            Result.Text = $"Welcome to App! \nThis is random number: {new Random().Next(0, 100)}\nIndex: {_id}";

            _id++;
            var uriTest = new Uri("pack://application:,,,/images/2434769.jpg");

            var uri = new Uri(@".../images/2434769.jpg", UriKind.Relative);
            NextImage.Source = new BitmapImage(uri);
        }
    }
}
