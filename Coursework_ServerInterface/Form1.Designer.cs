namespace Coursework_ServerInterface
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.usersGridView = new System.Windows.Forms.DataGridView();
            this.Hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.dataGridViewsBox = new System.Windows.Forms.GroupBox();
            this.mainGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainGridDataButton = new System.Windows.Forms.Button();
            this.usersGridDataButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LogsLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.clansGridDataButton = new System.Windows.Forms.Button();
            this.clansGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchButton = new System.Windows.Forms.Button();
            this.rangeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.dataGridViewsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clansGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // usersGridView
            // 
            this.usersGridView.AllowUserToAddRows = false;
            this.usersGridView.AllowUserToDeleteRows = false;
            this.usersGridView.AllowUserToResizeColumns = false;
            this.usersGridView.AllowUserToResizeRows = false;
            this.usersGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.usersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hash,
            this.Username,
            this.Password});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.usersGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.usersGridView.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.usersGridView.Location = new System.Drawing.Point(6, 19);
            this.usersGridView.Name = "usersGridView";
            this.usersGridView.RowHeadersVisible = false;
            this.usersGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.usersGridView.Size = new System.Drawing.Size(448, 391);
            this.usersGridView.TabIndex = 0;
            // 
            // Hash
            // 
            this.Hash.HeaderText = "Хэш";
            this.Hash.MaxInputLength = 12;
            this.Hash.Name = "Hash";
            this.Hash.ReadOnly = true;
            this.Hash.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Hash.ToolTipText = "Хэш записи пользователя";
            this.Hash.Width = 50;
            // 
            // Username
            // 
            this.Username.HeaderText = "Имя";
            this.Username.MaxInputLength = 12;
            this.Username.Name = "Username";
            this.Username.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Username.ToolTipText = "Имя пользователя";
            this.Username.Width = 200;
            // 
            // Password
            // 
            this.Password.HeaderText = "Пароль";
            this.Password.MaxInputLength = 12;
            this.Password.Name = "Password";
            this.Password.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Password.ToolTipText = "Пароль пользователя";
            this.Password.Width = 200;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rangeButton);
            this.groupBox1.Controls.Add(this.searchButton);
            this.groupBox1.Controls.Add(this.RemoveButton);
            this.groupBox1.Controls.Add(this.AddButton);
            this.groupBox1.Location = new System.Drawing.Point(18, 481);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(93, 10);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(81, 32);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Удалить";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(6, 10);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(81, 32);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // dataGridViewsBox
            // 
            this.dataGridViewsBox.Controls.Add(this.clansGridView);
            this.dataGridViewsBox.Controls.Add(this.mainGridView);
            this.dataGridViewsBox.Controls.Add(this.usersGridView);
            this.dataGridViewsBox.Location = new System.Drawing.Point(12, 59);
            this.dataGridViewsBox.Name = "dataGridViewsBox";
            this.dataGridViewsBox.Size = new System.Drawing.Size(700, 416);
            this.dataGridViewsBox.TabIndex = 2;
            this.dataGridViewsBox.TabStop = false;
            // 
            // mainGridView
            // 
            this.mainGridView.AllowUserToAddRows = false;
            this.mainGridView.AllowUserToDeleteRows = false;
            this.mainGridView.AllowUserToResizeColumns = false;
            this.mainGridView.AllowUserToResizeRows = false;
            this.mainGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.mainGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.ColorCode,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mainGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.mainGridView.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.mainGridView.Location = new System.Drawing.Point(6, 19);
            this.mainGridView.MultiSelect = false;
            this.mainGridView.Name = "mainGridView";
            this.mainGridView.ReadOnly = true;
            this.mainGridView.RowHeadersVisible = false;
            this.mainGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mainGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mainGridView.Size = new System.Drawing.Size(688, 391);
            this.mainGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Имя";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 12;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.ToolTipText = "Имя пользователя";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Пароль";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 12;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.ToolTipText = "Пароль пользователя";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Позиция";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 10;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.ToolTipText = "Позиция пользователя на игровом поле";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Клан";
            this.dataGridViewTextBoxColumn5.MaxInputLength = 7;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.ToolTipText = "Клан, в котором состоит пользователь";
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // ColorCode
            // 
            this.ColorCode.HeaderText = "Код цвета";
            this.ColorCode.Name = "ColorCode";
            this.ColorCode.ReadOnly = true;
            this.ColorCode.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Очки действий";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Здоровье";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.clansGridDataButton);
            this.panel1.Controls.Add(this.mainGridDataButton);
            this.panel1.Controls.Add(this.usersGridDataButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 41);
            this.panel1.TabIndex = 3;
            // 
            // mainGridDataButton
            // 
            this.mainGridDataButton.Location = new System.Drawing.Point(12, 3);
            this.mainGridDataButton.Name = "mainGridDataButton";
            this.mainGridDataButton.Size = new System.Drawing.Size(96, 35);
            this.mainGridDataButton.TabIndex = 1;
            this.mainGridDataButton.Text = "Общее";
            this.mainGridDataButton.UseVisualStyleBackColor = true;
            this.mainGridDataButton.Click += new System.EventHandler(this.mainGridDataButton_Click);
            // 
            // usersGridDataButton
            // 
            this.usersGridDataButton.Location = new System.Drawing.Point(114, 3);
            this.usersGridDataButton.Name = "usersGridDataButton";
            this.usersGridDataButton.Size = new System.Drawing.Size(96, 35);
            this.usersGridDataButton.TabIndex = 0;
            this.usersGridDataButton.Text = "Пользователи";
            this.usersGridDataButton.UseVisualStyleBackColor = true;
            this.usersGridDataButton.Click += new System.EventHandler(this.usersDataGridButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.LogsLabel);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(718, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 521);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.StopButton);
            this.panel3.Controls.Add(this.StartButton);
            this.panel3.Location = new System.Drawing.Point(12, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(352, 82);
            this.panel3.TabIndex = 4;
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(191, 19);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(113, 46);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Выключить";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(36, 19);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(113, 46);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Включить";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(107, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Управление сервером";
            // 
            // LogsLabel
            // 
            this.LogsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogsLabel.AutoSize = true;
            this.LogsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LogsLabel.Location = new System.Drawing.Point(135, 238);
            this.LogsLabel.Name = "LogsLabel";
            this.LogsLabel.Size = new System.Drawing.Size(99, 17);
            this.LogsLabel.TabIndex = 1;
            this.LogsLabel.Text = "Логи событий";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Location = new System.Drawing.Point(12, 258);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(352, 253);
            this.textBox1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // clansGridDataButton
            // 
            this.clansGridDataButton.Location = new System.Drawing.Point(216, 3);
            this.clansGridDataButton.Name = "clansGridDataButton";
            this.clansGridDataButton.Size = new System.Drawing.Size(96, 35);
            this.clansGridDataButton.TabIndex = 2;
            this.clansGridDataButton.Text = "Кланы";
            this.clansGridDataButton.UseVisualStyleBackColor = true;
            this.clansGridDataButton.Click += new System.EventHandler(this.clansGridDataButton_Click);
            // 
            // clansGridView
            // 
            this.clansGridView.AllowUserToAddRows = false;
            this.clansGridView.AllowUserToDeleteRows = false;
            this.clansGridView.AllowUserToResizeColumns = false;
            this.clansGridView.AllowUserToResizeRows = false;
            this.clansGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.clansGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clansGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.clansGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.clansGridView.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.clansGridView.Location = new System.Drawing.Point(6, 19);
            this.clansGridView.MultiSelect = false;
            this.clansGridView.Name = "clansGridView";
            this.clansGridView.ReadOnly = true;
            this.clansGridView.RowHeadersVisible = false;
            this.clansGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.clansGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.clansGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clansGridView.Size = new System.Drawing.Size(448, 391);
            this.clansGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Хэш";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 12;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Хэш записи пользователя";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Название";
            this.dataGridViewTextBoxColumn8.MaxInputLength = 12;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.ToolTipText = "Название клана";
            this.dataGridViewTextBoxColumn8.Width = 200;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Цвет";
            this.dataGridViewTextBoxColumn9.MaxInputLength = 12;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn9.ToolTipText = "Код цвета";
            this.dataGridViewTextBoxColumn9.Width = 200;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(180, 10);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(81, 32);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Поиск";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // rangeButton
            // 
            this.rangeButton.Location = new System.Drawing.Point(267, 10);
            this.rangeButton.Name = "rangeButton";
            this.rangeButton.Size = new System.Drawing.Size(81, 32);
            this.rangeButton.TabIndex = 3;
            this.rangeButton.Text = "Диапозон";
            this.rangeButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 545);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewsBox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.dataGridViewsBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clansGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView usersGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.GroupBox dataGridViewsBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button usersGridDataButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LogsLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView mainGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hash;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.Button mainGridDataButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridView clansGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Button clansGridDataButton;
        private System.Windows.Forms.Button rangeButton;
        private System.Windows.Forms.Button searchButton;
    }
}

