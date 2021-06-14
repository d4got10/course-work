namespace Coursework_ServerInterface
{
    partial class UserAddForm
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.xPositionTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.clanTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.actionPointsTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.healthTextBox = new System.Windows.Forms.TextBox();
            this.yPositionTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nameTextBox.Location = new System.Drawing.Point(180, 20);
            this.nameTextBox.MaxLength = 12;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(145, 26);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.Text = "newplayer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Добавление нового пользователя";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.yPositionTextBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.healthTextBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.actionPointsTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.clanTextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.xPositionTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.passwordTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Location = new System.Drawing.Point(12, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 213);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Пароль";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.passwordTextBox.Location = new System.Drawing.Point(180, 52);
            this.passwordTextBox.MaxLength = 12;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(145, 26);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.Text = "qwerty";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Позиция";
            // 
            // xPositionTextBox
            // 
            this.xPositionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.xPositionTextBox.Location = new System.Drawing.Point(180, 84);
            this.xPositionTextBox.MaxLength = 12;
            this.xPositionTextBox.Name = "xPositionTextBox";
            this.xPositionTextBox.Size = new System.Drawing.Size(66, 26);
            this.xPositionTextBox.TabIndex = 4;
            this.xPositionTextBox.Text = "20";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Клан";
            // 
            // clanTextBox
            // 
            this.clanTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.clanTextBox.Location = new System.Drawing.Point(180, 116);
            this.clanTextBox.MaxLength = 12;
            this.clanTextBox.Name = "clanTextBox";
            this.clanTextBox.Size = new System.Drawing.Size(145, 26);
            this.clanTextBox.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(12, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Очки действий";
            // 
            // actionPointsTextBox
            // 
            this.actionPointsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.actionPointsTextBox.Location = new System.Drawing.Point(180, 148);
            this.actionPointsTextBox.MaxLength = 12;
            this.actionPointsTextBox.Name = "actionPointsTextBox";
            this.actionPointsTextBox.Size = new System.Drawing.Size(145, 26);
            this.actionPointsTextBox.TabIndex = 8;
            this.actionPointsTextBox.Text = "5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(12, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Здоровье";
            // 
            // healthTextBox
            // 
            this.healthTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.healthTextBox.Location = new System.Drawing.Point(180, 180);
            this.healthTextBox.MaxLength = 12;
            this.healthTextBox.Name = "healthTextBox";
            this.healthTextBox.Size = new System.Drawing.Size(145, 26);
            this.healthTextBox.TabIndex = 10;
            this.healthTextBox.Text = "3";
            // 
            // yPositionTextBox
            // 
            this.yPositionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.yPositionTextBox.Location = new System.Drawing.Point(252, 84);
            this.yPositionTextBox.MaxLength = 12;
            this.yPositionTextBox.Name = "yPositionTextBox";
            this.yPositionTextBox.Size = new System.Drawing.Size(73, 26);
            this.yPositionTextBox.TabIndex = 12;
            this.yPositionTextBox.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 303);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserAddForm";
            this.Text = "UserAddForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox yPositionTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox healthTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox actionPointsTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox clanTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox xPositionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}