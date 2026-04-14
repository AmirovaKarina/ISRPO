namespace TestApp
{
    partial class FormStart
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            btnStart = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(210, 51);
            label1.Name = "label1";
            label1.Size = new Size(367, 50);
            label1.TabIndex = 0;
            label1.Text = "Добро пожаловать!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(132, 172);
            label2.Name = "label2";
            label2.Size = new Size(62, 31);
            label2.TabIndex = 1;
            label2.Text = "Имя:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semilight", 13.8F);
            label3.Location = new Point(132, 233);
            label3.Name = "label3";
            label3.Size = new Size(111, 31);
            label3.TabIndex = 2;
            label3.Text = "Фамилия:";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI Semilight", 13.8F);
            txtFirstName.Location = new Point(292, 169);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(317, 38);
            txtFirstName.TabIndex = 3;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI Semilight", 13.8F);
            txtLastName.Location = new Point(292, 226);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(317, 38);
            txtLastName.TabIndex = 4;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnStart.Location = new Point(292, 337);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(205, 65);
            btnStart.TabIndex = 5;
            btnStart.Text = "Начать тест";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // FormStart
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 457);
            Controls.Add(btnStart);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormStart";
            Text = "Начало тестирования";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Button btnStart;
    }
}
