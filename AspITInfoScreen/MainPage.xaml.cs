﻿using System;
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
using Windows.UI.Xaml.Documents;
using AspITInfoScreen.Business;
using AspITInfoScreen.DAL;
using Windows.Data.Pdf;
using System.Net.Http;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AspITInfoScreen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DBHandler dbHandler;
        private LunchPlanHandler lunchPlanHandler;
        private Model model;
        private MealHandler mealHandler;
        private MessageHandler messageHandler;
        int counter;
        DateTime Date = DateTime.Now;
        public ObservableCollection<BitmapImage> PdfPages
        {
            get;
            set;
        } = new ObservableCollection<BitmapImage>();
        public MainPage()
        {
            this.InitializeComponent();
            lunchPlanHandler = new LunchPlanHandler();
            mealHandler = new MealHandler();
            dbHandler = new DBHandler();
            messageHandler = new MessageHandler();
            model = dbHandler.Model;
            counter = 1;
            SetDpTimer();
        }

        private void SetDpTimer()
        {
            DispatcherTimer timer = new DispatcherTimer() { Interval = new TimeSpan(0,2,0) };
            timer.Tick += Dispatcher_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateUiContent();
        }

        private void Dispatcher_Elapsed(object sender, object e)
        {
            if (counter == 1)
            {
                counter++;
            }
            UpdateUiContent();
            counter++;
        }

        private void UpdateUiContent()
        {
            if (counter % 2 != 0)
            {
                TBlockAdminMessage.Text += "[Tick] ";
            }
            else
            {
                TBlockAdminMessage.Text += "[Tock] ";
            }
            SetWeatherImage();
            SetComicStripImage(ImageComic);
            TBlockDate.Text = Date.ToString("dd/MM/yyyy");
            SetAdminMessage();
            OpenRemoteModule();
        }

        /// <summary>
        /// Retrieves a BitmapImage of the weather chart from DMI.
        /// </summary>
        private void SetWeatherImage()
        {
            try
            {
                BitmapImage weather = new BitmapImage();
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
        /// Retrieves Garfield comic strips from Cloudfront.net.
        /// </summary>
        private void SetComicStripImage(Image container, int deductDays = 0)
        {
            try
            {
                BitmapImage comic = new BitmapImage();
                string url = "https://" + "d1ejxu6vysztl5.cloudfront.net/comics/garfield/" + Date.ToString("yyyy") + "/" + Date.AddDays(-deductDays).ToString("yyyy-MM-dd") + ".gif";
                Uri address = new Uri(url);

                comic.DecodePixelType = DecodePixelType.Logical;
                comic.DecodePixelWidth = (int)MyGrid.ColumnDefinitions.Select(c => c.ActualWidth).FirstOrDefault();
                comic.DecodePixelHeight = (int)Math.Round(MyGrid.RowDefinitions.Select(c => c.ActualHeight).FirstOrDefault() / 2);
                comic.UriSource = address;

                container.Source = comic;

            }
            catch (Exception error)
            {
                Debug.WriteLine(error.GetType() + ": " + error.Message);
            }
        }

        /// <summary>
        /// Sets the AdminMessage elements to the maximum amount of characters allowed.
        /// </summary>
        private void GetMaxAdminMessage()
        {
            string msg = new string('W', 660);
            string title = new string('W', 44);
            TBlockAdminMessageTitle.VerticalAlignment = VerticalAlignment.Top;
            TBlockAdminMessageTitle.Text = title;
            TBlockAdminMessage.Text = msg;
        }
        /// <summary>
        /// Retrieves the module schedule from AspIT.dk and converts it into a bitmap to display in the GUI.
        /// </summary>
        private async void OpenRemoteModule()
        {
            HttpClient client = new HttpClient();
            Uri url = new Uri("http://www.aspit.dk/fileadmin/filbibliotek/KALENDER/2018-Fremad/Efteraar-18-v2.pdf");
            var stream = await client.GetStreamAsync(url);
            var memStream = new MemoryStream();
            await stream.CopyToAsync(memStream);
            memStream.Position = 0;
            PdfDocument doc = await PdfDocument.LoadFromStreamAsync(memStream.AsRandomAccessStream());

            BitmapImage bitmap = new BitmapImage();
            var page = doc.GetPage(0);

            using (Windows.Storage.Streams.InMemoryRandomAccessStream mStream = new Windows.Storage.Streams.InMemoryRandomAccessStream())
            {
                await page.RenderToStreamAsync(mStream);
                await bitmap.SetSourceAsync(mStream);
            }

            ImageModulePlan.Source = bitmap;
        }
        /// <summary>
        /// Retrives the custom admin message from the database and sets the relevant AdminMessage element in the GUI.
        /// </summary>
        private void SetAdminMessage()
        {
            Message msg = messageHandler.GetNewestMessage(model);

            TBlockAdminMessageTitle.Text = msg.Header;
            TBlockAdminMessage.Text = msg.Text;
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateUiContent();
        }
    }
}
