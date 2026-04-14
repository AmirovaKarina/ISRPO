using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class FormFinish : Form
    {
        private int userId;
        private string firstName, lastName;

        public FormFinish(int userId, string firstName, string lastName)
        {
            InitializeComponent();
            this.userId = userId;
            this.firstName = firstName;
            this.lastName = lastName;
            LoadResult();
            LoadHistory();
        }

        private void LoadResult()
        {
            var user = DatabaseHelper.GetUserResult(userId);
            if (user != null)
            {
                double percent = (double)user.Score / 15 * 100;
                string grade;
                if (percent >= 80) grade = "Отлично";
                else if (percent >= 60) grade = "Хорошо";
                else if (percent >= 40) grade = "Удовлетворительно";
                else grade = "Попробуйте еще раз";

                lblResult.Text = $"Правильных ответов: {user.Score} из 15\n" +
                                 $"Результат: {percent:F1}% - {grade}";
            }
        }

        private void LoadHistory()
        {
            var history = DatabaseHelper.GetUserHistory(firstName, lastName);
            DataTable dt = new DataTable();
            dt.Columns.Add("Пользователь");
            dt.Columns.Add("Дата теста");
            dt.Columns.Add("Баллы");
            dt.Columns.Add("Время (сек)");

            foreach (var item in history)
            {
                dt.Rows.Add(item.FullName, item.TestDate.ToString("dd.MM.yyyy HH:mm"), item.Score, item.TimeSpentSeconds);
            }
            dgvHistory.DataSource = dt;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAgain_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы уверены, что хотите пройти тест заново? Текущий результат будет сохранен.",
                                          "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                FormStart startForm = new FormStart();
                startForm.Show();
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
