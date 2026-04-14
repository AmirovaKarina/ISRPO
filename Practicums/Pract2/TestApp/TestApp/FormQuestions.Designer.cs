namespace TestApp
{
    partial class FormQuestions
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
            lblQuestionNum = new Label();
            lblTimer = new Label();
            lblQuestion = new Label();
            rb1 = new RadioButton();
            rb2 = new RadioButton();
            rb3 = new RadioButton();
            rb4 = new RadioButton();
            btnNext = new Button();
            btnPrev = new Button();
            panel1 = new Panel();
            label4 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblQuestionNum
            // 
            lblQuestionNum.AutoSize = true;
            lblQuestionNum.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblQuestionNum.Location = new Point(552, 31);
            lblQuestionNum.Name = "lblQuestionNum";
            lblQuestionNum.Size = new Size(63, 28);
            lblQuestionNum.TabIndex = 0;
            lblQuestionNum.Text = "label1";
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTimer.Location = new Point(222, 31);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(66, 28);
            lblTimer.TabIndex = 1;
            lblTimer.Text = "label2";
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblQuestion.Location = new Point(37, 36);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(66, 28);
            lblQuestion.TabIndex = 2;
            lblQuestion.Text = "label3";
            // 
            // rb1
            // 
            rb1.AutoSize = true;
            rb1.Font = new Font("Segoe UI Semilight", 10.8F);
            rb1.Location = new Point(48, 35);
            rb1.Name = "rb1";
            rb1.Size = new Size(131, 29);
            rb1.TabIndex = 3;
            rb1.TabStop = true;
            rb1.Text = "radioButton1";
            rb1.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            rb2.AutoSize = true;
            rb2.Font = new Font("Segoe UI Semilight", 10.8F);
            rb2.Location = new Point(48, 80);
            rb2.Name = "rb2";
            rb2.Size = new Size(133, 29);
            rb2.TabIndex = 4;
            rb2.TabStop = true;
            rb2.Text = "radioButton2";
            rb2.UseVisualStyleBackColor = true;
            // 
            // rb3
            // 
            rb3.AutoSize = true;
            rb3.Font = new Font("Segoe UI Semilight", 10.8F);
            rb3.Location = new Point(48, 127);
            rb3.Name = "rb3";
            rb3.Size = new Size(133, 29);
            rb3.TabIndex = 5;
            rb3.TabStop = true;
            rb3.Text = "radioButton3";
            rb3.UseVisualStyleBackColor = true;
            // 
            // rb4
            // 
            rb4.AutoSize = true;
            rb4.Font = new Font("Segoe UI Semilight", 10.8F);
            rb4.Location = new Point(48, 171);
            rb4.Name = "rb4";
            rb4.Size = new Size(134, 29);
            rb4.TabIndex = 6;
            rb4.TabStop = true;
            rb4.Text = "radioButton4";
            rb4.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnNext.Location = new Point(437, 487);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(148, 58);
            btnNext.TabIndex = 7;
            btnNext.Text = "Далее";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnPrev.Location = new Point(181, 487);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(148, 58);
            btnPrev.TabIndex = 8;
            btnPrev.Text = "Назад";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lblTimer);
            panel1.Controls.Add(lblQuestionNum);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(801, 87);
            panel1.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(22, 31);
            label4.Name = "label4";
            label4.Size = new Size(193, 28);
            label4.TabIndex = 10;
            label4.Text = "Осталось времени:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightSeaGreen;
            panel2.Controls.Add(lblQuestion);
            panel2.ForeColor = SystemColors.ControlText;
            panel2.Location = new Point(48, 111);
            panel2.Name = "panel2";
            panel2.Size = new Size(692, 101);
            panel2.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(rb2);
            panel3.Controls.Add(rb3);
            panel3.Controls.Add(rb4);
            panel3.Controls.Add(rb1);
            panel3.Location = new Point(48, 218);
            panel3.Name = "panel3";
            panel3.Size = new Size(692, 238);
            panel3.TabIndex = 11;
            // 
            // FormQuestions
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 575);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);
            Name = "FormQuestions";
            Text = "Тестирование";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblQuestionNum;
        private Label lblTimer;
        private Label lblQuestion;
        private RadioButton rb1;
        private RadioButton rb2;
        private RadioButton rb3;
        private RadioButton rb4;
        private Button btnNext;
        private Button btnPrev;
        private Panel panel1;
        private Label label4;
        private Panel panel2;
        private Panel panel3;
    }
}