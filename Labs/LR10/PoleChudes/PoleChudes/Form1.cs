using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PoleChudes
{
    public partial class Form1 : Form
    {
        private string currentWord;
        private List<char> currentAnswer;
        private Stack<Button> undoStack;
        private List<Button> letterButtons;
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            currentAnswer = new List<char>();
            undoStack = new Stack<Button>();
            letterButtons = new List<Button>();

            LoadRandomWord();
        }
        private void LoadRandomWord()
        {
            string connectionString = @"Data Source=WIN-07GTU19UB60\SQLEXPRESS;Initial Catalog=PoleChudesDB;Integrated Security=True;Encrypt=False";
            string query = "SELECT TOP 1 Word FROM Words ORDER BY NEWID()";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    string word = cmd.ExecuteScalar()?.ToString().ToUpper();
                    if (string.IsNullOrEmpty(word))
                    {
                        MessageBox.Show("База данных не содержит слов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                        return;
                    }

                    currentWord = word.Replace('Ё', 'Е');
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            List<char> shuffledLetters = ShuffleLetters(currentWord);

            panelLetters.Controls.Clear();
            letterButtons.Clear();

            CreateLetterButtons(shuffledLetters);

            currentAnswer.Clear();
            undoStack.Clear();
            UpdateUI();
        }
        private List<char> ShuffleLetters(string word)
        {
            char[] letters = word.ToCharArray();
            Random rng = new Random();
            for (int i = letters.Length - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                char temp = letters[i];
                letters[i] = letters[j];
                letters[j] = temp;
            }
            return new List<char>(letters);
        }

        private void CreateLetterButtons(List<char> letters)
        {
            foreach (char ch in letters)
            {
                Button btn = new Button
                {
                    Text = ch.ToString(),
                    Width = 60,
                    Height = 60,
                    Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold),
                    Enabled = true,
                    Tag = ch
                };
                btn.Click += LetterButton_Click;
                panelLetters.Controls.Add(btn);
                letterButtons.Add(btn);
            }
        }
        private void LetterButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null || !btn.Enabled) return;

            currentAnswer.Add(btn.Text[0]);
            btn.Enabled = false;
            undoStack.Push(btn);
            UpdateUI();
        }
        private void UpdateUI()
        {
            string display = new string('_', currentWord.Length);

            if (currentAnswer.Count > 0)
                txtCurrentWord.Text = new string(currentAnswer.ToArray());
            else
                txtCurrentWord.Text = "";
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            LoadRandomWord();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (undoStack.Count == 0) return;

            Button lastButton = undoStack.Pop();
            if (currentAnswer.Count > 0)
                currentAnswer.RemoveAt(currentAnswer.Count - 1);
            lastButton.Enabled = true;
            UpdateUI();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckWord();
        }

        private void CheckWord()
        {
            string userWord = new string(currentAnswer.ToArray());
            if (userWord.Equals(currentWord, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Правильно! Слово угадано!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка! Попробуйте снова!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
