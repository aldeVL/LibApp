using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;
using System.IO;
using System.Security;

namespace Biblioteka_Design
{
    public partial class AddBooks : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb";
        public OleDbCommand comm;
        public OleDbConnection myConnection;
        public string fullpath;
        public string pathTo = System.Environment.CurrentDirectory + @"\images";
        public OpenFileDialog fb = new OpenFileDialog();

        public AddBooks()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (Book_Name_TextBox.Text == "")
            {
                MessageBox.Show("Заполните название книги!");
            }
            else
            {
                fb.FilterIndex = 2;
                fb.Filter = "jpg|*.jpg| png|*.png";

                if (fb.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        fullpath = Path.GetFullPath(fb.FileName);

                        //label10.Visible = false;
                        Oblozhka_Label.Text = "Изменить";

                        Image img = Image.FromFile(fb.FileName);

                        Oblozhka.SizeMode = PictureBoxSizeMode.StretchImage;

                        Oblozhka.Image = img;
                        label12.Text = "1";


                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Path.Combine(pathTo, Book_Name_TextBox.Text + ".png")))
                {
                    MessageBox.Show("Книга с таким названием уже есть!");
                }
                else
                {
                    foreach (TextBox rBtn in this.Controls.OfType<TextBox>())
                    {
                        if (rBtn.Text == "")
                        {
                            MessageBox.Show("Заполните все поля!");
                            return;
                        }
                    }

                    Books f1 = new Books();
                    string zaprosInsertBooks = "INSERT INTO Книги ([Обложка книги], [Название], [Автор], [Жанр], [Издательство], " +
                        "[Год издания], [ISBN], [Возрастное ограничение], " +
                        "[ББК]) VALUES (@image, @name, @autor, @genre, @publisher, @year, @isbn, @ogranich, @section)";
                    f1.comm = new OleDbCommand(zaprosInsertBooks, f1.myConnection);
                    if (label12.Text == "1")
                    {
                        f1.comm.Parameters.AddWithValue("image", Path.Combine("images", Book_Name_TextBox.Text + ".png"));
                    }
                    else
                    {
                        f1.comm.Parameters.AddWithValue("image", "empty");
                    }
                    f1.comm.Parameters.AddWithValue("name", Book_Name_TextBox.Text);
                    f1.comm.Parameters.AddWithValue("autor", Convert.ToInt32(comboBox7.Text));
                    f1.comm.Parameters.AddWithValue("genre", Convert.ToInt32(comboBox8.Text));
                    f1.comm.Parameters.AddWithValue("publisher", Convert.ToInt32(comboBox9.Text));
                    f1.comm.Parameters.AddWithValue("year", Convert.ToInt32(Book_Year_TextBox.Text));
                    f1.comm.Parameters.AddWithValue("isbn", Book_ISBN_TextBox.Text);
                    f1.comm.Parameters.AddWithValue("ogranich", Book_Vozrast_Combo.Text);
                    f1.comm.Parameters.AddWithValue("section", Book_BBK_TextBox.Text);
                    f1.comm.ExecuteNonQuery();

                   /* Thread.Sleep(1000);
                    f1.updatebooks(0);
                    f1.Show();
                    */
                    //this.Close();

                    if (label12.Text == "1")
                    {
                        File.Copy(fb.FileName, Path.Combine(pathTo, Book_Name_TextBox.Text + ".png"), false);
                    }
                    else { }

                    if (System.Windows.Forms.Application.OpenForms["AddExample"] == null)
                    {
                        Form addex = new AddExample(label12.Text);
                        addex.Show();
                    }
                    else { }
                    
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Заполните все поля!");
            }
            
        }


        public void loadCombos()
        {
            //comboBox1.SelectedIndex = 0;
            Book_Vozrast_Combo.SelectedIndex = 0;
            //--------------Заполнение авторов
            string zaprosAutors = "SELECT Авторы.[Код автора], Авторы.[Фамилия автора]+' '+Left(Авторы.[Имя автора],1)+'.'+Left(Авторы.[Отчество Автора],1) as [Фамилия автора] FROM Авторы";
            Book_Author_Combo.DataSource = nass(zaprosAutors);
            Book_Author_Combo.DisplayMember = "Фамилия автора";
            Book_Author_Combo.ValueMember = "Код автора";
            DataRowView jab2 = (DataRowView)Book_Author_Combo.SelectedItem;
            String valueofitem = jab2["Фамилия автора"].ToString();

            //--------------Заполнение жанров
            string zaprosGenre = "SELECT Жанры.[Код жанра], Жанры.[Название жанра] FROM Жанры";
            Book_Genre_Combo.DataSource = nass(zaprosGenre);
            Book_Genre_Combo.DisplayMember = "Название жанра";
            Book_Genre_Combo.ValueMember = "Код жанра";
            DataRowView jab3 = (DataRowView)Book_Genre_Combo.SelectedItem;
            String valueofite3 = jab3["Название жанра"].ToString();

            //--------------Заполнение издательств
            string zaprosPublish = "SELECT Издателства.[Код издательства], Издателства.[Наименование издателсьтва] FROM Издателства";
            Book_Publish_Combo.DataSource = nass(zaprosPublish);
            Book_Publish_Combo.DisplayMember = "Наименование издателсьтва";
            Book_Publish_Combo.ValueMember = "Код издательства";
            DataRowView jab4 = (DataRowView)Book_Publish_Combo.SelectedItem;
            String valueofite4 = jab4["Наименование издателсьтва"].ToString();
        }

        public void loadCombosCodes()
        {
            //--------------Заполнение кодов авторов
            string zaprosAutors = "SELECT Авторы.[Код автора], Авторы.[Фамилия автора] FROM Авторы";
            comboBox7.DataSource = nass(zaprosAutors);
            comboBox7.DisplayMember = "Код автора";
            comboBox7.ValueMember = "Код автора";
            DataRowView jab7 = (DataRowView)comboBox7.SelectedItem;
            String valueofitem = jab7["Фамилия автора"].ToString();

            //--------------Заполнение жанров
            string zaprosGenre = "SELECT Жанры.[Код жанра], Жанры.[Название жанра] FROM Жанры";
            comboBox8.DataSource = nass(zaprosGenre);
            comboBox8.DisplayMember = "Код жанра";
            comboBox8.ValueMember = "Код жанра";
            DataRowView jab8 = (DataRowView)comboBox8.SelectedItem;
            String valueofite8 = jab8["Название жанра"].ToString();

            //--------------Заполнение издательств
            string zaprosPublish = "SELECT Издателства.[Код издательства], Издателства.[Наименование издателсьтва] FROM Издателства";
            comboBox9.DataSource = nass(zaprosPublish);
            comboBox9.DisplayMember = "Код издателсьтва";
            comboBox9.ValueMember = "Код издательства";
            DataRowView jab9 = (DataRowView)comboBox9.SelectedItem;
            String valueofite9 = jab9["Наименование издателсьтва"].ToString();
            /*
            comboBox7.Visible = false;
            comboBox8.Visible = false;
            comboBox9.Visible = false;
            */

        }

        public DataTable nass(string query)
        {
            OleDbConnection conn = new OleDbConnection(connectString);
            var adapter = new OleDbDataAdapter(query, conn);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            adapter.Dispose();
            return ds;
        }
        public void newauthoradded()
        {
            string zaprosAutors = "SELECT Авторы.[Код автора], Авторы.[Фамилия автора]+' '+Left(Авторы.[Имя автора],1)+'.'+Left(Авторы.[Отчество Автора],1) as [Фамилия автора] FROM Авторы ";
            comboBox7.DataSource = nass(zaprosAutors);
            comboBox7.DisplayMember = "Код автора";
            comboBox7.ValueMember = "Код автора";
            DataRowView jab7 = (DataRowView)comboBox7.SelectedItem;
            String valueofitem = jab7["Фамилия автора"].ToString();

            Book_Author_Combo.DataSource = nass(zaprosAutors);
            Book_Author_Combo.DisplayMember = "Фамилия автора";
            Book_Author_Combo.ValueMember = "Код автора";
            DataRowView jab2 = (DataRowView)Book_Author_Combo.SelectedItem;
            String valueofitem2 = jab2["Фамилия автора"].ToString();
        }

        public void newapublishadded()
        {
            string zaprosPublish = "SELECT Издателства.[Код издательства], Издателства.[Наименование издателсьтва] FROM Издателства";
            comboBox9.DataSource = nass(zaprosPublish);
            comboBox9.DisplayMember = "Код издателсьтва";
            comboBox9.ValueMember = "Код издательства";
            DataRowView jab9 = (DataRowView)comboBox9.SelectedItem;
            String valueofite9 = jab9["Наименование издателсьтва"].ToString();

            Book_Publish_Combo.DataSource = nass(zaprosPublish);
            Book_Publish_Combo.DisplayMember = "Наименование издателсьтва";
            Book_Publish_Combo.ValueMember = "Код издательства";
            DataRowView jab4 = (DataRowView)Book_Publish_Combo.SelectedItem;
            String valueofite4 = jab4["Наименование издателсьтва"].ToString();
        }

        public void newgenreadded()
        {
            string zaprosGenre = "SELECT Жанры.[Код жанра], Жанры.[Название жанра] FROM Жанры";
            comboBox8.DataSource = nass(zaprosGenre);
            comboBox8.DisplayMember = "Код жанра";
            comboBox8.ValueMember = "Код жанра";
            DataRowView jab8 = (DataRowView)comboBox8.SelectedItem;
            String valueofite8 = jab8["Название жанра"].ToString();

            Book_Genre_Combo.DataSource = nass(zaprosGenre);
            Book_Genre_Combo.DisplayMember = "Название жанра";
            Book_Genre_Combo.ValueMember = "Код жанра";
            DataRowView jab3 = (DataRowView)Book_Genre_Combo.SelectedItem;
            String valueofite3 = jab3["Название жанра"].ToString();
        }

        private void AddBooks_Load(object sender, EventArgs e)
        {
            loading();
        }
        public void loading()
        {
            loadCombosCodes();
            loadCombos();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.SelectedIndex = Book_Author_Combo.SelectedIndex;
            comboBox8.SelectedIndex = Book_Genre_Combo.SelectedIndex;
            comboBox9.SelectedIndex = Book_Publish_Combo.SelectedIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Все изменеия будут отменены", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();
                File.Delete(Path.Combine(System.Environment.CurrentDirectory + @"\images", Book_Name_TextBox.Text + ".png"));
                comm = new OleDbCommand($"DELETE From [Книги] Where [Название] = '{Book_Name_TextBox.Text}'", myConnection);
                comm.ExecuteNonQuery();
                this.Close();
            }
            else { }
        }

        private void AddBooks_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddBook_Submit.PerformClick();
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Authors"] == null)
            {
                Form aut = null;
                aut = new Authors();
                aut.Show();
            }
            else { }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Publishers"] == null)
            {
                Form pub = null;
                pub = new Publishers();
                pub.Show();
            }
            else { }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Genres"] == null)
            {
                Form gen = null;
                gen = new Genres();
                gen.Show();
            }
            else { }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back) return;
            else
            e.Handled = true;
        }
    }
}
