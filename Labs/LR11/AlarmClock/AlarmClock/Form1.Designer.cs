namespace AlarmClock
{
    partial class AlarmForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblCurrentTime = new Label();
            lblCurrentDate = new Label();
            dgvAlarms = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            pnlRinging = new Panel();
            btnStopAlarm = new Button();
            btnSnooze = new Button();
            lblRingingText = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAlarms).BeginInit();
            pnlRinging.SuspendLayout();
            SuspendLayout();
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblCurrentTime.Location = new Point(309, 48);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(118, 50);
            lblCurrentTime.TabIndex = 0;
            lblCurrentTime.Text = "label1";
            // 
            // lblCurrentDate
            // 
            lblCurrentDate.AutoSize = true;
            lblCurrentDate.Font = new Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblCurrentDate.Location = new Point(299, 115);
            lblCurrentDate.Name = "lblCurrentDate";
            lblCurrentDate.Size = new Size(113, 46);
            lblCurrentDate.TabIndex = 1;
            lblCurrentDate.Text = "label2";
            // 
            // dgvAlarms
            // 
            dgvAlarms.AllowUserToAddRows = false;
            dgvAlarms.AllowUserToDeleteRows = false;
            dgvAlarms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlarms.Location = new Point(33, 247);
            dgvAlarms.Name = "dgvAlarms";
            dgvAlarms.ReadOnly = true;
            dgvAlarms.RowHeadersWidth = 51;
            dgvAlarms.Size = new Size(728, 229);
            dgvAlarms.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI Semilight", 10.8F);
            btnAdd.Location = new Point(74, 182);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(138, 43);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI Semilight", 10.8F);
            btnEdit.Location = new Point(291, 182);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(171, 43);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI Semilight", 10.8F);
            btnDelete.Location = new Point(551, 182);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(138, 43);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // pnlRinging
            // 
            pnlRinging.BackColor = Color.Red;
            pnlRinging.Controls.Add(btnStopAlarm);
            pnlRinging.Controls.Add(btnSnooze);
            pnlRinging.Controls.Add(lblRingingText);
            pnlRinging.Location = new Point(0, 498);
            pnlRinging.Name = "pnlRinging";
            pnlRinging.Size = new Size(796, 172);
            pnlRinging.TabIndex = 6;
            pnlRinging.Visible = false;
            // 
            // btnStopAlarm
            // 
            btnStopAlarm.BackColor = Color.Gold;
            btnStopAlarm.Location = new Point(451, 100);
            btnStopAlarm.Name = "btnStopAlarm";
            btnStopAlarm.Size = new Size(152, 56);
            btnStopAlarm.TabIndex = 2;
            btnStopAlarm.Text = "Выключить";
            btnStopAlarm.UseVisualStyleBackColor = false;
            btnStopAlarm.Click += btnStopAlarm_Click;
            // 
            // btnSnooze
            // 
            btnSnooze.BackColor = Color.Gold;
            btnSnooze.Location = new Point(165, 100);
            btnSnooze.Name = "btnSnooze";
            btnSnooze.Size = new Size(151, 56);
            btnSnooze.TabIndex = 1;
            btnSnooze.Text = "Отложить (5 мин)";
            btnSnooze.UseVisualStyleBackColor = false;
            btnSnooze.Click += btnSnooze_Click;
            // 
            // lblRingingText
            // 
            lblRingingText.AutoSize = true;
            lblRingingText.BackColor = Color.Red;
            lblRingingText.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblRingingText.ForeColor = Color.Gold;
            lblRingingText.Location = new Point(277, 31);
            lblRingingText.Name = "lblRingingText";
            lblRingingText.Size = new Size(218, 31);
            lblRingingText.TabIndex = 0;
            lblRingingText.Text = "Будильник звенит!";
            // 
            // AlarmForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 666);
            Controls.Add(pnlRinging);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvAlarms);
            Controls.Add(lblCurrentDate);
            Controls.Add(lblCurrentTime);
            Name = "AlarmForm";
            Text = "Будильник";
            Load += AlarmForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAlarms).EndInit();
            pnlRinging.ResumeLayout(false);
            pnlRinging.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCurrentTime;
        private Label lblCurrentDate;
        private DataGridView dgvAlarms;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Panel pnlRinging;
        private Button btnStopAlarm;
        private Button btnSnooze;
        private Label lblRingingText;
    }
}
