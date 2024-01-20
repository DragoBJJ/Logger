using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using simpleLogger.Interfaces;


namespace simpleLogger.Database
{
    class MySqlDataBase : IDataBase

    {

        private readonly SqlConnection Connection;


        public MySqlDataBase()
        {

            try
            {
                string connectionString = new(ConfigurationManager.ConnectionStrings["CONNECTION_DB_STRING"].ConnectionString);
                Connection = new(connectionString);
                Console.WriteLine($"Create MySQL Instance, State connection is: {Connection.State}");


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public void AddLog(int userID, string name, string profession, string message)

        {
            try
            {
                using SqlConnection connection = Connection;
                Connection.Open();

                string query = $"INSERT INTO GameLogDB (id, name, profession, message) Values (@Value1, @Value2, @Value3, @Value4)";

                SqlCommand cmd = new(query, connection);

                cmd.Parameters.AddWithValue("@Value1", userID);
                cmd.Parameters.AddWithValue("@Value2", name);
                cmd.Parameters.AddWithValue("@Value3", profession);
                cmd.Parameters.AddWithValue("@Value4", message);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Console.WriteLine($"Successfully Added new Log to GameLogDB dataBase, State connection is: {Connection.State}");

        }

    }
}

