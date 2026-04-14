using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Debugging;

namespace TestApp.Database
{
    public static class DatabaseTester
    {
        private const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=backpack;Trusted_Connection=True;";

        [Conditional("DEBUG")]
        public static void TestConnection()
        {
            try
            {
                DebugLogger.Log("Проверка подключения к базе данных...");
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    DebugLogger.Log("Подключение к базе данных успешно установлено");

                    string query = "SELECT COUNT(*) FROM objects";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        int count = (int)cmd.ExecuteScalar();
                        DebugLogger.Log($"В таблице objects найдено {count} записей");
                    }

                    string tablesQuery = @"
                        SELECT TABLE_NAME
                        FROM INFORMATION_SCHEMA.TABLES
                        WHERE TABLE_TYPE = 'BASE TABLE'";
                    using (var tablesCmd = new SqlCommand(tablesQuery, connection))
                    using (var reader = tablesCmd.ExecuteReader())
                    {
                        DebugLogger.Log("Доступные таблицы:");
                        while (reader.Read())
                        {
                            DebugLogger.Log($"  - {reader["TABLE_NAME"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DebugLogger.Log($"Ошибка подключения к БД: {ex.Message}");
                DebugLogger.Log($"Stack trace: {ex.StackTrace}");
            }
        }
    }
}
