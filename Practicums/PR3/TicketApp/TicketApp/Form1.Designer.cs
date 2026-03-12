namespace TicketApp
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
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(179, 31);
            label1.Name = "label1";
            label1.Size = new Size(422, 28);
            label1.TabIndex = 0;
            label1.Text = "Генератор и проверка счастливых билетов";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semilight", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(159, 316);
            label2.Name = "label2";
            label2.Size = new Size(442, 57);
            label2.TabIndex = 1;
            label2.Text = "Счастливый билет - это билет, у которого сумма первых трех цифр равна сумме трех последних";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.SlateBlue;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.Location = new Point(264, 109);
            button1.Name = "button1";
            button1.Size = new Size(228, 51);
            button1.TabIndex = 2;
            button1.Text = "Сгенерировать билет";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semilight", 10.2F);
            label3.Location = new Point(315, 199);
            label3.Name = "label3";
            label3.Size = new Size(55, 23);
            label3.TabIndex = 3;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semilight", 10.2F);
            label4.Location = new Point(325, 251);
            label4.Name = "label4";
            label4.Size = new Size(55, 23);
            label4.TabIndex = 4;
            label4.Text = "label4";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 402);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Проверка счастливого билетика";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private Label label3;
        private Label label4;
    }
}
