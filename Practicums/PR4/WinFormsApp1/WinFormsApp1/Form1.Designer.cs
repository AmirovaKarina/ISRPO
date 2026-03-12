namespace WinFormsApp1
{
    partial class Form1
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
            label4 = new Label();
            textBoxText = new TextBox();
            textBoxResult = new TextBox();
            cmbLang = new ComboBox();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            btnClear = new Button();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 10.2F);
            label1.Location = new Point(70, 50);
            label1.Name = "label1";
            label1.Size = new Size(132, 23);
            label1.TabIndex = 0;
            label1.Text = "Исходный текст";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 10.2F);
            label2.Location = new Point(70, 233);
            label2.Name = "label2";
            label2.Size = new Size(81, 23);
            label2.TabIndex = 1;
            label2.Text = "Результат";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semilight", 10.2F);
            label3.Location = new Point(48, 443);
            label3.Name = "label3";
            label3.Size = new Size(48, 23);
            label3.TabIndex = 2;
            label3.Text = "Язык";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semilight", 10.2F);
            label4.Location = new Point(287, 443);
            label4.Name = "label4";
            label4.Size = new Size(55, 23);
            label4.TabIndex = 3;
            label4.Text = "Сдвиг";
            // 
            // textBoxText
            // 
            textBoxText.Location = new Point(287, 50);
            textBoxText.Multiline = true;
            textBoxText.Name = "textBoxText";
            textBoxText.ScrollBars = ScrollBars.Vertical;
            textBoxText.Size = new Size(665, 149);
            textBoxText.TabIndex = 4;
            // 
            // textBoxResult
            // 
            textBoxResult.Location = new Point(287, 233);
            textBoxResult.Multiline = true;
            textBoxResult.Name = "textBoxResult";
            textBoxResult.ReadOnly = true;
            textBoxResult.ScrollBars = ScrollBars.Vertical;
            textBoxResult.Size = new Size(665, 149);
            textBoxResult.TabIndex = 5;
            // 
            // cmbLang
            // 
            cmbLang.Font = new Font("Segoe UI Semilight", 9F);
            cmbLang.FormattingEnabled = true;
            cmbLang.Items.AddRange(new object[] { "Русский", "Английский" });
            cmbLang.Location = new Point(102, 442);
            cmbLang.Name = "cmbLang";
            cmbLang.Size = new Size(151, 28);
            cmbLang.TabIndex = 6;
            // 
            // btnEncrypt
            // 
            btnEncrypt.Font = new Font("Segoe UI Semilight", 10.2F);
            btnEncrypt.Location = new Point(532, 437);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(159, 34);
            btnEncrypt.TabIndex = 8;
            btnEncrypt.Text = "Зашифровать";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Font = new Font("Segoe UI Semilight", 10.2F);
            btnDecrypt.Location = new Point(714, 437);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(160, 34);
            btnDecrypt.TabIndex = 9;
            btnDecrypt.Text = "Расшифровать";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI Semilight", 10.2F);
            btnClear.Location = new Point(899, 437);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(114, 34);
            btnClear.TabIndex = 10;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI Semilight", 9F);
            numericUpDown1.Location = new Point(348, 443);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1104, 511);
            Controls.Add(btnClear);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(numericUpDown1);
            Controls.Add(cmbLang);
            Controls.Add(textBoxResult);
            Controls.Add(textBoxText);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Шифр Цезаря";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBoxText;
        private TextBox textBoxResult;
        private ComboBox cmbLang;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private Button btnClear;
        private NumericUpDown numericUpDown1;
    }
}
