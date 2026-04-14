using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    public partial class AlarmEditDialog : Form
    {
        public AlarmEditDialog()
        {
            InitializeComponent();
        }
        public TimeSpan SelectedTime
        {
            get => dtpAlarmTime.Value.TimeOfDay;
            set => dtpAlarmTime.Value = DateTime.Today + value;
        }

        public string SelectedLabel
        {
            get => txtLabel.Text.Trim();
            set => txtLabel.Text = value ?? "";
        }

        public bool RepeatDaily
        {
            get => chkRepeatDaily.Checked;
            set => chkRepeatDaily.Checked = value;
        }
        public bool IsActive
        {
            get => chkIsActive.Checked;
            set => chkIsActive.Checked = value;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
