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
        BitmapImage bmap = new BitmapImage();
        public MainPage()
        {
            this.InitializeComponent();
            SetWeatherImage();
            TBlockDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }
        /// <summary>
        /// Opens a weather chart from DMI in a WebView.
        /// </summary>
        public void SetWeatherImage()
        {
            try
            {
                Uri address = new Uri("http://servlet.dmi.dk/byvejr/servlet/byvejr_dag1?by=2630&mode=long");

                bmap.DecodePixelType = DecodePixelType.Logical;
                bmap.DecodePixelWidth = (int)MyGrid.ColumnDefinitions.Select(c => c.ActualWidth).FirstOrDefault();
                bmap.DecodePixelHeight = (int)MyGrid.RowDefinitions.Select(c => c.ActualHeight).FirstOrDefault();
                bmap.UriSource = address;

                ImageWeather.Source = bmap;

            }
            catch (Exception error)
            {
                Debug.WriteLine(error.GetType() + ": " + error.Message);
            }
            
        }

        public void SetComicStripImage()
        {

        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            bmap.DecodePixelWidth = (int)MyGrid.ColumnDefinitions.Select(c => c.ActualWidth).FirstOrDefault();
            bmap.DecodePixelHeight = (int)MyGrid.RowDefinitions.Select(c => c.ActualHeight).FirstOrDefault();
        }
    }
}
