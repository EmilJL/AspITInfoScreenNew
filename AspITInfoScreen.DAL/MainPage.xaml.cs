using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AspITInfoScreen.DAL
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static ObservableCollection<Admin> admins;
        static ObservableCollection<Message> messages;
        static ObservableCollection<LunchPlan> lunchPlans;
        static Model model;

        
        public MainPage()
        {
            this.InitializeComponent();
            admins = new ObservableCollection<Admin>();
            messages = new ObservableCollection<Message>();
            lunchPlans = new ObservableCollection<LunchPlan>();
            model = new Model(admins, lunchPlans, messages);
            //AddMes();
        }
        static void AddMes()
        {
            DbAccess da = new DbAccess();
            Random r = new Random();

            byte[] bytes = new byte[10];
            r.NextBytes(bytes);
            Admin admin = new Admin
            {
                Username = "Daniel",
                PasswordHash = bytes,
                PasswordSalt = bytes
            };
            admins.Add(admin);
            da.AddAdmin(admin);
            Message message = new Message
            {
                AdminId = 1,
                Date = DateTime.Now,
                Header = "En overskrift",
                Text = "En masse fucking lortetekst."
            };
            messages.Add(message);
            
            da.AddMessage(message);
        }
    }
}
