namespace Coursework_ServerInterface
{
    partial class PlayerAddForm
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
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.clanTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.colorTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.positionXField = new System.Windows.Forms.NumericUpDown();
            this.positionYField = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.actionPointsField = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.healthPointsField = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionXField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionYField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionPointsField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthPointsField)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.passwordTextBox.Location = new System.Drawing.Point(191, 55);
            this.passwordTextBox.MaxLength = 12;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.ReadOnly = true;
            this.passwordTextBox.Size = new System.Drawing.Size(153, 26);
            this.passwordTextBox.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.healthPointsField);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.actionPointsField);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.positionYField);
            this.panel1.Controls.Add(this.positionXField);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.colorTextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.clanTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.userNameTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.passwordTextBox);
            this.panel1.Location = new System.Drawing.Point(12, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 279);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Имя пользователя";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.userNameTextBox.Location = new System.Drawing.Point(191, 21);
            this.userNameTextBox.MaxLength = 12;
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(153, 26);
            this.userNameTextBox.TabIndex = 7;
            this.userNameTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // clanTextBox
            // 
            this.clanTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.clanTextBox.Location = new System.Drawing.Point(191, 87);
            this.clanTextBox.MaxLength = 12;
            this.clanTextBox.Name = "clanTextBox";
            this.clanTextBox.Size = new System.Drawing.Size(153, 26);
            this.clanTextBox.TabIndex = 9;
            this.clanTextBox.TextChanged += new System.EventHandler(this.clanTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Название клана";
            // 
            // colorTextBox
            // 
            this.colorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.colorTextBox.Location = new System.Drawing.Point(191, 119);
            this.colorTextBox.MaxLength = 12;
            this.colorTextBox.Name = "colorTextBox";
            this.colorTextBox.ReadOnly = true;
            this.colorTextBox.Size = new System.Drawing.Size(153, 26);
            this.colorTextBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(3, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Код цвета клана";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(3, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Позиция";
            // 
            // positionXField
            // 
            this.positionXField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.positionXField.Location = new System.Drawing.Point(214, 150);
            this.positionXField.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.positionXField.Name = "positionXField";
            this.positionXField.Size = new System.Drawing.Size(52, 26);
            this.positionXField.TabIndex = 13;
            // 
            // positionYField
            // 
            this.positionYField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.positionYField.Location = new System.Drawing.Point(299, 150);
            this.positionYField.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.positionYField.Name = "positionYField";
            this.positionYField.Size = new System.Drawing.Size(45, 26);
            this.positionYField.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(272, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(187, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "X";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(3, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Очки действий";
            // 
            // actionPointsField
            // 
            this.actionPointsField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.actionPointsField.Location = new System.Drawing.Point(191, 182);
            this.actionPointsField.Name = "actionPointsField";
            this.actionPointsField.Size = new System.Drawing.Size(153, 26);
            this.actionPointsField.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(3, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Здоровье";
            // 
            // healthPointsField
            // 
            this.healthPointsField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.healthPointsField.Location = new System.Drawing.Point(191, 214);
            this.healthPointsField.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.healthPointsField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.healthPointsField.Name = "healthPointsField";
            this.healthPointsField.Size = new System.Drawing.Size(153, 26);
            this.healthPointsField.TabIndex = 20;
            this.healthPointsField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(125, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 29);
            this.button1.TabIndex = 21;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label10.Location = new System.Drawing.Point(101, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 24);
            this.label10.TabIndex = 6;
            this.label10.Text = "Добавление игрока";
            // 
            // PlayerAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 341);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PlayerAddForm";
            this.Text = "PlayerAddForm";
            this.Load += new System.EventHandler(this.PlayerAddForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionXField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionYField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actionPointsField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthPointsField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.NumericUpDown positionYField;
        private System.Windows.Forms.NumericUpDown positionXField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox colorTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox clanTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown healthPointsField;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown actionPointsField;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
    }
}