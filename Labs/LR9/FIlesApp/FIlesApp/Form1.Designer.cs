namespace FIlesApp
{
    partial class SimbolsCount
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
            btnOpen = new Button();
            btnCountUp = new Button();
            btnSave = new Button();
            btnClear = new Button();
            btnExit = new Button();
            lblInfo1 = new Label();
            lblInfo2 = new Label();
            txtText = new TextBox();
            txtPath = new TextBox();
            txtCount = new TextBox();
            SuspendLayout();
            // 
            // btnOpen
            // 
            btnOpen.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnOpen.Location = new Point(15, 24);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(122, 39);
            btnOpen.TabIndex = 0;
            btnOpen.Text = "Открыть";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnCountUp
            // 
            btnCountUp.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCountUp.Location = new Point(172, 24);
            btnCountUp.Name = "btnCountUp";
            btnCountUp.Size = new Size(122, 39);
            btnCountUp.TabIndex = 1;
            btnCountUp.Text = "Подсчитать";
            btnCountUp.UseVisualStyleBackColor = true;
            btnCountUp.Click += btnCountUp_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSave.Location = new Point(334, 24);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(122, 39);
            btnSave.TabIndex = 2;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnClear.Location = new Point(503, 24);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(122, 39);
            btnClear.TabIndex = 3;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnExit.Location = new Point(657, 24);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(122, 39);
            btnExit.TabIndex = 4;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblInfo1
            // 
            lblInfo1.AutoSize = true;
            lblInfo1.Font = new Font("Segoe UI Semilight", 10.2F);
            lblInfo1.Location = new Point(26, 98);
            lblInfo1.Name = "lblInfo1";
            lblInfo1.Size = new Size(353, 23);
            lblInfo1.TabIndex = 5;
            lblInfo1.Text = "Введите текст или выберите файл с текстом";
            // 
            // lblInfo2
            // 
            lblInfo2.AutoSize = true;
            lblInfo2.Font = new Font("Segoe UI Semilight", 10.2F);
            lblInfo2.Location = new Point(26, 412);
            lblInfo2.Name = "lblInfo2";
            lblInfo2.Size = new Size(248, 23);
            lblInfo2.TabIndex = 6;
            lblInfo2.Text = "Количество символов в тексте";
            // 
            // txtText
            // 
            txtText.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtText.Location = new Point(26, 179);
            txtText.Multiline = true;
            txtText.Name = "txtText";
            txtText.ScrollBars = ScrollBars.Vertical;
            txtText.Size = new Size(756, 200);
            txtText.TabIndex = 7;
            // 
            // txtPath
            // 
            txtPath.Font = new Font("Segoe UI Semilight", 9F);
            txtPath.Location = new Point(26, 134);
            txtPath.Name = "txtPath";
            txtPath.ReadOnly = true;
            txtPath.Size = new Size(756, 27);
            txtPath.TabIndex = 8;
            // 
            // txtCount
            // 
            txtCount.Font = new Font("Segoe UI Semilight", 9F);
            txtCount.Location = new Point(26, 448);
            txtCount.Name = "txtCount";
            txtCount.ReadOnly = true;
            txtCount.Size = new Size(248, 27);
            txtCount.TabIndex = 9;
            // 
            // SimbolsCount
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 498);
            Controls.Add(txtCount);
            Controls.Add(txtPath);
            Controls.Add(txtText);
            Controls.Add(lblInfo2);
            Controls.Add(lblInfo1);
            Controls.Add(btnExit);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(btnCountUp);
            Controls.Add(btnOpen);
            Name = "SimbolsCount";
            Text = "Подсчет символов в тексте";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOpen;
        private Button btnCountUp;
        private Button btnSave;
        private Button btnClear;
        private Button btnExit;
        private Label lblInfo1;
        private Label lblInfo2;
        private TextBox txtText;
        private TextBox txtPath;
        private TextBox txtCount;
    }
}
