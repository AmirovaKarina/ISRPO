namespace SupermarketApp
{
    partial class SpisokProduct
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
            cmbProducts = new ComboBox();
            btnAdd = new Button();
            lsbSelectedProducts = new ListBox();
            btnCalc = new Button();
            tbSum = new TextBox();
            btnClear = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(261, 32);
            label1.Name = "label1";
            label1.Size = new Size(280, 28);
            label1.TabIndex = 0;
            label1.Text = "Выберите продукты из списка:";
            // 
            // cmbProducts
            // 
            cmbProducts.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(261, 83);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(280, 31);
            cmbProducts.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI Semilight", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnAdd.Location = new Point(325, 136);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 45);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lsbSelectedProducts
            // 
            lsbSelectedProducts.Font = new Font("Segoe UI Semilight", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lsbSelectedProducts.FormattingEnabled = true;
            lsbSelectedProducts.ItemHeight = 25;
            lsbSelectedProducts.Location = new Point(261, 240);
            lsbSelectedProducts.Name = "lsbSelectedProducts";
            lsbSelectedProducts.Size = new Size(280, 204);
            lsbSelectedProducts.TabIndex = 3;
            // 
            // btnCalc
            // 
            btnCalc.Font = new Font("Segoe UI Semilight", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCalc.Location = new Point(60, 300);
            btnCalc.Name = "btnCalc";
            btnCalc.Size = new Size(152, 71);
            btnCalc.TabIndex = 4;
            btnCalc.Text = "Посчитать итог";
            btnCalc.UseVisualStyleBackColor = true;
            btnCalc.Click += btnCalc_Click;
            // 
            // tbSum
            // 
            tbSum.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            tbSum.Location = new Point(416, 487);
            tbSum.Name = "tbSum";
            tbSum.Size = new Size(125, 30);
            tbSum.TabIndex = 5;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI Semilight", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnClear.Location = new Point(600, 310);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(142, 50);
            btnClear.TabIndex = 6;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(239, 487);
            label2.Name = "label2";
            label2.Size = new Size(157, 28);
            label2.TabIndex = 7;
            label2.Text = "Итоговая сумма:";
            // 
            // SpisokProduct
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 547);
            Controls.Add(label2);
            Controls.Add(btnClear);
            Controls.Add(tbSum);
            Controls.Add(btnCalc);
            Controls.Add(lsbSelectedProducts);
            Controls.Add(btnAdd);
            Controls.Add(cmbProducts);
            Controls.Add(label1);
            Name = "SpisokProduct";
            Text = "Список продуктов";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbProducts;
        private Button btnAdd;
        private ListBox lsbSelectedProducts;
        private Button btnCalc;
        private TextBox tbSum;
        private Button btnClear;
        private Label label2;
    }
}
