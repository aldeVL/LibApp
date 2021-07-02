namespace Biblioteka_Design
{
    partial class AddBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBooks));
            this.Book_Name_TextBox = new System.Windows.Forms.TextBox();
            this.Book_Author_Combo = new System.Windows.Forms.ComboBox();
            this.Book_Genre_Combo = new System.Windows.Forms.ComboBox();
            this.Book_Publish_Combo = new System.Windows.Forms.ComboBox();
            this.Book_Year_TextBox = new System.Windows.Forms.TextBox();
            this.Book_Vozrast_Combo = new System.Windows.Forms.ComboBox();
            this.Book_Name_Label = new System.Windows.Forms.Label();
            this.Book_Year_Label = new System.Windows.Forms.Label();
            this.Book_Vozrast_Label = new System.Windows.Forms.Label();
            this.Book_BBK_Label = new System.Windows.Forms.Label();
            this.Oblozhka = new System.Windows.Forms.PictureBox();
            this.Oblozhka_Label = new System.Windows.Forms.Label();
            this.Oblozhka_ = new System.Windows.Forms.Label();
            this.AddBook_Submit = new System.Windows.Forms.Button();
            this.AddBook_Cancel = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.Book_Author_Label = new System.Windows.Forms.Label();
            this.Book_Genre_Label = new System.Windows.Forms.Label();
            this.Book_Publish_Label = new System.Windows.Forms.Label();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.Book_BBK_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Book_ISBN_TextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Oblozhka)).BeginInit();
            this.SuspendLayout();
            // 
            // Book_Name_TextBox
            // 
            this.Book_Name_TextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Book_Name_TextBox.Location = new System.Drawing.Point(166, 23);
            this.Book_Name_TextBox.MaxLength = 20;
            this.Book_Name_TextBox.Name = "Book_Name_TextBox";
            this.Book_Name_TextBox.Size = new System.Drawing.Size(121, 22);
            this.Book_Name_TextBox.TabIndex = 1;
            this.Book_Name_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.Book_Name_TextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // Book_Author_Combo
            // 
            this.Book_Author_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Book_Author_Combo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Book_Author_Combo.FormattingEnabled = true;
            this.Book_Author_Combo.Location = new System.Drawing.Point(166, 91);
            this.Book_Author_Combo.Name = "Book_Author_Combo";
            this.Book_Author_Combo.Size = new System.Drawing.Size(158, 22);
            this.Book_Author_Combo.TabIndex = 2;
            this.Book_Author_Combo.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Book_Genre_Combo
            // 
            this.Book_Genre_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Book_Genre_Combo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Book_Genre_Combo.FormattingEnabled = true;
            this.Book_Genre_Combo.Location = new System.Drawing.Point(166, 156);
            this.Book_Genre_Combo.Name = "Book_Genre_Combo";
            this.Book_Genre_Combo.Size = new System.Drawing.Size(121, 22);
            this.Book_Genre_Combo.TabIndex = 3;
            this.Book_Genre_Combo.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Book_Publish_Combo
            // 
            this.Book_Publish_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Book_Publish_Combo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Book_Publish_Combo.FormattingEnabled = true;
            this.Book_Publish_Combo.Location = new System.Drawing.Point(166, 217);
            this.Book_Publish_Combo.Name = "Book_Publish_Combo";
            this.Book_Publish_Combo.Size = new System.Drawing.Size(121, 22);
            this.Book_Publish_Combo.TabIndex = 4;
            this.Book_Publish_Combo.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Book_Year_TextBox
            // 
            this.Book_Year_TextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Book_Year_TextBox.Location = new System.Drawing.Point(166, 270);
            this.Book_Year_TextBox.MaxLength = 4;
            this.Book_Year_TextBox.Name = "Book_Year_TextBox";
            this.Book_Year_TextBox.Size = new System.Drawing.Size(121, 22);
            this.Book_Year_TextBox.TabIndex = 5;
            this.Book_Year_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            this.Book_Year_TextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // Book_Vozrast_Combo
            // 
            this.Book_Vozrast_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Book_Vozrast_Combo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Book_Vozrast_Combo.FormattingEnabled = true;
            this.Book_Vozrast_Combo.Items.AddRange(new object[] {
            "0+",
            "6+",
            "12+",
            "16+",
            "18+"});
            this.Book_Vozrast_Combo.Location = new System.Drawing.Point(166, 389);
            this.Book_Vozrast_Combo.Name = "Book_Vozrast_Combo";
            this.Book_Vozrast_Combo.Size = new System.Drawing.Size(121, 22);
            this.Book_Vozrast_Combo.TabIndex = 6;
            // 
            // Book_Name_Label
            // 
            this.Book_Name_Label.AutoSize = true;
            this.Book_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.Book_Name_Label.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Book_Name_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Book_Name_Label.Location = new System.Drawing.Point(19, 26);
            this.Book_Name_Label.Name = "Book_Name_Label";
            this.Book_Name_Label.Size = new System.Drawing.Size(105, 21);
            this.Book_Name_Label.TabIndex = 9;
            this.Book_Name_Label.Text = "Название книги";
            // 
            // Book_Year_Label
            // 
            this.Book_Year_Label.AutoSize = true;
            this.Book_Year_Label.BackColor = System.Drawing.Color.Transparent;
            this.Book_Year_Label.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Book_Year_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Book_Year_Label.Location = new System.Drawing.Point(19, 273);
            this.Book_Year_Label.Name = "Book_Year_Label";
            this.Book_Year_Label.Size = new System.Drawing.Size(83, 21);
            this.Book_Year_Label.TabIndex = 13;
            this.Book_Year_Label.Text = "Год издания";
            // 
            // Book_Vozrast_Label
            // 
            this.Book_Vozrast_Label.AutoSize = true;
            this.Book_Vozrast_Label.BackColor = System.Drawing.Color.Transparent;
            this.Book_Vozrast_Label.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Book_Vozrast_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Book_Vozrast_Label.Location = new System.Drawing.Point(19, 379);
            this.Book_Vozrast_Label.Name = "Book_Vozrast_Label";
            this.Book_Vozrast_Label.Size = new System.Drawing.Size(90, 42);
            this.Book_Vozrast_Label.TabIndex = 14;
            this.Book_Vozrast_Label.Text = "Возрастное \r\nограничение";
            // 
            // Book_BBK_Label
            // 
            this.Book_BBK_Label.AutoSize = true;
            this.Book_BBK_Label.BackColor = System.Drawing.Color.Transparent;
            this.Book_BBK_Label.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Book_BBK_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Book_BBK_Label.Location = new System.Drawing.Point(19, 457);
            this.Book_BBK_Label.Name = "Book_BBK_Label";
            this.Book_BBK_Label.Size = new System.Drawing.Size(40, 21);
            this.Book_BBK_Label.TabIndex = 15;
            this.Book_BBK_Label.Text = "ББК";
            // 
            // Oblozhka
            // 
            this.Oblozhka.Location = new System.Drawing.Point(166, 502);
            this.Oblozhka.Name = "Oblozhka";
            this.Oblozhka.Size = new System.Drawing.Size(107, 122);
            this.Oblozhka.TabIndex = 18;
            this.Oblozhka.TabStop = false;
            // 
            // Oblozhka_Label
            // 
            this.Oblozhka_Label.AutoSize = true;
            this.Oblozhka_Label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Oblozhka_Label.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Oblozhka_Label.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Oblozhka_Label.Location = new System.Drawing.Point(175, 551);
            this.Oblozhka_Label.Name = "Oblozhka_Label";
            this.Oblozhka_Label.Size = new System.Drawing.Size(91, 21);
            this.Oblozhka_Label.TabIndex = 19;
            this.Oblozhka_Label.Text = "Изображение";
            this.Oblozhka_Label.Click += new System.EventHandler(this.label10_Click);
            // 
            // Oblozhka_
            // 
            this.Oblozhka_.AutoSize = true;
            this.Oblozhka_.BackColor = System.Drawing.Color.Transparent;
            this.Oblozhka_.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Oblozhka_.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Oblozhka_.Location = new System.Drawing.Point(19, 560);
            this.Oblozhka_.Name = "Oblozhka_";
            this.Oblozhka_.Size = new System.Drawing.Size(104, 21);
            this.Oblozhka_.TabIndex = 20;
            this.Oblozhka_.Text = "Обложка книги";
            // 
            // AddBook_Submit
            // 
            this.AddBook_Submit.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBook_Submit.Location = new System.Drawing.Point(12, 637);
            this.AddBook_Submit.Name = "AddBook_Submit";
            this.AddBook_Submit.Size = new System.Drawing.Size(118, 32);
            this.AddBook_Submit.TabIndex = 21;
            this.AddBook_Submit.Text = "Далее";
            this.AddBook_Submit.UseVisualStyleBackColor = true;
            this.AddBook_Submit.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddBook_Cancel
            // 
            this.AddBook_Cancel.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBook_Cancel.Location = new System.Drawing.Point(247, 637);
            this.AddBook_Cancel.Name = "AddBook_Cancel";
            this.AddBook_Cancel.Size = new System.Drawing.Size(75, 32);
            this.AddBook_Cancel.TabIndex = 22;
            this.AddBook_Cancel.Text = "Отмена";
            this.AddBook_Cancel.UseVisualStyleBackColor = true;
            this.AddBook_Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(176, 646);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "0";
            this.label12.Visible = false;
            // 
            // Book_Author_Label
            // 
            this.Book_Author_Label.AutoSize = true;
            this.Book_Author_Label.BackColor = System.Drawing.Color.Transparent;
            this.Book_Author_Label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Book_Author_Label.Font = new System.Drawing.Font("Segoe Print", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Book_Author_Label.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Book_Author_Label.Location = new System.Drawing.Point(19, 94);
            this.Book_Author_Label.Name = "Book_Author_Label";
            this.Book_Author_Label.Size = new System.Drawing.Size(53, 21);
            this.Book_Author_Label.TabIndex = 25;
            this.Book_Author_Label.Text = "Автор";
            this.Book_Author_Label.Click += new System.EventHandler(this.label13_Click);
            // 
            // Book_Genre_Label
            // 
            this.Book_Genre_Label.AutoSize = true;
            this.Book_Genre_Label.BackColor = System.Drawing.Color.Transparent;
            this.Book_Genre_Label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Book_Genre_Label.Font = new System.Drawing.Font("Segoe Print", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Book_Genre_Label.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Book_Genre_Label.Location = new System.Drawing.Point(19, 159);
            this.Book_Genre_Label.Name = "Book_Genre_Label";
            this.Book_Genre_Label.Size = new System.Drawing.Size(44, 21);
            this.Book_Genre_Label.TabIndex = 26;
            this.Book_Genre_Label.Text = "Жанр";
            this.Book_Genre_Label.Click += new System.EventHandler(this.label3_Click);
            // 
            // Book_Publish_Label
            // 
            this.Book_Publish_Label.AutoSize = true;
            this.Book_Publish_Label.BackColor = System.Drawing.Color.Transparent;
            this.Book_Publish_Label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Book_Publish_Label.Font = new System.Drawing.Font("Segoe Print", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Book_Publish_Label.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Book_Publish_Label.Location = new System.Drawing.Point(19, 220);
            this.Book_Publish_Label.Name = "Book_Publish_Label";
            this.Book_Publish_Label.Size = new System.Drawing.Size(103, 21);
            this.Book_Publish_Label.TabIndex = 27;
            this.Book_Publish_Label.Text = "Издательство";
            this.Book_Publish_Label.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboBox7
            // 
            this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(166, 64);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(158, 22);
            this.comboBox7.TabIndex = 29;
            // 
            // comboBox8
            // 
            this.comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(166, 129);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(121, 22);
            this.comboBox8.TabIndex = 30;
            // 
            // comboBox9
            // 
            this.comboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Location = new System.Drawing.Point(166, 190);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(121, 22);
            this.comboBox9.TabIndex = 31;
            // 
            // Book_BBK_TextBox
            // 
            this.Book_BBK_TextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Book_BBK_TextBox.Location = new System.Drawing.Point(166, 454);
            this.Book_BBK_TextBox.MaxLength = 13;
            this.Book_BBK_TextBox.Name = "Book_BBK_TextBox";
            this.Book_BBK_TextBox.Size = new System.Drawing.Size(121, 22);
            this.Book_BBK_TextBox.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(19, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 21);
            this.label1.TabIndex = 34;
            this.label1.Text = "ISBN";
            // 
            // Book_ISBN_TextBox
            // 
            this.Book_ISBN_TextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Book_ISBN_TextBox.Location = new System.Drawing.Point(166, 326);
            this.Book_ISBN_TextBox.MaxLength = 13;
            this.Book_ISBN_TextBox.Name = "Book_ISBN_TextBox";
            this.Book_ISBN_TextBox.Size = new System.Drawing.Size(121, 22);
            this.Book_ISBN_TextBox.TabIndex = 33;
            // 
            // AddBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::Biblioteka_Design.Properties.Resources.menubibl2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(334, 681);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Book_ISBN_TextBox);
            this.Controls.Add(this.Book_BBK_TextBox);
            this.Controls.Add(this.comboBox9);
            this.Controls.Add(this.comboBox8);
            this.Controls.Add(this.comboBox7);
            this.Controls.Add(this.Book_Publish_Label);
            this.Controls.Add(this.Book_Genre_Label);
            this.Controls.Add(this.Book_Author_Label);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.AddBook_Cancel);
            this.Controls.Add(this.AddBook_Submit);
            this.Controls.Add(this.Oblozhka_);
            this.Controls.Add(this.Oblozhka_Label);
            this.Controls.Add(this.Oblozhka);
            this.Controls.Add(this.Book_BBK_Label);
            this.Controls.Add(this.Book_Vozrast_Label);
            this.Controls.Add(this.Book_Year_Label);
            this.Controls.Add(this.Book_Name_Label);
            this.Controls.Add(this.Book_Vozrast_Combo);
            this.Controls.Add(this.Book_Year_TextBox);
            this.Controls.Add(this.Book_Publish_Combo);
            this.Controls.Add(this.Book_Genre_Combo);
            this.Controls.Add(this.Book_Author_Combo);
            this.Controls.Add(this.Book_Name_TextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(350, 720);
            this.MinimumSize = new System.Drawing.Size(350, 720);
            this.Name = "AddBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление книг";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddBooks_FormClosed);
            this.Load += new System.EventHandler(this.AddBooks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Oblozhka)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox Book_Name_TextBox;
        public System.Windows.Forms.ComboBox Book_Author_Combo;
        public System.Windows.Forms.ComboBox Book_Genre_Combo;
        public System.Windows.Forms.ComboBox Book_Publish_Combo;
        public System.Windows.Forms.TextBox Book_Year_TextBox;
        public System.Windows.Forms.ComboBox Book_Vozrast_Combo;
        public System.Windows.Forms.Label Book_Name_Label;
        public System.Windows.Forms.Label Book_Year_Label;
        public System.Windows.Forms.Label Book_Vozrast_Label;
        public System.Windows.Forms.Label Book_BBK_Label;
        public System.Windows.Forms.PictureBox Oblozhka;
        public System.Windows.Forms.Label Oblozhka_Label;
        public System.Windows.Forms.Label Oblozhka_;
        public System.Windows.Forms.Button AddBook_Submit;
        public System.Windows.Forms.Button AddBook_Cancel;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label Book_Author_Label;
        public System.Windows.Forms.Label Book_Genre_Label;
        public System.Windows.Forms.Label Book_Publish_Label;
        public System.Windows.Forms.ComboBox comboBox7;
        public System.Windows.Forms.ComboBox comboBox8;
        public System.Windows.Forms.ComboBox comboBox9;
        public System.Windows.Forms.TextBox Book_BBK_TextBox;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox Book_ISBN_TextBox;
    }
}