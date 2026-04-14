namespace AlarmClock
{
    partial class AlarmEditDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dtpAlarmTime = new DateTimePicker();
            chkIsActive = new CheckBox();
            chkRepeatDaily = new CheckBox();
            txtLabel = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // dtpAlarmTime
            // 
            dtpAlarmTime.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            dtpAlarmTime.Format = DateTimePickerFormat.Time;
            dtpAlarmTime.Location = new Point(33, 41);
            dtpAlarmTime.Name = "dtpAlarmTime";
            dtpAlarmTime.ShowUpDown = true;
            dtpAlarmTime.Size = new Size(250, 30);
            dtpAlarmTime.TabIndex = 0;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            chkIsActive.Location = new Point(33, 93);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(97, 27);
            chkIsActive.TabIndex = 1;
            chkIsActive.Text = "Активен";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // chkRepeatDaily
            // 
            chkRepeatDaily.AutoSize = true;
            chkRepeatDaily.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            chkRepeatDaily.Location = new Point(33, 126);
            chkRepeatDaily.Name = "chkRepeatDaily";
            chkRepeatDaily.Size = new Size(210, 27);
            chkRepeatDaily.TabIndex = 2;
            chkRepeatDaily.Text = "Повторять ежедневно";
            chkRepeatDaily.UseVisualStyleBackColor = true;
            // 
            // txtLabel
            // 
            txtLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtLabel.Location = new Point(33, 172);
            txtLabel.Name = "txtLabel";
            txtLabel.Size = new Size(219, 30);
            txtLabel.TabIndex = 4;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnOK.Location = new Point(155, 247);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(101, 40);
            btnOK.TabIndex = 5;
            btnOK.Text = "ОК";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnCancel.Location = new Point(293, 247);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(101, 40);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AlarmEditDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 320);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtLabel);
            Controls.Add(chkRepeatDaily);
            Controls.Add(chkIsActive);
            Controls.Add(dtpAlarmTime);
            Name = "AlarmEditDialog";
            Text = "Настройка будильника";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpAlarmTime;
        private CheckBox chkIsActive;
        private CheckBox chkRepeatDaily;
        private TextBox txtLabel;
        private Button btnOK;
        private Button btnCancel;
    }
}