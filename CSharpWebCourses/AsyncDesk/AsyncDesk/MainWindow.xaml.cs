using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace AsyncDesk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await ShowImageAsync(Image1, "https://http.cat/100");
            await ShowImageAsync(Image2, "https://http.cat/201");
            await ShowImageAsync(Image3, "https://http.cat/302");
            await ShowImageAsync(Image4, "https://http.cat/404");
            await ShowImageAsync(Image5, "https://http.cat/500");
            await ShowImageAsync(Image6, "https://http.cat/509");
        }

        private async Task ShowImageAsync(Image image, string url)
        {
            WebClient wc = new WebClient();
            var result = await wc.DownloadDataTaskAsync(url);
            await Task.Run(() => Thread.Sleep(1000));
            image.Source = LoadImage(result);
        }

        private static ImageSource LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        private static bool clicked = false;
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (clicked)
            {
                textField.Text = "Yes, I work!!!";
                clicked = false;
            }
            else
            {
                textField.Text = "Check me again!";
                clicked = true; 
            }
        }
    }
}
