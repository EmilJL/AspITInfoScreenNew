using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspITInfoScreen.DAL
{
    public class Model
    {
        public Model(ObservableCollection<Admin> admins, ObservableCollection<LunchPlan> lunchPlans, ObservableCollection<Message> messages)
        {
            Admins = admins;
            LunchPlans = lunchPlans;
            Messages = messages;
        }
        public ObservableCollection<Admin> Admins { get; private set; }
        public ObservableCollection<LunchPlan> LunchPlans { get; private set; }
        public ObservableCollection<Message> Messages { get; private set; }
    }
}
