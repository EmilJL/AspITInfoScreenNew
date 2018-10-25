using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspITInfoScreen.DAL
{
    public class Admin : INotifyPropertyChanged
    {
        //public Admin()
        //{
        //             }
        public int Id { get; set; }
        private string username;
        private byte[] passwordSalt;
        private byte[] passwordHash;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }
        
        public byte[] PasswordSalt
        {
            get { return passwordSalt; }
            set
            {
                passwordSalt = value;
                NotifyPropertyChanged("PasswordSalt");
            }
        }
       

        public byte[] PasswordHash
        {
            get { return passwordHash; }
            set
            {
                passwordHash = value;
                NotifyPropertyChanged("PasswordHash");
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
