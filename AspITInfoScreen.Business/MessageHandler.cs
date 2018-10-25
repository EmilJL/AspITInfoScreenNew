using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspITInfoScreen.DAL;

namespace AspITInfoScreen.Business
{
    public class MessageHandler : DBHandler
    {
        public Message GetMessage(int id)
        {
            Message message = Model.Messages.Where(m => m.Id == id).FirstOrDefault();
            return message;
        }
        public bool AddMessage(Message message)
        {
            try
            {
                DbAccess.AddMessage(message);
                Model.Messages.Add(message);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
        public bool DeleteMessage(int id)
        {
            try
            {
                DbAccess.DeleteMessage(id);
                Model.Messages.RemoveAt(Model.Messages.IndexOf(Model.Messages.Where(m => m.Id == id).FirstOrDefault()));
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
