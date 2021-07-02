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
    public partial class BookEdit : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb";
        public OleDbCommand comm;
        public OleDbConnection myConnection;
        public string fullpath;
        public string pathTo = System.Environment.CurrentDirectory + @"\images";
        public OpenFileDialog fb = new OpenFileDialog();

        public BookEdit(int idbook, string namebook, string auth, string genre, string publish, int god, string vozrast, string sect, string isbn)
        {
            InitializeComponent();
            loadCombosCodes();
            loadCombos();

            textBox1.Text = namebook;
            comboBox2.Text = auth;
            comboBox3.Text = genre;
            comboBox4.Text = publish;
            textBox2.Text = god.ToString();
            comboBox5.Text = vozrast;
            textBox3.Text = sect;
            label12.Text = idbook.ToString();
            textBox4.Text = isbn;
        }

        public void loadCombos()
        {
            //comboBox1.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            //--------------Заполнение авторов
            string zaprosAutors = "SELECT Авторы.[Код автора], Авторы.[Фамилия автора]+' '+Left(Авторы.[Имя автора],1)+'.'+Left(Авторы.[Отчество Автора],1) as [Фамилия автора] FROM Авторы";
            comboBox2.DataSource = nass(zaprosAutors);
            comboBox2.DisplayMember = "Фамилия автора";
            comboBox2.ValueMember = "Код автора";
            DataRowView jab2 = (DataRowView)comboBox2.SelectedItem;
            String valueofitem = jab2["Фамилия автора"].ToString();

            //--------------Заполнение жанров
            string zaprosGenre = "SELECT Жанры.[Код жанра], Жанры.[Название жанра] FROM Жанры";
            comboBox3.DataSource = nass(zaprosGenre);
            comboBox3.DisplayMember = "Название жанра";
            comboBox3.ValueMember = "Код жанра";
            DataRowView jab3 = (DataRowView)comboBox3.SelectedItem;
            String valueofite3 = jab3["Название жанра"].ToString();

            //--------------Заполнение издательств
            string zaprosPublish = "SELECT Издателства.[Код издательства], Издателства.[Наименование издателсьтва] FROM Издателства";
            comboBox4.DataSource = nass(zaprosPublish);
            comboBox4.DisplayMember = "Наименование издателсьтва";
            comboBox4.ValueMember = "Код издательства";
            DataRowView jab4 = (DataRowView)comboBox4.SelectedItem;
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
            String valueofitem = jab7["Код автора"].ToString();

            //--------------Заполнение жанров
            string zaprosGenre = "SELECT Жанры.[Код жанра], Жанры.[Название жанра] FROM Жанры";
            comboBox8.DataSource = nass(zaprosGenre);
            comboBox8.DisplayMember = "Код жанра";
            comboBox8.ValueMember = "Код жанра";
            DataRowView jab8 = (DataRowView)comboBox8.SelectedItem;
            String valueofite8 = jab8["Код жанра"].ToString();

            //--------------Заполнение издательств
            string zaprosPublish = "SELECT Издателства.[Код издательства], Издателства.[Наименование издателсьтва] FROM Издателства";
            comboBox9.DataSource = nass(zaprosPublish);
            comboBox9.DisplayMember = "Код издателсьтва";
            comboBox9.ValueMember = "Код издательства";
            DataRowView jab9 = (DataRowView)comboBox9.SelectedItem;
            String valueofite9 = jab9["Код издательства"].ToString();

            comboBox7.Visible = false;
            comboBox8.Visible = false;
            comboBox9.Visible = false;


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

        private void BookEdit_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.SelectedIndex = comboBox2.SelectedIndex;
            comboBox8.SelectedIndex = comboBox3.SelectedIndex;
            comboBox9.SelectedIndex = comboBox4.SelectedIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Все изменеия будут отменены", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                
                this.Close();
            }
            else { }
        }

        private void BookEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox7.Visible = true;
            int idbug = Convert.ToInt32(label12.Text);
            string n = textBox1.Text;
            int a = Convert.ToInt32(comboBox7.Text);
            int g = Convert.ToInt32(comboBox8.Text);
            int p = Convert.ToInt32(comboBox9.Text);
            int y = Convert.ToInt32(textBox2.Text);
            string v = comboBox5.Text;
            string s = textBox3.Text;
            update(idbug, n, a, g, p, y, v, s, textBox4.Text);
            if (System.Windows.Forms.Application.OpenForms["Books"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Books"] as Books).updatebooks(2);
            }
            this.Close();
        }

        public void update(int idbook, string namebook, int auth, int genre, int publish, int god, string vozrast, string sect, string isbn)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comm = new OleDbCommand($"UPDATE Книги SET Книги.[Название] = '{namebook}', Книги.[Автор] = '{auth}', " +
                $"Книги.[Жанр] = '{genre}', Книги.[Издательство] = '{publish}'," +
                $" Книги.[Год издания] = '{god}', Книги.[ISBN] = '{isbn}', Книги.[Возрастное ограничение] = '{vozrast}', " +
                $"Книги.[ББК] = '{sect}' WHERE [Код книги] = {idbook}", myConnection);
            comm.ExecuteNonQuery();
        }


        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        public void newauthoradded()
        {
            string a = comboBox2.Text;
            string zaprosAutors = "SELECT Авторы.[Код автора], Авторы.[Фамилия автора]+' '+Left(Авторы.[Имя автора],1)+'.'+Left(Авторы.[Отчество Автора],1) as [Фамилия автора] FROM Авторы";
            comboBox7.DataSource = nass(zaprosAutors);
            comboBox7.DisplayMember = "Код автора";
            comboBox7.ValueMember = "Код автора";
            DataRowView jab7 = (DataRowView)comboBox7.SelectedItem;
            String valueofitem = jab7["Фамилия автора"].ToString();

            comboBox2.DataSource = nass(zaprosAutors);
            comboBox2.DisplayMember = "Фамилия автора";
            comboBox2.ValueMember = "Код автора";
            DataRowView jab2 = (DataRowView)comboBox2.SelectedItem;
            String valueofitem2 = jab2["Фамилия автора"].ToString();

            comboBox2.Text = a;
        }

        public void newapublishadded()
        {
            string a = comboBox4.Text;

            string zaprosPublish = "SELECT Издателства.[Код издательства], Издателства.[Наименование издателсьтва] FROM Издателства";
            comboBox9.DataSource = nass(zaprosPublish);
            comboBox9.DisplayMember = "Код издателсьтва";
            comboBox9.ValueMember = "Код издательства";
            DataRowView jab9 = (DataRowView)comboBox9.SelectedItem;
            String valueofite9 = jab9["Наименование издателсьтва"].ToString();

            comboBox4.DataSource = nass(zaprosPublish);
            comboBox4.DisplayMember = "Наименование издателсьтва";
            comboBox4.ValueMember = "Код издательства";
            DataRowView jab4 = (DataRowView)comboBox4.SelectedItem;
            String valueofite4 = jab4["Наименование издателсьтва"].ToString();

            comboBox4.Text = a;
        }

        public void newgenreadded()
        {
            string a = comboBox3.Text;

            string zaprosGenre = "SELECT Жанры.[Код жанра], Жанры.[Название жанра] FROM Жанры";
            comboBox8.DataSource = nass(zaprosGenre);
            comboBox8.DisplayMember = "Код жанра";
            comboBox8.ValueMember = "Код жанра";
            DataRowView jab8 = (DataRowView)comboBox8.SelectedItem;
            String valueofite8 = jab8["Название жанра"].ToString();

            comboBox3.DataSource = nass(zaprosGenre);
            comboBox3.DisplayMember = "Название жанра";
            comboBox3.ValueMember = "Код жанра";
            DataRowView jab3 = (DataRowView)comboBox3.SelectedItem;
            String valueofite3 = jab3["Название жанра"].ToString();

            comboBox3.Text = a;
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
    }
}
