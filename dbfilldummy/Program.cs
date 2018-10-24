using System;
using System.Collections.ObjectModel;
using AspITInfoScreen.DAL;

namespace dbfilldummy
{
    public class Program
    {
        static ObservableCollection<Admin> admins;
        static ObservableCollection<Message> messages; 
        static ObservableCollection<LunchPlan> lunchPlans;
        static Model model;
        static void Main(string[] args)
        {
            admins = new ObservableCollection<Admin>();
            messages = new ObservableCollection<Message>();
            lunchPlans = new ObservableCollection<LunchPlan>();
            model = new Model(admins, lunchPlans, messages);
            AddMessages();
            Console.ReadKey();
        }
        static void AddMessages()
        {
            Message message = new Message
            {
                AdminId = 1,
                Date = DateTime.Now,
                Header = "En overskrift",
                Text = "En masse fucking lortetekst."
            };
            messages.Add(message);
        }
    }
}
