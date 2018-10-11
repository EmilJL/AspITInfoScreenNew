using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using System.Net;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AspITInfoScreen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        BitmapImage weather = new BitmapImage();
        BitmapImage comic = new BitmapImage();
        DateTime Date = DateTime.Now;
        public MainPage()
        {
            this.InitializeComponent();
            SetWeatherImage();
            SetComicStripImage();            
            TBlockDate.Text = Date.ToString("dd/MM/yyyy");
        }
        /// <summary>
        /// Retrieves a BitmapImage of the weather chart from DMI.
        /// </summary>
        public void SetWeatherImage()
        {
            try
            {
                Uri address = new Uri("http://servlet.dmi.dk/byvejr/servlet/byvejr_dag1?by=2630&mode=long");

                weather.DecodePixelType = DecodePixelType.Logical;
                weather.DecodePixelWidth = (int)MyGrid.ColumnDefinitions.Select(c => c.ActualWidth).FirstOrDefault();
                weather.DecodePixelHeight = (int)MyGrid.RowDefinitions.Select(c => c.ActualHeight).FirstOrDefault();
                weather.UriSource = address;

                ImageWeather.Source = weather;

            }
            catch (Exception error)
            {   
                Debug.WriteLine(error.GetType() + ": " + error.Message);
            }
            
        }
        /// <summary>
        /// Retrieves todays Garfield comic strip from Cloudfront.net.
        /// </summary>
        public void SetComicStripImage()
        {
            try
            {
                string url = "https://" + "d1ejxu6vysztl5.cloudfront.net/comics/garfield/" + Date.ToString("yyyy") + "/" + Date.ToString("yyyy-MM-dd") + ".gif";
                Uri address = new Uri(url);

                comic.DecodePixelType = DecodePixelType.Logical;
                comic.DecodePixelWidth = (int)MyGrid.ColumnDefinitions.Select(c => c.ActualWidth).FirstOrDefault();
                comic.DecodePixelHeight = (int)MyGrid.RowDefinitions.Select(c => c.ActualHeight).FirstOrDefault();
                comic.UriSource = address;

                ImageComic.Source = comic;

            }
            catch (Exception error)
            {
                Debug.WriteLine(error.GetType() + ": " + error.Message);
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            weather.DecodePixelWidth = (int)MyGrid.ColumnDefinitions.Select(c => c.ActualWidth).FirstOrDefault();
            weather.DecodePixelHeight = (int)MyGrid.RowDefinitions.Select(c => c.ActualHeight).FirstOrDefault();

            comic.DecodePixelWidth = (int)MyGrid.ColumnDefinitions.Select(c => c.ActualWidth).FirstOrDefault();
            comic.DecodePixelHeight = (int)MyGrid.RowDefinitions.Select(c => c.ActualHeight).FirstOrDefault();
        }
    }
}
