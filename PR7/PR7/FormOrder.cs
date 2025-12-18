using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PR7.Models;

namespace PR7
{
    public partial class FormOrder : Form
    {
        private Book selectedBook;
        private DatabaseHelper db;
        private decimal price = 0;

        public FormOrder(Book book, DatabaseHelper databaseHelper)
        {
            InitializeComponent();
            selectedBook = book;
            db = databaseHelper;
            LoadOffices();
            DisplayBookInfo();
            CalculatePrice();
        }

        private void DisplayBookInfo()
        {
            label1.Text = selectedBook.Title;
            label2.Text = selectedBook.AuthorName;
            
        }

        private void LoadOffices()
        {
            try
            {
                var offices = db.GetOffices();
                comboBoxOffice.DataSource = offices;
                comboBoxOffice.DisplayMember = "Name";
                comboBoxOffice.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки офисов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxCustomerName.Text))
                {
                    MessageBox.Show("Введите ФИО клиента!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string prices = labelPrice.Text;
                string customerName = textBoxCustomerName.Text.Trim();
                string officeName = "";
                if (comboBoxOffice.SelectedItem != null)
                {
                    var selectedOffice = (Office)comboBoxOffice.SelectedItem;
                    officeName = selectedOffice.Name;  
                }

                var customer = new Customer
                {
                    Name = customerName,
                    Address = textBoxAddress.Text,
                    Phone = textBoxPhone.Text
                };

                int customerId = db.CreateCustomer(customer);

                var order = new Order
                {
                    Name = $"Предзаказ {selectedBook.Title}",
                    Customer = customerId,
                    Type = 1,
                    Publication = selectedBook.Id,
                    Office = (int)comboBoxOffice.SelectedValue,
                    DateOfAdmission = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    DateOfCompletion = null,
                    Price = labelPrice.Text,
                    BookTitle = selectedBook.Title
                };

                int orderId = db.CreateOrder(order);

                FormReceipt receiptForm = new FormReceipt(orderId, db, selectedBook.Title, customerName, officeName);
                receiptForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка оформления заказа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void CalculatePrice()
        {
            try
            {
                decimal basePrice = selectedBook.Pages * 5m;
                price = basePrice;
                labelPrice.Text = $"Итого: {price} руб.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка расчета цены: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
