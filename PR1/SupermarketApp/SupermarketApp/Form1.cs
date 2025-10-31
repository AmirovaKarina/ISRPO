using System.Data;
using System.Text.RegularExpressions;

namespace SupermarketApp
{
    public partial class SpisokProduct : Form
    {
        public SpisokProduct()
        {
            InitializeComponent();
            fillComboBox();
        }

        private void fillComboBox()
        {
            cmbProducts.Items.Clear();
            string query = "select name, price from products order by name asc";
            DataTable table = DataBase.executeQuery(query);
            foreach (DataRow row in table.Rows)
            {
                cmbProducts.Items.Add($"{row.ItemArray[0]} - {row.ItemArray[1]:C}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedIndex != -1)
            {
                lsbSelectedProducts.Items.Add(cmbProducts.SelectedItem);
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            decimal total_price = 0m;
            foreach (var item in lsbSelectedProducts.Items)
            {
                var parts = Regex.Split(item.ToString(), @"\s-\s");
                total_price += Convert.ToDecimal(parts[1].Split(' ')[0]);
            }
            tbSum.Text = total_price.ToString("C");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lsbSelectedProducts.Items.Clear();
            tbSum.Text = "";
        }
    }
}
