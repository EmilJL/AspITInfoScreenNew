using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspITInfoScreen.DAL
{
    public class Model /*: INotifyCollectionChanged*/
    {
        DbAccess dbAccess;
        public Model()
        {
            dbAccess = new DbAccess();
            Model model = dbAccess.GetDataAndCreateModel();
            Admins = model.Admins;
            LunchPlans = model.LunchPlans;
            Messages = model.Messages;
        }
        public Model(ObservableCollection<Admin> admins, ObservableCollection<LunchPlan> lunchPlans, ObservableCollection<Message> messages)
        {
            //dbAccess = new DbAccess();
            Admins = admins;
            LunchPlans = lunchPlans;
            Messages = messages;
            //Admins.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChanged);
            //LunchPlans.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChanged);
            //Messages.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChanged);
        }
        public ObservableCollection<Admin> Admins { get; private set; }
        public ObservableCollection<LunchPlan> LunchPlans { get; private set; }
        public ObservableCollection<Message> Messages { get; private set; }

        //public event NotifyCollectionChangedEventHandler CollectionChanged;

        //// MIGHT HAVE TO MAKE 3 DIFFERENT EVENTS, ONE FOR EACH COLLECTION (ObservableCollection<int> myCollection = sender as ObservableCollection<int>;)
        
        //private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    if (sender == Admins)
        //    {
        //        if (e.Action == NotifyCollectionChangedAction.Add)
        //        {
        //            foreach (var adm in e.NewItems)
        //            {
        //                dbAccess.AddAdmin(adm as Admin);
        //            }
        //        }
        //        else if (e.Action == NotifyCollectionChangedAction.Remove)
        //        {
        //            foreach (var adm in e.OldItems)
        //            {
        //                Admin admin = adm as Admin;
        //                dbAccess.DeleteAdmin(admin.Id);
        //            }
        //        }
        //    }
        //    else if (sender == LunchPlans)
        //    {
        //        if (e.Action == NotifyCollectionChangedAction.Add)
        //        {
        //            foreach (var lp in e.NewItems)
        //            {
        //                dbAccess.AddLunchPlan(lp as LunchPlan);
        //            }
        //        }
        //        else if (e.Action == NotifyCollectionChangedAction.Remove)
        //        {
        //            foreach (var lp in e.OldItems)
        //            {
        //                LunchPlan lunchPlan = lp as LunchPlan;
        //                dbAccess.DeleteLunchPlan(lunchPlan.Id);
        //            }
        //        }
        //    }
        //    else if (sender == Messages)
        //    {
        //        if (e.Action == NotifyCollectionChangedAction.Add)
        //        {
        //            foreach (var msg in e.NewItems)
        //            {
        //                dbAccess.AddMessage(msg as Message);
        //            }
        //        }
        //        else if (e.Action == NotifyCollectionChangedAction.Remove)
        //        {
        //            foreach (var msg in e.OldItems)
        //            {
        //                Message message = msg as Message;
        //                dbAccess.DeleteMessage(message.Id);
        //            }
        //        }
        //    }
        //}
    }
}
