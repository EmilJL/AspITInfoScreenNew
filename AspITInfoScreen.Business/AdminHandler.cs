using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspITInfoScreen.DAL;

namespace AspITInfoScreen.Business
{
    public class AdminHandler : DBHandler
    {
        
        //public AdminHandler()
        //{
        //    model = dbAccess.GetDataAndCreateModel();
        //}
        public Admin GetAdmin(int id)
        {
            Admin admin = Model.Admins.Where(m => m.Id == id).FirstOrDefault();
            return admin;
        }
        public bool AddAdmin(Admin admin)
        {
            try
            {
                DbAccess.AddAdmin(admin);
                Model.Admins.Add(admin);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
        public bool DeleteAdmin(int id)
        {
            try
            {
                DbAccess.DeleteAdmin(id);
                Model.Admins.RemoveAt(Model.Admins.IndexOf(Model.Admins.Where(m => m.Id == id).FirstOrDefault()));
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
