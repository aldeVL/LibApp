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
    public partial class AddAuthor : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb";
        public OleDbCommand comm;
        public OleDbConnection myConnection;
        public string fullpath;
        public OpenFileDialog fb = new OpenFileDialog();

        public AddAuthor(int flag, int id, string surn, string nam, string ot, string coun)
        {
            InitializeComponent();
            label5.Text = flag.ToString();
            label6.Text = id.ToString();
            Author_Surname.Text = surn;
            Author_Name.Text = nam;
            Author_Otch.Text = ot;
            Author_Country.Text = coun;
        }

        public void bbbf(string x, string y, string z, string c, out string box1, out string box2, out string box3, out string box4)
        {

                string box11 = x.Substring(0, 1).ToUpper();
                string box22 = y.Substring(0, 1).ToUpper();
                string box33 = z.Substring(0, 1).ToUpper();
                string box44 = c.Substring(0, 1).ToUpper();
                box1 = box11 + x.Substring(1);
                box2 = box22 + y.Substring(1);
                box3 = box33 + z.Substring(1);
                box4 = box44 + c.Substring(1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string q = "";
                string w = "";
                string t = "";
                string r = "";
                foreach (TextBox rBtn in this.Controls.OfType<TextBox>())
                {
                    if (rBtn.Text == "")
                    {
                        MessageBox.Show("Заполните все поля!");
                        return;
                    }
                }
                bbbf(Author_Surname.Text, Author_Name.Text, Author_Otch.Text, Author_Country.Text, out q, out w, out t, out r);
                Author_Surname.Text = q;
                Author_Name.Text = w;
                Author_Otch.Text = t;
                Author_Country.Text = r;

                Books f1 = new Books();
                AddBooks f2 = new AddBooks();
                if (label5.Text != "1")
                {
                    string zaprosInsertAuthor = "INSERT INTO Авторы ([Фамилия автора], [Имя автора], [Отчество Автора], [Страна автора]) VALUES (@surname, @name, @otch, @country)";
                    f1.comm = new OleDbCommand(zaprosInsertAuthor, f1.myConnection);
                    f1.comm.Parameters.AddWithValue("surname", Author_Surname.Text);
                    f1.comm.Parameters.AddWithValue("name", Author_Name.Text);
                    f1.comm.Parameters.AddWithValue("otch", Author_Otch.Text);
                    f1.comm.Parameters.AddWithValue("country", Author_Country.Text);
                    f1.comm.ExecuteNonQuery();

                    if (System.Windows.Forms.Application.OpenForms["Authors"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["Authors"] as Authors).updateauthors();
                    }
                    
                    if (System.Windows.Forms.Application.OpenForms["AddBooks"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["AddBooks"] as AddBooks).newauthoradded();
                    }

                    if (System.Windows.Forms.Application.OpenForms["BookEdit"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["BookEdit"] as BookEdit).newauthoradded();
                    }
                    this.Close();
                }
                else
                {
                    this.Text = "Редактирование автора";
                    int id = Convert.ToInt32(label6.Text);
                    string a = Author_Surname.Text;
                    string g = Author_Name.Text;
                    string p = Author_Otch.Text;
                    string y = Author_Country.Text;
                    update(id, g, a, p, y);
                    if (System.Windows.Forms.Application.OpenForms["Authors"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["Authors"] as Authors).updateauthors();
                    }
                    if (System.Windows.Forms.Application.OpenForms["Books"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["Books"] as Books).updatebooks(1);
                    }
                    this.Close();
                }

            }
            catch (System.FormatException)
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        public void update(int idauth, string nameauth, string surname, string otch, string country)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comm = new OleDbCommand($"UPDATE Авторы SET Авторы.[Фамилия автора] = '{surname}', Авторы.[Имя автора] = '{nameauth}', Авторы.[Отчество Автора] = '{otch}'," +
                $" Авторы.[Страна автора] = '{country}'  WHERE [Код автора] = {idauth}", myConnection);
            comm.ExecuteNonQuery();
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            else
            e.Handled = true;
        }
    }
}
