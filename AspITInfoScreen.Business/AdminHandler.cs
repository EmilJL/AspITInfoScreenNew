using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspITInfoScreen.DAL;

namespace AspITInfoScreen.Business
{
    public class AdminHandler
    {
        private DbAccess dbAccess;
        private Model model;
        public AdminHandler()
        {
            dbAccess = new DbAccess();
            model = dbAccess.GetDataAndCreateModel();
        }
        public Admin GetAdmin(int id)
        {
            Admin admin = model.Admins.Where(m => m.Id == id).FirstOrDefault();
            return admin;
        }
        public bool AddAdmin(Admin admin)
        {
            try
            {
                dbAccess.AddAdmin(admin);
                model.Admins.Add(admin);
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
                dbAccess.DeleteAdmin(id);
                model.Admins.RemoveAt(model.Admins.IndexOf(model.Admins.Where(m => m.Id == id).FirstOrDefault()));
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
