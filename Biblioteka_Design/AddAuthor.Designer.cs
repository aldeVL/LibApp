namespace Biblioteka_Design
{
    partial class AddAuthor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAuthor));
            this.Author_Surname = new System.Windows.Forms.TextBox();
            this.Author_Name = new System.Windows.Forms.TextBox();
            this.Author_Otch = new System.Windows.Forms.TextBox();
            this.Author_Country = new System.Windows.Forms.TextBox();
            this.Author_Surname_Label = new System.Windows.Forms.Label();
            this.Author_Name_Label = new System.Windows.Forms.Label();
            this.Author_Otch_Label = new System.Windows.Forms.Label();
            this.Author_Country_Label = new System.Windows.Forms.Label();
            this.Add_Author_Cancel = new System.Windows.Forms.Button();
            this.Add_Author_Submit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Author_Surname
            // 
            this.Author_Surname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Author_Surname.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Author_Surname.Location = new System.Drawing.Point(142, 27);
            this.Author_Surname.MaxLength = 20;
            this.Author_Surname.Name = "Author_Surname";
            this.Author_Surname.Size = new System.Drawing.Size(113, 22);
            this.Author_Surname.TabIndex = 0;
            this.Author_Surname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // Author_Name
            // 
            this.Author_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Author_Name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Author_Name.Location = new System.Drawing.Point(142, 94);
            this.Author_Name.MaxLength = 20;
            this.Author_Name.Name = "Author_Name";
            this.Author_Name.Size = new System.Drawing.Size(113, 22);
            this.Author_Name.TabIndex = 1;
            this.Author_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // Author_Otch
            // 
            this.Author_Otch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Author_Otch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Author_Otch.Location = new System.Drawing.Point(142, 159);
            this.Author_Otch.MaxLength = 20;
            this.Author_Otch.Name = "Author_Otch";
            this.Author_Otch.Size = new System.Drawing.Size(113, 22);
            this.Author_Otch.TabIndex = 2;
            this.Author_Otch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // Author_Country
            // 
            this.Author_Country.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Author_Country.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Author_Country.Location = new System.Drawing.Point(142, 222);
            this.Author_Country.MaxLength = 20;
            this.Author_Country.Name = "Author_Country";
            this.Author_Country.Size = new System.Drawing.Size(113, 22);
            this.Author_Country.TabIndex = 3;
            this.Author_Country.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // Author_Surname_Label
            // 
            this.Author_Surname_Label.AutoSize = true;
            this.Author_Surname_Label.BackColor = System.Drawing.Color.Transparent;
            this.Author_Surname_Label.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Author_Surname_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Author_Surname_Label.Location = new System.Drawing.Point(12, 30);
            this.Author_Surname_Label.Name = "Author_Surname_Label";
            this.Author_Surname_Label.Size = new System.Drawing.Size(117, 21);
            this.Author_Surname_Label.TabIndex = 5;
            this.Author_Surname_Label.Text = "Фамилия автора";
            // 
            // Author_Name_Label
            // 
            this.Author_Name_Label.AutoSize = true;
            this.Author_Name_Label.BackColor = System.Drawing.Color.Transparent;
            this.Author_Name_Label.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Author_Name_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Author_Name_Label.Location = new System.Drawing.Point(12, 97);
            this.Author_Name_Label.Name = "Author_Name_Label";
            this.Author_Name_Label.Size = new System.Drawing.Size(89, 21);
            this.Author_Name_Label.TabIndex = 6;
            this.Author_Name_Label.Text = "Имя автора";
            // 
            // Author_Otch_Label
            // 
            this.Author_Otch_Label.AutoSize = true;
            this.Author_Otch_Label.BackColor = System.Drawing.Color.Transparent;
            this.Author_Otch_Label.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Author_Otch_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Author_Otch_Label.Location = new System.Drawing.Point(12, 162);
            this.Author_Otch_Label.Name = "Author_Otch_Label";
            this.Author_Otch_Label.Size = new System.Drawing.Size(128, 21);
            this.Author_Otch_Label.TabIndex = 7;
            this.Author_Otch_Label.Text = "Отчество автора";
            // 
            // Author_Country_Label
            // 
            this.Author_Country_Label.AutoSize = true;
            this.Author_Country_Label.BackColor = System.Drawing.Color.Transparent;
            this.Author_Country_Label.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Author_Country_Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Author_Country_Label.Location = new System.Drawing.Point(12, 225);
            this.Author_Country_Label.Name = "Author_Country_Label";
            this.Author_Country_Label.Size = new System.Drawing.Size(111, 21);
            this.Author_Country_Label.TabIndex = 8;
            this.Author_Country_Label.Text = "Страна автора";
            // 
            // Add_Author_Cancel
            // 
            this.Add_Author_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_Author_Cancel.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add_Author_Cancel.Location = new System.Drawing.Point(186, 282);
            this.Add_Author_Cancel.Name = "Add_Author_Cancel";
            this.Add_Author_Cancel.Size = new System.Drawing.Size(75, 29);
            this.Add_Author_Cancel.TabIndex = 25;
            this.Add_Author_Cancel.Text = "Отмена";
            this.Add_Author_Cancel.UseVisualStyleBackColor = true;
            this.Add_Author_Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // Add_Author_Submit
            // 
            this.Add_Author_Submit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Add_Author_Submit.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add_Author_Submit.Location = new System.Drawing.Point(12, 282);
            this.Add_Author_Submit.Name = "Add_Author_Submit";
            this.Add_Author_Submit.Size = new System.Drawing.Size(118, 29);
            this.Add_Author_Submit.TabIndex = 24;
            this.Add_Author_Submit.Text = "Сохранить";
            this.Add_Author_Submit.UseVisualStyleBackColor = true;
            this.Add_Author_Submit.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 26;
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(261, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 27;
            this.label6.Visible = false;
            // 
            // AddAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Biblioteka_Design.Properties.Resources.menubibl2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(273, 323);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Add_Author_Cancel);
            this.Controls.Add(this.Add_Author_Submit);
            this.Controls.Add(this.Author_Country_Label);
            this.Controls.Add(this.Author_Otch_Label);
            this.Controls.Add(this.Author_Name_Label);
            this.Controls.Add(this.Author_Surname_Label);
            this.Controls.Add(this.Author_Country);
            this.Controls.Add(this.Author_Otch);
            this.Controls.Add(this.Author_Name);
            this.Controls.Add(this.Author_Surname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(289, 362);
            this.MinimumSize = new System.Drawing.Size(289, 362);
            this.Name = "AddAuthor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление автора";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Author_Surname;
        private System.Windows.Forms.TextBox Author_Name;
        private System.Windows.Forms.TextBox Author_Otch;
        private System.Windows.Forms.TextBox Author_Country;
        private System.Windows.Forms.Label Author_Surname_Label;
        private System.Windows.Forms.Label Author_Name_Label;
        private System.Windows.Forms.Label Author_Otch_Label;
        private System.Windows.Forms.Label Author_Country_Label;
        public System.Windows.Forms.Button Add_Author_Cancel;
        public System.Windows.Forms.Button Add_Author_Submit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}