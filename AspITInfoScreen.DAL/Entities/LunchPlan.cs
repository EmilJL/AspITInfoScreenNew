using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspITInfoScreen.DAL
{
    public class LunchPlan : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private DateTime date;
        private string meal;

        public string Meal
        {
            get { return meal; }
            set
            {
                meal = value;
                NotifyPropertyChanged("Meal");
            }
        }
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                NotifyPropertyChanged("Date");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
