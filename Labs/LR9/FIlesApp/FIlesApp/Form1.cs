using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FIlesApp
{
    public partial class SimbolsCount : Form
    {
        private string connectionString = @"Server=WIN-07GTU19UB60\SQLEXPRESS;Initial Catalog=FileHistoryDB;Integrated Security=True;Encrypt=False";
        public SimbolsCount()
        {
            InitializeComponent();
            EnsureDatabaseAndTableExist();
        }

        private void EnsureDatabaseAndTableExist()
        {
            try
            {
                string masterConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Encrypt=False";
                using (var masterConn = new SqlConnection(masterConnectionString))
                {
                    masterConn.Open();
                    string checkDbQuery = $"SELECT database_id FROM sys.databases WHERE Name = 'FileHistoryDB'";
                    using (var cmd = new SqlCommand(checkDbQuery, masterConn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            string createDbQuery = $"CREATE DATABASE FileHistoryDB";
                            using (var createCmd = new SqlCommand(createDbQuery, masterConn))
                            {
                                createCmd.ExecuteNonQuery();
                                Debug.WriteLine($"База данных FileHistoryDB успешно создана.");
                            }
                        }
                    }
                }

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string checkTableQuery = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'FileOperations' AND xtype = 'U')
                    BEGIN
                        CREATE TABLE FileOperations (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            FilePath NVARCHAR(500),
                            Content NVARCHAR(MAX),
                            SymbolCount INT,
                            OperationType NVARCHAR(50),
                            OperationDate DATETIME DEFAULT GETDATE()
                        )
                    END";
                    using (var cmd = new SqlCommand(checkTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Debug.WriteLine("Таблица FileOperations проверена/создана.");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка при инициализации БД: {ex.Message}");
                MessageBox.Show($"Ошибка подключения к БД: {ex.Message}\nПроверьте, запущен ли SQL Server Express.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateCount()
        {
            txtCount.Text = txtText.Text.Length.ToString();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        txtPath.Text = openFileDialog.FileName;
                        string content = File.ReadAllText(openFileDialog.FileName);
                        txtText.Text = content;
                        UpdateCount();

                        SaveToDatabase(txtPath.Text, content, content.Length, "Open");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при открытии файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCountUp_Click(object sender, EventArgs e)
        {
            UpdateCount();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = txtPath.Text;
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            filePath = saveFileDialog.FileName;
                            txtPath.Text = filePath;
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                File.WriteAllText(filePath, txtText.Text);

                SaveToDatabase(filePath, txtText.Text, txtText.Text.Length, "Save");

                MessageBox.Show("Файл успешно сохранён.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtText.Clear();
            txtCount.Clear();
            txtPath.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void SaveToDatabase(string filePath, string content, int symbolCount, string operationType)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = $@"
                    INSERT INTO FileOperations (FilePath, Content, SymbolCount, OperationType)
                    VALUES (@FilePath, @Content, @SymbolCount, @OperationType)";
                    using (var command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FilePath", filePath ?? "Без пути");
                        command.Parameters.AddWithValue("@Content", content ?? "");
                        command.Parameters.AddWithValue("@SymbolCount", symbolCount);
                        command.Parameters.AddWithValue("@OperationType", operationType);
                        command.ExecuteNonQuery();
                    }
                }
                Debug.WriteLine($"Операция '{operationType}' сохранена в БД.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка при сохранении в БД: {ex.Message}");
            }
        }
    }
}
