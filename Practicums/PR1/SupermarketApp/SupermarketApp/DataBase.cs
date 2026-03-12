using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketApp
{
    internal class DataBase
    {
        private static SqlConnection connection = new SqlConnection(@"Data source=WIN-07GTU19UB60\SQLEXPRESS;Initial Catalog=SupermarketDB;Integrated Security=True; TrustServerCertificate=true; Encrypt=true;");
        private static SqlDataAdapter adapter = new SqlDataAdapter();

        public static void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public static void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static SqlConnection getConnection()
        {
            return connection;
        }

        public static DataTable executeQuery(string query)
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(query, connection);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public static void executeNonQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }
    }
}
