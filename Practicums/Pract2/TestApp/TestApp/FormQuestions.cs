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
    public partial class FormQuestions : Form
    {
        private List<Question> questions;
        private int currentIndex = 0;
        private int userId;
        private string firstName, lastName;
        private DateTime startTime;
        private System.Windows.Forms.Timer timer;
        private Dictionary<int, int> selectedAnswers;

        public FormQuestions(int userId, string firstName, string lastName, DateTime startTime)
        {
            InitializeComponent();
            this.userId = userId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.startTime = startTime;

            selectedAnswers = new Dictionary<int, int>();
            LoadQuestions();
            SetupTimer();
            ShowQuestion(0);
        }

        private void LoadQuestions()
        {
            questions = DatabaseHelper.GetQuestions();
            if (questions.Count == 0)
            {
                MessageBox.Show("Нет вопросов в базе данных");
                Close();
            }
        }

        private void SetupTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - startTime;
            TimeSpan remaining = TimeSpan.FromMinutes(25) - elapsed;
            if (remaining.TotalSeconds <= 0)
            {
                timer.Stop();
                MessageBox.Show("Время вышло! Тест будет завершён.");
                FinishTest();
            }
            else
            {
                lblTimer.Text = remaining.ToString(@"mm\:ss");
            }
        }

        private void ShowQuestion(int index)
        {
            if (index < 0 || index >= questions.Count) return;

            Question q = questions[index];
            lblQuestion.Text = q.Text;
            rb1.Text = q.Options[0];
            rb2.Text = q.Options[1];
            rb3.Text = q.Options[2];
            rb4.Text = q.Options[3];

            if (selectedAnswers.ContainsKey(q.Id))
            {
                int sel = selectedAnswers[q.Id];
                rb1.Checked = (sel == 1);
                rb2.Checked = (sel == 2);
                rb3.Checked = (sel == 3);
                rb4.Checked = (sel == 4);
            }
            else
            {
                rb1.Checked = rb2.Checked = rb3.Checked = rb4.Checked = false;
            }

            lblQuestionNum.Text = $"Вопрос {index + 1} из {questions.Count}";
            btnPrev.Enabled = (index > 0);
            btnNext.Text = (index == questions.Count - 1) ? "Завершить" : "Далее";
        }

        private int GetSelectedOption()
        {
            if (rb1.Checked) return 1;
            if (rb2.Checked) return 2;
            if (rb3.Checked) return 3;
            if (rb4.Checked) return 4;
            return 0;
        }

        private void SaveCurrentAnswer()
        {
            int selected = GetSelectedOption();
            if (selected == 0) return;

            Question q = questions[currentIndex];
            bool isCorrect = (selected == q.CorrectOption);
            DatabaseHelper.SaveUserAnswer(userId, q.Id, selected, isCorrect);
            selectedAnswers[q.Id] = selected;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                SaveCurrentAnswer();
                currentIndex--;
                ShowQuestion(currentIndex);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (GetSelectedOption() == 0)
            {
                MessageBox.Show("Выберите ответ!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveCurrentAnswer();

            if (currentIndex == questions.Count - 1)
            {
                FinishTest();
            }
            else
            {
                currentIndex++;
                ShowQuestion(currentIndex);
            }
        }
        private void FinishTest()
        {
            timer.Stop();
            int correctCount = 0;
            foreach (var kvp in selectedAnswers)
            {
                Question q = questions.Find(x => x.Id == kvp.Key);
                if (q != null && kvp.Value == q.CorrectOption) correctCount++;
            }
            int timeSpent = (int)(DateTime.Now - startTime).TotalSeconds;
            DatabaseHelper.UpdateUserResult(userId, correctCount, timeSpent);

            this.Hide();
            using (FormFinish finishForm = new FormFinish(userId, firstName, lastName))
            {
                finishForm.ShowDialog();
            }
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timer?.Stop();
            base.OnFormClosing(e);
        }
    }
}
