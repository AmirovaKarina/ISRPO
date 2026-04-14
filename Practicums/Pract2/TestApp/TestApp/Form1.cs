namespace TestApp
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("¬ведите им€ и фамилию", "ќшибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime testStart = DateTime.Now;
            int userId = DatabaseHelper.InsertUser(txtFirstName.Text.Trim(), txtLastName.Text.Trim(), testStart);

            FormQuestions frmQuestions = new FormQuestions(userId, txtFirstName.Text.Trim(), txtLastName.Text.Trim(), testStart);
            frmQuestions.FormClosed += (s, args) => this.Show();
            frmQuestions.Show();
            this.Hide();
        }
    }
}

