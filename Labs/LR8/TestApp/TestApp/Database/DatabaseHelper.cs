using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TestApp.Debugging;
using TestApp.Models;

namespace TestApp.Database
{
    public static class DatabaseHelper
    {
        private const string ConnectionString = @"Server=WIN-07GTU19UB60\SQLEXPRESS;Database=backpack;Trusted_Connection=True;Encrypt=False;";

        public static List<Item> LoadItems()
        {
            var items = new List<Item>();
            string query = "SELECT Id, Name, Weight, Cost FROM objects";

            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                DebugLogger.LogSqlQuery(query);
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new Item
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Weight = reader.GetInt32(2),
                                Cost = reader.GetInt32(3)
                            });
                        }
                    }
                    DebugLogger.LogItems(items, "Загружены предметы из БД");
                }
                catch (Exception ex)
                {
                    DebugLogger.Log($"Ошибка загрузки данных: {ex.Message}");
                    throw;
                }
            }
            return items;
        }
    }
}
