using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspITInfoScreen.DAL
{
    public class DbAccess
    {
        private const string connectionString = @"Data Source=cvdb3,1488;Initial Catalog=DAHO.AspITInfoScreen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Model GetDataAndCreateModel()
        {
            const string GetAdminsQuery = "SELECT * from Admins";
            const string GetLunchPlansQuery = "SELECT * from LunchPlans";
            const string GetMessagesQuery = "SELECT * from Messages";
            var admins = new ObservableCollection<Admin>();
            var lunchPlans = new ObservableCollection<LunchPlan>();
            var messages = new ObservableCollection<Message>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetAdminsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var admin = new Admin();
                                    admin.Id = reader.GetInt32(0);
                                    admin.Username = reader.GetString(1);
                                    admin.PasswordSalt = (byte[])reader.GetValue(2);
                                    admin.PasswordHash = (byte[])reader.GetValue(3);
                                    admins.Add(admin);
                                }
                            }
                            cmd.CommandText = GetLunchPlansQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var lunchPlan = new LunchPlan();
                                    lunchPlan.Id = reader.GetInt32(0);
                                    lunchPlan.Date = reader.GetDateTime(1);
                                    lunchPlan.Meal = reader.GetString(2);
                                    lunchPlans.Add(lunchPlan);
                                }
                            }
                            cmd.CommandText = GetMessagesQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var message = new Message();
                                    message.Id = reader.GetInt32(0);
                                    message.AdminId = reader.GetInt32(1);
                                    message.Date = reader.GetDateTime(2);
                                    message.Text = reader.GetString(3);
                                    message.Header = reader.GetString(4);
                                    messages.Add(message);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            Model model = new Model(admins, lunchPlans, messages);
            return model;
        }
    }
}
