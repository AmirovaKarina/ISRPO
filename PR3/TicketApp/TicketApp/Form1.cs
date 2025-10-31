namespace TicketApp
{
    public partial class Form1 : Form
    {
        private Random random;
        public Form1()
        {
            InitializeComponent();
            label3.Text = "";
            label4.Text = "";
            this.random = new Random();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ticket = random.Next(100000, 1000000);
            bool isLucky = CheckTicket(ticket);

            if (isLucky)
            {
                label3.Text = $"Билет {ticket}";
                label4.Text = "Счастливый!";
                label3.ForeColor = Color.Green;
                label4.ForeColor = Color.Green;
            }
            else
            {
                label3.Text = $"Билет {ticket}";
                label4.Text = "Обычный...";
                label3.ForeColor = Color.Red;
                label4.ForeColor = Color.Red;
            }
        }

        private bool CheckTicket(int number)
        {
            int sumFstHalf = 0;
            int sumSecHalf = 0;
            for (int i = 5; i >= 0; i--)
            {
                int digit = number % 10;
                number = number / 10;

                if (i >= 3)
                {
                    sumFstHalf += digit;
                }
                else
                {
                    sumSecHalf += digit;
                }
            }
            return sumFstHalf == sumSecHalf;
        }
    }
}
