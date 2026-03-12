using System.Globalization;

namespace CurrConverter
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<string, decimal> exchangeRates = new Dictionary<string, decimal>
        {
            ["RUB"] = 1.00m,      // Российский рубль
            ["USD"] = 90.50m,     // Доллар США
            ["EUR"] = 98.20m,     // Евро
            ["CNY"] = 12.50m,     // Китайский юань
            ["KRW"] = 0.067m      // Южнокорейская вона
        };
        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }
        private void SetupForm()
        {
            comboBoxFrom.SelectedItem = "RUB";
            comboBoxTo.SelectedItem = "USD";

            UpdateRatesDisplay();

            ConvertCurrency();
        }

        private void UpdateRatesDisplay()
        {
            if (labelRates != null)
            {
                labelRates.Text =$"1 USD = {exchangeRates["USD"]:F2} RUB\n" +
                                 $"1 EUR = {exchangeRates["EUR"]:F2} RUB\n" +
                                 $"1 CNY = {exchangeRates["CNY"]:F2} RUB\n" +
                                 $"1 KRW = {exchangeRates["KRW"]:F4} RUB";
            }
        }
        private void ConvertCurrency()
        {
            if (textBoxResult == null) return;

            if (string.IsNullOrEmpty(textBoxAmount.Text))
            {
                textBoxResult.Text = "Введите сумму";
                return;
            }

            if (!decimal.TryParse(textBoxAmount.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amount))
            {
                textBoxResult.Text = "Некорректная сумма";
                return;
            }

            if (amount < 0)
            {
                textBoxResult.Text = "Сумма должна быть положительной";
                return;
            }

            if (comboBoxFrom.SelectedItem == null || comboBoxTo.SelectedItem == null)
            {
                textBoxResult.Text = "Выберите валюты";
                return;
            }

            string fromCurrency = comboBoxFrom.SelectedItem.ToString();
            string toCurrency = comboBoxTo.SelectedItem.ToString();

            decimal rateFrom = exchangeRates[fromCurrency];
            decimal rateTo = exchangeRates[toCurrency];

            decimal result = (amount * rateFrom) / rateTo;

            textBoxResult.Text = $"{result:F2}";
        }

        private void OnCurrencyChanged(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void OnAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void OnUpdateRatesClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Курсы валют фиксированные. Для изменения курсов требуется редактирование кода программы.",
                          "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public decimal Convert(decimal amount, string fromCurrency, string toCurrency)
        {
            if (!exchangeRates.ContainsKey(fromCurrency) || !exchangeRates.ContainsKey(toCurrency))
                throw new ArgumentException("Неподдерживаемая валюта");

            decimal rateFrom = exchangeRates[fromCurrency];
            decimal rateTo = exchangeRates[toCurrency];

            return (amount * rateFrom) / rateTo;
        }
    }
}

