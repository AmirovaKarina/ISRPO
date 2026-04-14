using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Linq;
using Timer = System.Windows.Forms.Timer;

namespace AlarmClock
{
    public partial class AlarmForm : Form
    {
        private readonly string connectionString = @"Data Source=WIN-07GTU19UB60\SQLEXPRESS;Initial Catalog=AlarmClockDB;Integrated Security=True;TrustServerCertificate=True;";
        private List<AlarmItem> alarms = new List<AlarmItem>();
        private AlarmItem ringingAlarm = null;

        private Timer timerCurrentTime;
        private Timer timerCheckAlarms;
        private Timer timerBlink;
        private Timer timerSound;
        public AlarmForm()
        {
            InitializeComponent();
        }

        private void AlarmForm_Load(object sender, EventArgs e)
        {
            LoadAlarms();
            InitializeTimers();
            dgvAlarms.AutoGenerateColumns = false;
            dgvAlarms.CellValueChanged += dgvAlarms_CellValueChanged;
        }
        private void InitializeTimers()
        {
            timerCurrentTime = new Timer { Interval = 1000 };
            timerCurrentTime.Tick += TimerCurrentTime_Tick;
            timerCurrentTime.Start();

            timerCheckAlarms = new Timer { Interval = 1000 };
            timerCheckAlarms.Tick += TimerCheckAlarms_Tick;
            timerCheckAlarms.Start();

            timerBlink = new Timer { Interval = 500 };
            timerBlink.Tick += TimerBlink_Tick;

            timerSound = new Timer { Interval = 1500 };
            timerSound.Tick += TimerSound_Tick;
        }
        private void TimerCurrentTime_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblCurrentDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void TimerCheckAlarms_Tick(object sender, EventArgs e)
        {
            if (ringingAlarm != null) return;

            var now = DateTime.Now;
            AlarmItem triggered = alarms.FirstOrDefault(a =>
                a.IsActive &&
                a.Time.Hours == now.Hour &&
                a.Time.Minutes == now.Minute);

            if (triggered != null)
            {
                ringingAlarm = triggered;
                StartRinging();
            }
        }

        private void StartRinging()
        {
            pnlRinging.Visible = true;
            string info = string.IsNullOrEmpty(ringingAlarm.Label) ? "" : " " + ringingAlarm.Label;
            lblRingingText.Text = "Будильник звенит!" + info;
            timerBlink.Start();
            timerSound.Start();
        }

        private void StopRinging()
        {
            pnlRinging.Visible = false;
            timerBlink.Stop();
            timerSound.Stop();
            ringingAlarm = null;
        }

        private void TimerBlink_Tick(object sender, EventArgs e)
        {
            lblRingingText.BackColor = (lblRingingText.BackColor == Color.Red) ? Color.Yellow : Color.Red;
        }

        private void TimerSound_Tick(object sender, EventArgs e)
        {
            SystemSounds.Exclamation.Play();
        }

        private void LoadAlarms()
        {
            alarms.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(
                        @"SELECT 
                    Id, 
                    AlarmTime,
                    CONVERT(varchar(5), AlarmTime, 108) AS DisplayTime,
                    IsActive, 
                    RepeatDaily, 
                    Label, 
                    CreatedDate 
                  FROM Alarms 
                  ORDER BY AlarmTime",
                        conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvAlarms.DataSource = dt;

                    dgvAlarms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgvAlarms.Columns["Id"].Visible = false;
                    dgvAlarms.Columns["AlarmTime"].Visible = false;
                    dgvAlarms.Columns["RepeatDaily"].Visible = false;
                    dgvAlarms.Columns["CreatedDate"].Visible = false;

                    dgvAlarms.Columns["DisplayTime"].HeaderText = "Время";
                    dgvAlarms.Columns["DisplayTime"].Width = 100;

                    dgvAlarms.Columns["IsActive"].HeaderText = "Активен";
                    dgvAlarms.Columns["IsActive"].Width = 80;
                    dgvAlarms.Columns["IsActive"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                 
                    dgvAlarms.Columns["Label"].HeaderText = "Название";
                    dgvAlarms.Columns["Label"].Width = 250;
                    dgvAlarms.Columns["Label"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    dgvAlarms.ReadOnly = false;
                    foreach (DataGridViewColumn col in dgvAlarms.Columns)
                    {
                        if (col.Name != "IsActive")
                            col.ReadOnly = true;
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        alarms.Add(new AlarmItem
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Time = (TimeSpan)row["AlarmTime"],
                            IsActive = Convert.ToBoolean(row["IsActive"]),
                            RepeatDaily = Convert.ToBoolean(row["RepeatDaily"]),
                            Label = row["Label"] != DBNull.Value ? row["Label"].ToString() : ""
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения к БД: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvAlarms_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAlarms.Columns["IsActive"].Index && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvAlarms.Rows[e.RowIndex].Cells["Id"].Value);
                bool isActive = Convert.ToBoolean(dgvAlarms.Rows[e.RowIndex].Cells["IsActive"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Alarms SET IsActive = @IsActive WHERE Id = @ID", conn);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }

                LoadAlarms();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AlarmEditDialog dialog = new AlarmEditDialog())
            {
                dialog.IsActive = true;   // по умолчанию активен

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Alarms (AlarmTime, IsActive, RepeatDaily, Label, CreatedDate) " +
                            "VALUES (@Time, @IsActive, @RepeatDaily, @Label, GETDATE())",
                            conn);
                        cmd.Parameters.AddWithValue("@Time", dialog.SelectedTime);
                        cmd.Parameters.AddWithValue("@IsActive", dialog.IsActive);
                        cmd.Parameters.AddWithValue("@RepeatDaily", dialog.RepeatDaily);
                        cmd.Parameters.AddWithValue("@Label", string.IsNullOrEmpty(dialog.SelectedLabel) ? DBNull.Value : (object)dialog.SelectedLabel);
                        cmd.ExecuteNonQuery();
                    }
                    LoadAlarms();
                    MessageBox.Show("Будильник успешно добавлен!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAlarms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите будильник для редактирования!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvAlarms.SelectedRows[0].Cells["Id"].Value);
            AlarmItem selected = alarms.FirstOrDefault(a => a.Id == id);
            if (selected == null) return;

            using (AlarmEditDialog dialog = new AlarmEditDialog())
            {
                dialog.SelectedTime = selected.Time;
                dialog.SelectedLabel = selected.Label;
                dialog.RepeatDaily = selected.RepeatDaily;
                dialog.IsActive = selected.IsActive;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(
                            "UPDATE Alarms SET AlarmTime = @Time, IsActive = @IsActive, " +
                            "RepeatDaily = @RepeatDaily, Label = @Label WHERE Id = @ID", conn);
                        cmd.Parameters.AddWithValue("@Time", dialog.SelectedTime);
                        cmd.Parameters.AddWithValue("@IsActive", dialog.IsActive);
                        cmd.Parameters.AddWithValue("@RepeatDaily", dialog.RepeatDaily);
                        cmd.Parameters.AddWithValue("@Label", string.IsNullOrEmpty(dialog.SelectedLabel) ? DBNull.Value : (object)dialog.SelectedLabel);
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.ExecuteNonQuery();
                    }
                    LoadAlarms();
                    MessageBox.Show("Будильник успешно обновлён!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAlarms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите будильник для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvAlarms.SelectedRows[0].Cells["Id"].Value);

            if (MessageBox.Show("Удалить выбранный будильник?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Alarms WHERE Id = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
                LoadAlarms();
            }
        }

        private void btnSnooze_Click(object sender, EventArgs e)
        {
            if (ringingAlarm == null) return;

            TimeSpan newTime = DateTime.Now.AddMinutes(5).TimeOfDay;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Alarms SET AlarmTime = @NewTime WHERE Id = @ID", conn);
                cmd.Parameters.AddWithValue("@NewTime", newTime);
                cmd.Parameters.AddWithValue("@ID", ringingAlarm.Id);
                cmd.ExecuteNonQuery();
            }

            StopRinging();
            LoadAlarms();
        }

        private void btnStopAlarm_Click(object sender, EventArgs e)
        {
            if (ringingAlarm != null && !ringingAlarm.RepeatDaily)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Alarms SET IsActive = 0 WHERE Id = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID", ringingAlarm.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            StopRinging();
            LoadAlarms();
        }
        private class AlarmItem
        {
            public int Id { get; set; }
            public TimeSpan Time { get; set; }
            public bool IsActive { get; set; }
            public bool RepeatDaily { get; set; }
            public string Label { get; set; }
        }
    }
}
