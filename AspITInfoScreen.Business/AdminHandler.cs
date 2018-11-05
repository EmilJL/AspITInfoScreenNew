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
        public Admin GetAdmin(int id)
        {
            Admin admin = Model.Admins.Where(m => m.Id == id).FirstOrDefault();
            return admin;
        }
    }
}
