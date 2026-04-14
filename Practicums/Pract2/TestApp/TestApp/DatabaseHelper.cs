using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public static class DatabaseHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        public static List<Question> GetQuestions()
        {
            var list = new List<Question>();
            string query = "SELECT Id, QuestionText, Option1, Option2, Option3, Option4, CorrectOption FROM Questions";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Question q = new Question
                    {
                        Id = reader.GetInt32(0),
                        Text = reader.GetString(1),
                        Options = new string[]
                        {
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5)
                        },
                        CorrectOption = reader.GetInt32(6)
                    };
                    list.Add(q);
                }
            }
            return list;
        }

        public static int InsertUser(string firstName, string lastName, DateTime testDate)
        {
            string query = "INSERT INTO Users (FirstName, LastName, TestDate, Score, TimeSpentSeconds) VALUES (@fn, @ln, @date, 0, 0); SELECT SCOPE_IDENTITY();";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fn", firstName);
                cmd.Parameters.AddWithValue("@ln", lastName);
                cmd.Parameters.AddWithValue("@date", testDate);
                conn.Open();
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                return newId;
            }
        }

        public static void UpdateUserResult(int userId, int score, int timeSpent)
        {
            string query = "UPDATE Users SET Score = @score, TimeSpentSeconds = @time WHERE Id = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@score", score);
                cmd.Parameters.AddWithValue("@time", timeSpent);
                cmd.Parameters.AddWithValue("@id", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void SaveUserAnswer(int userId, int questionId, int selectedOption, bool isCorrect)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string delete = "DELETE FROM UserAnswers WHERE UserId = @uid AND QuestionId = @qid";
                SqlCommand cmdDel = new SqlCommand(delete, conn);
                cmdDel.Parameters.AddWithValue("@uid", userId);
                cmdDel.Parameters.AddWithValue("@qid", questionId);
                cmdDel.ExecuteNonQuery();

                string insert = "INSERT INTO UserAnswers (UserId, QuestionId, SelectedAnswer, IsCorrect) VALUES (@uid, @qid, @sel, @cor)";
                SqlCommand cmdIns = new SqlCommand(insert, conn);
                cmdIns.Parameters.AddWithValue("@uid", userId);
                cmdIns.Parameters.AddWithValue("@qid", questionId);
                cmdIns.Parameters.AddWithValue("@sel", selectedOption);
                cmdIns.Parameters.AddWithValue("@cor", isCorrect);
                cmdIns.ExecuteNonQuery();
            }
        }

        public static int GetCorrectAnswersCount(int userId)
        {
            string query = "SELECT COUNT(*) FROM UserAnswers WHERE UserId = @uid AND IsCorrect = 1";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@uid", userId);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public static List<UserResult> GetUserHistory(string firstName, string lastName)
        {
            var list = new List<UserResult>();
            string query = "SELECT FirstName, LastName, TestDate, Score, TimeSpentSeconds FROM Users WHERE FirstName = @fn AND LastName = @ln ORDER BY TestDate DESC";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fn", firstName);
                cmd.Parameters.AddWithValue("@ln", lastName);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new UserResult
                    {
                        FullName = reader.GetString(0) + " " + reader.GetString(1),
                        TestDate = reader.GetDateTime(2),
                        Score = reader.GetInt32(3),
                        TimeSpentSeconds = reader.GetInt32(4)
                    });
                }
            }
            return list;
        }

        public static UserResult GetUserResult(int userId)
        {
            string query = "SELECT FirstName, LastName, TestDate, Score, TimeSpentSeconds FROM Users WHERE Id = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new UserResult
                    {
                        FullName = reader.GetString(0) + " " + reader.GetString(1),
                        TestDate = reader.GetDateTime(2),
                        Score = reader.GetInt32(3),
                        TimeSpentSeconds = reader.GetInt32(4)
                    };
                }
                return null;
            }
        }
    }
}
