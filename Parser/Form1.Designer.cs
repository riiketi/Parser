namespace Parser
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
            this.view_btn = new System.Windows.Forms.Button();
            this.Catalog_rb = new System.Windows.Forms.RadioButton();
            this.Category_rb = new System.Windows.Forms.RadioButton();
            this.Product_rb = new System.Windows.Forms.RadioButton();
            this.Path_tb = new System.Windows.Forms.TextBox();
            this.url_rb = new System.Windows.Forms.RadioButton();
            this.html_rb = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.start_btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // view_btn
            // 
            this.view_btn.Enabled = false;
            this.view_btn.Location = new System.Drawing.Point(331, 12);
            this.view_btn.Name = "view_btn";
            this.view_btn.Size = new System.Drawing.Size(75, 20);
            this.view_btn.TabIndex = 0;
            this.view_btn.Text = "Обзор";
            this.view_btn.UseVisualStyleBackColor = true;
            this.view_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Catalog_rb
            // 
            this.Catalog_rb.AutoSize = true;
            this.Catalog_rb.Checked = true;
            this.Catalog_rb.Location = new System.Drawing.Point(6, 19);
            this.Catalog_rb.Name = "Catalog_rb";
            this.Catalog_rb.Size = new System.Drawing.Size(66, 17);
            this.Catalog_rb.TabIndex = 1;
            this.Catalog_rb.TabStop = true;
            this.Catalog_rb.Text = "Каталог";
            this.Catalog_rb.UseVisualStyleBackColor = true;
            // 
            // Category_rb
            // 
            this.Category_rb.AutoSize = true;
            this.Category_rb.Location = new System.Drawing.Point(78, 19);
            this.Category_rb.Name = "Category_rb";
            this.Category_rb.Size = new System.Drawing.Size(78, 17);
            this.Category_rb.TabIndex = 2;
            this.Category_rb.Text = "Категория";
            this.Category_rb.UseVisualStyleBackColor = true;
            // 
            // Product_rb
            // 
            this.Product_rb.AutoSize = true;
            this.Product_rb.Location = new System.Drawing.Point(162, 19);
            this.Product_rb.Name = "Product_rb";
            this.Product_rb.Size = new System.Drawing.Size(56, 17);
            this.Product_rb.TabIndex = 3;
            this.Product_rb.Text = "Товар";
            this.Product_rb.UseVisualStyleBackColor = true;
            // 
            // Path_tb
            // 
            this.Path_tb.Location = new System.Drawing.Point(10, 11);
            this.Path_tb.Name = "Path_tb";
            this.Path_tb.Size = new System.Drawing.Size(222, 20);
            this.Path_tb.TabIndex = 4;
            this.Path_tb.Text = "https://www.dveriregionov.ru/catalog/";
            // 
            // url_rb
            // 
            this.url_rb.AutoSize = true;
            this.url_rb.Checked = true;
            this.url_rb.Location = new System.Drawing.Point(6, 19);
            this.url_rb.Name = "url_rb";
            this.url_rb.Size = new System.Drawing.Size(80, 17);
            this.url_rb.TabIndex = 5;
            this.url_rb.TabStop = true;
            this.url_rb.Text = "URL адрес";
            this.url_rb.UseVisualStyleBackColor = true;
            // 
            // html_rb
            // 
            this.html_rb.AutoSize = true;
            this.html_rb.Location = new System.Drawing.Point(92, 19);
            this.html_rb.Name = "html_rb";
            this.html_rb.Size = new System.Drawing.Size(73, 17);
            this.html_rb.TabIndex = 6;
            this.html_rb.Text = "html файл";
            this.html_rb.UseVisualStyleBackColor = true;
            this.html_rb.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Catalog_rb);
            this.groupBox1.Controls.Add(this.Category_rb);
            this.groupBox1.Controls.Add(this.Product_rb);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 49);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.url_rb);
            this.groupBox2.Controls.Add(this.html_rb);
            this.groupBox2.Location = new System.Drawing.Point(238, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 49);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(238, 12);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(86, 20);
            this.start_btn.TabIndex = 9;
            this.start_btn.Text = "Старт";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 98);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Path_tb);
            this.Controls.Add(this.view_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parser";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button view_btn;
        private System.Windows.Forms.RadioButton Catalog_rb;
        private System.Windows.Forms.RadioButton Category_rb;
        private System.Windows.Forms.RadioButton Product_rb;
        private System.Windows.Forms.TextBox Path_tb;
        private System.Windows.Forms.RadioButton url_rb;
        private System.Windows.Forms.RadioButton html_rb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button start_btn;
    }
}

