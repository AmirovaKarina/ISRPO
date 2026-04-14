namespace PoleChudes
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
            btnNewGame = new Button();
            btnCheck = new Button();
            btnUndo = new Button();
            label1 = new Label();
            txtCurrentWord = new TextBox();
            panelLetters = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btnNewGame
            // 
            btnNewGame.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnNewGame.Location = new Point(30, 21);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(138, 39);
            btnNewGame.TabIndex = 0;
            btnNewGame.Text = "Новая игра";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // btnCheck
            // 
            btnCheck.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCheck.Location = new Point(193, 21);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(126, 39);
            btnCheck.TabIndex = 1;
            btnCheck.Text = "Проверить";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // btnUndo
            // 
            btnUndo.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnUndo.Location = new Point(347, 21);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(114, 39);
            btnUndo.TabIndex = 2;
            btnUndo.Text = "Отмена";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(31, 83);
            label1.Name = "label1";
            label1.Size = new Size(109, 23);
            label1.TabIndex = 3;
            label1.Text = "Собираемое";
            // 
            // txtCurrentWord
            // 
            txtCurrentWord.Font = new Font("Segoe UI Semilight", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtCurrentWord.Location = new Point(158, 80);
            txtCurrentWord.Name = "txtCurrentWord";
            txtCurrentWord.ReadOnly = true;
            txtCurrentWord.Size = new Size(325, 30);
            txtCurrentWord.TabIndex = 4;
            // 
            // panelLetters
            // 
            panelLetters.Location = new Point(89, 232);
            panelLetters.Name = "panelLetters";
            panelLetters.Size = new Size(551, 105);
            panelLetters.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 463);
            Controls.Add(panelLetters);
            Controls.Add(txtCurrentWord);
            Controls.Add(label1);
            Controls.Add(btnUndo);
            Controls.Add(btnCheck);
            Controls.Add(btnNewGame);
            Name = "Form1";
            Text = "Поле чудес";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNewGame;
        private Button btnCheck;
        private Button btnUndo;
        private Label label1;
        private TextBox txtCurrentWord;
        private FlowLayoutPanel panelLetters;
    }
}
