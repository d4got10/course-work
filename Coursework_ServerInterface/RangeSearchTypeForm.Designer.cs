namespace Coursework_ServerInterface
{
    partial class RangeSearchTypeForm
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
            this.clanSearchButton = new System.Windows.Forms.Button();
            this.userSearchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clanSearchButton
            // 
            this.clanSearchButton.Location = new System.Drawing.Point(205, 40);
            this.clanSearchButton.Name = "clanSearchButton";
            this.clanSearchButton.Size = new System.Drawing.Size(142, 49);
            this.clanSearchButton.TabIndex = 5;
            this.clanSearchButton.Text = "По Очкам действий";
            this.clanSearchButton.UseVisualStyleBackColor = true;
            this.clanSearchButton.Click += new System.EventHandler(this.clanSearchButton_Click);
            // 
            // userSearchButton
            // 
            this.userSearchButton.Location = new System.Drawing.Point(27, 40);
            this.userSearchButton.Name = "userSearchButton";
            this.userSearchButton.Size = new System.Drawing.Size(142, 49);
            this.userSearchButton.TabIndex = 4;
            this.userSearchButton.Text = "По Здоровью";
            this.userSearchButton.UseVisualStyleBackColor = true;
            this.userSearchButton.Click += new System.EventHandler(this.userSearchButton_Click);
            // 
            // RangeSearchTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 128);
            this.Controls.Add(this.clanSearchButton);
            this.Controls.Add(this.userSearchButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RangeSearchTypeForm";
            this.Text = "RangeSearchTypeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clanSearchButton;
        private System.Windows.Forms.Button userSearchButton;
    }
}