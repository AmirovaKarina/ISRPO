namespace CurrConverter
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
            label5 = new Label();
            comboBoxFrom = new ComboBox();
            comboBoxTo = new ComboBox();
            textBoxAmount = new TextBox();
            textBoxResult = new TextBox();
            groupBox1 = new GroupBox();
            labelRates = new Label();
            buttonUpdate = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(30, 24);
            label1.Name = "label1";
            label1.Size = new Size(249, 38);
            label1.TabIndex = 0;
            label1.Text = "Конвертер валют";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(30, 108);
            label2.Name = "label2";
            label2.Size = new Size(34, 23);
            label2.TabIndex = 1;
            label2.Text = "Из:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(30, 190);
            label3.Name = "label3";
            label3.Size = new Size(23, 23);
            label3.TabIndex = 2;
            label3.Text = "В:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(30, 265);
            label4.Name = "label4";
            label4.Size = new Size(64, 23);
            label4.TabIndex = 3;
            label4.Text = "Сумма:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(30, 343);
            label5.Name = "label5";
            label5.Size = new Size(85, 23);
            label5.TabIndex = 4;
            label5.Text = "Результат:";
            // 
            // comboBoxFrom
            // 
            comboBoxFrom.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxFrom.FormattingEnabled = true;
            comboBoxFrom.Items.AddRange(new object[] { "RUB", "USD", "EUR", "CNY", "KRW" });
            comboBoxFrom.Location = new Point(230, 100);
            comboBoxFrom.Name = "comboBoxFrom";
            comboBoxFrom.Size = new Size(286, 31);
            comboBoxFrom.TabIndex = 5;
            comboBoxFrom.SelectedIndexChanged += OnCurrencyChanged;
            // 
            // comboBoxTo
            // 
            comboBoxTo.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            comboBoxTo.FormattingEnabled = true;
            comboBoxTo.Items.AddRange(new object[] { "RUB", "USD", "EUR", "CNY", "KRW" });
            comboBoxTo.Location = new Point(230, 182);
            comboBoxTo.Name = "comboBoxTo";
            comboBoxTo.Size = new Size(286, 31);
            comboBoxTo.TabIndex = 6;
            comboBoxTo.SelectedIndexChanged += OnCurrencyChanged;
            // 
            // textBoxAmount
            // 
            textBoxAmount.Location = new Point(230, 261);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(208, 27);
            textBoxAmount.TabIndex = 7;
            textBoxAmount.Text = "100";
            textBoxAmount.TextChanged += OnCurrencyChanged;
            textBoxAmount.KeyPress += OnAmountKeyPress;
            // 
            // textBoxResult
            // 
            textBoxResult.Location = new Point(230, 342);
            textBoxResult.Name = "textBoxResult";
            textBoxResult.ReadOnly = true;
            textBoxResult.Size = new Size(208, 27);
            textBoxResult.TabIndex = 8;
            textBoxResult.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelRates);
            groupBox1.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(30, 428);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(388, 173);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Курсы валют к RUB";
            // 
            // labelRates
            // 
            labelRates.AutoSize = true;
            labelRates.Font = new Font("Segoe UI Semilight", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelRates.Location = new Point(16, 42);
            labelRates.Name = "labelRates";
            labelRates.Size = new Size(57, 25);
            labelRates.TabIndex = 12;
            labelRates.Text = "label6";
            // 
            // buttonUpdate
            // 
            buttonUpdate.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonUpdate.Location = new Point(490, 495);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(168, 46);
            buttonUpdate.TabIndex = 11;
            buttonUpdate.Text = "Обновить курсы";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += OnUpdateRatesClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 640);
            Controls.Add(buttonUpdate);
            Controls.Add(groupBox1);
            Controls.Add(textBoxResult);
            Controls.Add(textBoxAmount);
            Controls.Add(comboBoxTo);
            Controls.Add(comboBoxFrom);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Конвертер валют";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBoxFrom;
        private ComboBox comboBoxTo;
        private TextBox textBoxAmount;
        private TextBox textBoxResult;
        private GroupBox groupBox1;
        private Label labelRates;
        private Button buttonUpdate;
    }
}
