namespace Coursework_ServerInterface
{
    partial class DebugForm
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
            this.components = new System.ComponentModel.Container();
            this.debugTextBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.displayNameTreeButton = new System.Windows.Forms.Button();
            this.displayClanTreeButton = new System.Windows.Forms.Button();
            this.displayHealthTreeButton = new System.Windows.Forms.Button();
            this.displayActionPointsTreeButton = new System.Windows.Forms.Button();
            this.clearTextBoxButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // debugTextBox
            // 
            this.debugTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.debugTextBox.Location = new System.Drawing.Point(12, 12);
            this.debugTextBox.Multiline = true;
            this.debugTextBox.Name = "debugTextBox";
            this.debugTextBox.ReadOnly = true;
            this.debugTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.debugTextBox.Size = new System.Drawing.Size(478, 426);
            this.debugTextBox.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // displayNameTreeButton
            // 
            this.displayNameTreeButton.Location = new System.Drawing.Point(544, 24);
            this.displayNameTreeButton.Name = "displayNameTreeButton";
            this.displayNameTreeButton.Size = new System.Drawing.Size(132, 45);
            this.displayNameTreeButton.TabIndex = 1;
            this.displayNameTreeButton.Text = "Вывести дерево поиска по имени";
            this.displayNameTreeButton.UseVisualStyleBackColor = true;
            this.displayNameTreeButton.Click += new System.EventHandler(this.displayNameTreeButton_Click);
            // 
            // displayClanTreeButton
            // 
            this.displayClanTreeButton.Location = new System.Drawing.Point(544, 99);
            this.displayClanTreeButton.Name = "displayClanTreeButton";
            this.displayClanTreeButton.Size = new System.Drawing.Size(132, 45);
            this.displayClanTreeButton.TabIndex = 2;
            this.displayClanTreeButton.Text = "Вывести дерево поиска по клану";
            this.displayClanTreeButton.UseVisualStyleBackColor = true;
            this.displayClanTreeButton.Click += new System.EventHandler(this.displayClanTreeButton_Click);
            // 
            // displayHealthTreeButton
            // 
            this.displayHealthTreeButton.Location = new System.Drawing.Point(544, 174);
            this.displayHealthTreeButton.Name = "displayHealthTreeButton";
            this.displayHealthTreeButton.Size = new System.Drawing.Size(132, 45);
            this.displayHealthTreeButton.TabIndex = 3;
            this.displayHealthTreeButton.Text = "Вывести дерево поиска по здоровью";
            this.displayHealthTreeButton.UseVisualStyleBackColor = true;
            this.displayHealthTreeButton.Click += new System.EventHandler(this.displayHealthTreeButton_Click);
            // 
            // displayActionPointsTreeButton
            // 
            this.displayActionPointsTreeButton.Location = new System.Drawing.Point(544, 250);
            this.displayActionPointsTreeButton.Name = "displayActionPointsTreeButton";
            this.displayActionPointsTreeButton.Size = new System.Drawing.Size(132, 49);
            this.displayActionPointsTreeButton.TabIndex = 4;
            this.displayActionPointsTreeButton.Text = "Вывести дерево поиска по очкам действий";
            this.displayActionPointsTreeButton.UseVisualStyleBackColor = true;
            this.displayActionPointsTreeButton.Click += new System.EventHandler(this.displayActionPointsTreeButton_Click);
            // 
            // clearTextBoxButton
            // 
            this.clearTextBoxButton.Location = new System.Drawing.Point(544, 389);
            this.clearTextBoxButton.Name = "clearTextBoxButton";
            this.clearTextBoxButton.Size = new System.Drawing.Size(132, 49);
            this.clearTextBoxButton.TabIndex = 5;
            this.clearTextBoxButton.Text = "Очистить вывод";
            this.clearTextBoxButton.UseVisualStyleBackColor = true;
            this.clearTextBoxButton.Click += new System.EventHandler(this.clearTextBoxButton_Click);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 450);
            this.Controls.Add(this.clearTextBoxButton);
            this.Controls.Add(this.displayActionPointsTreeButton);
            this.Controls.Add(this.displayHealthTreeButton);
            this.Controls.Add(this.displayClanTreeButton);
            this.Controls.Add(this.displayNameTreeButton);
            this.Controls.Add(this.debugTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DebugForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "DebugForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebugForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox debugTextBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button displayNameTreeButton;
        private System.Windows.Forms.Button displayClanTreeButton;
        private System.Windows.Forms.Button displayHealthTreeButton;
        private System.Windows.Forms.Button displayActionPointsTreeButton;
        private System.Windows.Forms.Button clearTextBoxButton;
    }
}