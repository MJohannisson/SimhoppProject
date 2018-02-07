using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SimHopp.Model
{
    class Db
    {
        void loginDB()
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

                            }
                        }

                    }
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}
