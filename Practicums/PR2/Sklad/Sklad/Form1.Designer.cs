namespace Sklad
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
            groupBox1 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox2 = new GroupBox();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            comboBox1 = new ComboBox();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox3 = new GroupBox();
            label6 = new Label();
            button6 = new Button();
            textBox2 = new TextBox();
            groupBox4 = new GroupBox();
            numericUpDown5 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            label8 = new Label();
            label7 = new Label();
            button7 = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(714, 580);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Товар";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(18, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(677, 531);
            dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(numericUpDown3);
            groupBox2.Controls.Add(numericUpDown2);
            groupBox2.Controls.Add(numericUpDown1);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Segoe UI Semilight", 9F);
            groupBox2.Location = new Point(743, 25);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(550, 325);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Добавить";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(212, 210);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(158, 27);
            numericUpDown3.TabIndex = 14;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(212, 173);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(158, 27);
            numericUpDown2.TabIndex = 13;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(212, 134);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(158, 27);
            numericUpDown1.TabIndex = 12;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(212, 91);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(158, 28);
            comboBox1.TabIndex = 11;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button5
            // 
            button5.Location = new Point(408, 206);
            button5.Name = "button5";
            button5.Size = new Size(122, 33);
            button5.TabIndex = 10;
            button5.Text = "Открыть";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(408, 267);
            button4.Name = "button4";
            button4.Size = new Size(122, 33);
            button4.TabIndex = 9;
            button4.Text = "Сохранить как";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(259, 267);
            button3.Name = "button3";
            button3.Size = new Size(111, 33);
            button3.TabIndex = 8;
            button3.Text = "Добавить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(36, 267);
            button2.Name = "button2";
            button2.Size = new Size(176, 33);
            button2.TabIndex = 7;
            button2.Text = "Удалить выбранное";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(408, 43);
            button1.Name = "button1";
            button1.Size = new Size(113, 33);
            button1.TabIndex = 6;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(212, 43);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(158, 27);
            textBox1.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 212);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 4;
            label5.Text = "Количество";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 175);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 3;
            label4.Text = "Номер ячейки";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 136);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 2;
            label3.Text = "Номер стелажа";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 94);
            label2.Name = "label2";
            label2.Size = new Size(162, 20);
            label2.TabIndex = 1;
            label2.Text = "Наименование товара";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 46);
            label1.Name = "label1";
            label1.Size = new Size(156, 20);
            label1.TabIndex = 0;
            label1.Text = "Новое наименование";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(button6);
            groupBox3.Controls.Add(textBox2);
            groupBox3.Font = new Font("Segoe UI Semilight", 9F);
            groupBox3.Location = new Point(743, 366);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(550, 93);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Поиск по названию";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 45);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 2;
            label6.Text = "Имя товара";
            // 
            // button6
            // 
            button6.Location = new Point(408, 45);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 1;
            button6.Text = "Поиск";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(113, 45);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(235, 27);
            textBox2.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(numericUpDown5);
            groupBox4.Controls.Add(numericUpDown4);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(button7);
            groupBox4.Font = new Font("Segoe UI Semilight", 9F);
            groupBox4.Location = new Point(743, 477);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(550, 115);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Поиск по координатам";
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(207, 65);
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(150, 27);
            numericUpDown5.TabIndex = 6;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(17, 65);
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(150, 27);
            numericUpDown4.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(207, 42);
            label8.Name = "label8";
            label8.Size = new Size(57, 20);
            label8.TabIndex = 4;
            label8.Text = "Ячейка";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 37);
            label7.Name = "label7";
            label7.Size = new Size(59, 20);
            label7.TabIndex = 3;
            label7.Text = "Стелаж";
            // 
            // button7
            // 
            button7.Location = new Point(408, 63);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 2;
            button7.Text = "Поиск";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1305, 610);
            Controls.Add(groupBox3);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Складской учет";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private ComboBox comboBox1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private TextBox textBox1;
        private Label label6;
        private Button button6;
        private TextBox textBox2;
        private Label label8;
        private Label label7;
        private Button button7;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown5;
        private NumericUpDown numericUpDown4;
    }
}
