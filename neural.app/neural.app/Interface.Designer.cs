namespace neural.app
{
    partial class Interface
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обработатьВидеоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.распознатьОбразыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.образToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьОбразToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.образToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(316, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обработатьВидеоToolStripMenuItem,
            this.распознатьОбразыToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // обработатьВидеоToolStripMenuItem
            // 
            this.обработатьВидеоToolStripMenuItem.Name = "обработатьВидеоToolStripMenuItem";
            this.обработатьВидеоToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.обработатьВидеоToolStripMenuItem.Text = "Обработать видео";
            this.обработатьВидеоToolStripMenuItem.Click += new System.EventHandler(this.обработатьВидеоToolStripMenuItem_Click);
            // 
            // распознатьОбразыToolStripMenuItem
            // 
            this.распознатьОбразыToolStripMenuItem.Name = "распознатьОбразыToolStripMenuItem";
            this.распознатьОбразыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.распознатьОбразыToolStripMenuItem.Text = "Распознать образы";
            this.распознатьОбразыToolStripMenuItem.Click += new System.EventHandler(this.распознатьОбразыToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // образToolStripMenuItem
            // 
            this.образToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьОбразToolStripMenuItem});
            this.образToolStripMenuItem.Name = "образToolStripMenuItem";
            this.образToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.образToolStripMenuItem.Text = "Образ";
            // 
            // добавитьОбразToolStripMenuItem
            // 
            this.добавитьОбразToolStripMenuItem.Name = "добавитьОбразToolStripMenuItem";
            this.добавитьОбразToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.добавитьОбразToolStripMenuItem.Text = "Добавить образ";
            this.добавитьОбразToolStripMenuItem.Click += new System.EventHandler(this.добавитьОбразToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(316, 500);
            this.textBox1.TabIndex = 18;
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(316, 526);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Interface";
            this.Text = "Распознавание образов";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обработатьВидеоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem распознатьОбразыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem образToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьОбразToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
    }
}

