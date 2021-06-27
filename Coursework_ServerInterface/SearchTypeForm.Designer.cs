namespace Coursework_ServerInterface
{
    partial class SearchTypeForm
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
            this.userSearchButton = new System.Windows.Forms.Button();
            this.clanSearchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userSearchButton
            // 
            this.userSearchButton.Location = new System.Drawing.Point(28, 37);
            this.userSearchButton.Name = "userSearchButton";
            this.userSearchButton.Size = new System.Drawing.Size(142, 49);
            this.userSearchButton.TabIndex = 2;
            this.userSearchButton.Text = "По Пользователю";
            this.userSearchButton.UseVisualStyleBackColor = true;
            this.userSearchButton.Click += new System.EventHandler(this.userSearchButton_Click);
            // 
            // clanSearchButton
            // 
            this.clanSearchButton.Location = new System.Drawing.Point(206, 37);
            this.clanSearchButton.Name = "clanSearchButton";
            this.clanSearchButton.Size = new System.Drawing.Size(142, 49);
            this.clanSearchButton.TabIndex = 3;
            this.clanSearchButton.Text = "По Клану";
            this.clanSearchButton.UseVisualStyleBackColor = true;
            this.clanSearchButton.Click += new System.EventHandler(this.clanSearchButton_Click);
            // 
            // SearchTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 128);
            this.Controls.Add(this.clanSearchButton);
            this.Controls.Add(this.userSearchButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchTypeForm";
            this.Text = "SearchTypeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button userSearchButton;
        private System.Windows.Forms.Button clanSearchButton;
    }
}