using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SimHopp.Model
{
    public struct User
    {
        public int userID;
        public string Username;
        public string Password;

        public User(int userID, string Username, string Password)
        {
            this.userID = userID;
            this.Username = Username;
            this.Password = Password;
        }
    }
    class Db
    {
        
        List<User> Valid_User = new List<User>();
        //public void LoginDB()
        public List<User> LoginDB()
        {
            try
            {
                SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder()
                {
                    DataSource = "simhoppdb.database.windows.net",
                    UserID = "SimHopp",
                    Password = "10helluworlD",
                    InitialCatalog = "SIMHOPP"
                };
                using (SqlConnection connection = new SqlConnection(connString.ConnectionString))
                {
                    connection.Open();
                    string Query = "SELECT * FROM [LoginProfile] p";

                    using (SqlCommand cmd = new SqlCommand(Query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User new_User = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                                Valid_User.Add(new_User);


                                //Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                            }
                        }

                    }
                    //foreach(User u in Valid_User)
                    //{
                    //    Console.WriteLine(u.userID + " " + u.Username + " " + u.Password);
                    //}
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return this.Valid_User;
        }
    }
}
