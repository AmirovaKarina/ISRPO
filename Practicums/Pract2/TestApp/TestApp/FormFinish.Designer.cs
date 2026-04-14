namespace TestApp
{
    partial class FormFinish
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
            label1 = new Label();
            lblResult = new Label();
            dgvHistory = new DataGridView();
            btnAgain = new Button();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(252, 44);
            label1.Name = "label1";
            label1.Size = new Size(305, 54);
            label1.TabIndex = 0;
            label1.Text = "Тест завершен!";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblResult.Location = new Point(181, 121);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(77, 31);
            lblResult.TabIndex = 1;
            lblResult.Text = "label2";
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvHistory
            // 
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Location = new Point(104, 231);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.RowHeadersWidth = 51;
            dgvHistory.Size = new Size(615, 255);
            dgvHistory.TabIndex = 2;
            // 
            // btnAgain
            // 
            btnAgain.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnAgain.Location = new Point(178, 513);
            btnAgain.Name = "btnAgain";
            btnAgain.Size = new Size(168, 51);
            btnAgain.TabIndex = 3;
            btnAgain.Text = "Пройти заново";
            btnAgain.UseVisualStyleBackColor = true;
            btnAgain.Click += btnAgain_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnExit.Location = new Point(468, 513);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(168, 51);
            btnExit.TabIndex = 4;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // FormFinish
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(835, 592);
            Controls.Add(btnExit);
            Controls.Add(btnAgain);
            Controls.Add(dgvHistory);
            Controls.Add(lblResult);
            Controls.Add(label1);
            Name = "FormFinish";
            Text = "Результаты теста";
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblResult;
        private DataGridView dgvHistory;
        private Button btnAgain;
        private Button btnExit;
    }
}