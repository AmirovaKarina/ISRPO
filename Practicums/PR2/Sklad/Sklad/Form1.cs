using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Sklad
{
    public partial class Form1 : Form
    {
        private const string ConnectionString = @"Data source=WIN-07GTU19UB60\SQLEXPRESS;Initial Catalog=SkladDB;Integrated Security=True; TrustServerCertificate=true; Encrypt=true;";
        public Form1()
        {
            InitializeComponent(); LoadEquipment();
            LoadProductNames();
        }
        private void LoadEquipment()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT * from products";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
                }
            }
        }
        private void LoadProductNames()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT name from products";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    comboBox1.Items.Clear();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["name"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки наименований: {ex.Message}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM products WHERE id = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Товар успешно удален");
                        LoadEquipment();
                        LoadProductNames();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        conn.Open();

                        string query = @"INSERT INTO products (name, stillage, cell, quantity) 
                                    VALUES (@name, @stillage, @cell, @quantity)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@stillage", numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@cell", numericUpDown2.Value);
                        cmd.Parameters.AddWithValue("@quantity", numericUpDown3.Value);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Товар успешно добавлен");
                        LoadEquipment();
                        LoadProductNames();
                        textBox1.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка добавления: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите наименование товара");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
            saveFileDialog.Title = "Сохранить данные о товарах";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine("Наименование;Стеллаж;Ячейка;Количество");

                        
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                writer.WriteLine($"{row.Cells["name"].Value};{row.Cells["stillage"].Value};{row.Cells["cell"].Value};{row.Cells["quantity"].Value}");
                            }
                        }
                    }
                    MessageBox.Show("Данные успешно сохранены в CSV");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = @"UPDATE products 
                                       SET name = @name, stillage = @stillage, cell = @cell, quantity = @quantity 
                                       WHERE name = @name_2";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        
                        cmd.Parameters.AddWithValue("@name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@name_2", comboBox1.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@stillage", numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@cell", numericUpDown2.Value);
                        cmd.Parameters.AddWithValue("@quantity", numericUpDown3.Value);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Данные товара успешно обновлены");
                        LoadEquipment();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка обновления: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для изменения");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
            openFileDialog.Title = "Загрузить данные о товарах";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ClearDatabase();

                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        string line = reader.ReadLine();
                        while ((line = reader.ReadLine()) != null) 
                        {
                            string[] parts = line.Split(';');
                            if (parts.Length == 4)
                            {
                                
                                AddProductFromFile(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                            }
                        }
                    }

                    MessageBox.Show("Данные успешно загружены из CSV");
                    LoadEquipment();
                    LoadProductNames();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
                }
            }
        }
        private void ClearDatabase()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM products";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка очистки базы данных: {ex.Message}");
                }
            }
        }
        private void AddProductFromFile(string name, int stillage, int cell, int count)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"INSERT INTO products (name, stillage, cell, quantity) 
                                VALUES (@name, @stillage, @cell, @quantity)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@stillage", stillage);
                    cmd.Parameters.AddWithValue("@cell", cell);
                    cmd.Parameters.AddWithValue("@quantity", count);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка добавления товара: {ex.Message}");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        conn.Open();
                                     
                        string query = @"SELECT * FROM products WHERE name LIKE @name";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                        adapter.SelectCommand.Parameters.AddWithValue("@name", "%" + textBox2.Text + "%");

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns["id"].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка поиска: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите название для поиска");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT * FROM products 
                                   WHERE stillage = @stillage AND cell = @cell";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@stillage", numericUpDown4.Value);
                    adapter.SelectCommand.Parameters.AddWithValue("@cell", numericUpDown5.Value);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["id"].Visible = false;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Товары с указанными координатами не найдены");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка поиска: {ex.Message}");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        conn.Open(); 
                        string query = @"SELECT stillage, cell, quantity FROM products WHERE name = @name";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@name", comboBox1.SelectedItem.ToString());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                numericUpDown1.Value = Convert.ToDecimal(reader["stillage"]);
                                numericUpDown2.Value = Convert.ToDecimal(reader["cell"]);
                                numericUpDown3.Value = Convert.ToDecimal(reader["quantity"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки данных товара: {ex.Message}");
                    }
                }
            }
        }
    }
}
