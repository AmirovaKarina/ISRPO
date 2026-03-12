namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbLang.SelectedIndex = 0;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;
            string inputText = textBoxText.Text;
            int shift = (int)numericUpDown1.Value;
            string lang = cmbLang.SelectedItem.ToString();
            textBoxResult.Text = CeasarCipher(inputText, shift, lang);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;
            string inputText = textBoxText.Text;
            int shift = (int)numericUpDown1.Value;
            string lang = cmbLang.SelectedItem.ToString();
            textBoxResult.Text = CeasarCipher(inputText, -shift, lang);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxText.Text))
            {
                MessageBox.Show("Введите текст для шифрования!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private string CeasarCipher(string text, int shift, string lang)
        {
            string result = "";
            string alphabet = "";
            int alphabetSize = 0;
            if (lang == "Русский")
            {
                alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                alphabetSize = 32;
            }
            else
            {
                alphabet = "abcdifghigklmnopqrstuvwxyz";
                alphabetSize = 26;
            }
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    bool isUpper = char.IsUpper(c);
                    char lowerChar = char.ToLower(c);
                    int index = alphabet.IndexOf(lowerChar);
                    if (index != -1)
                    {
                        int newIndex = (index + shift) % alphabetSize;
                        if (newIndex < 0)
                        {
                            newIndex += alphabetSize;
                        }
                        char newChar = alphabet[newIndex];
                        result += isUpper ? char.ToUpper(newChar) : newChar;
                    }
                    else
                    {
                        result += c;
                    }
                }
                else
                {
                    result += c;
                }
            }
            return result;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxText.Text = "";
            textBoxResult.Text = "";
        }
    }
}
