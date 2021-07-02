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
    public partial class AddClient : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb";
        public OleDbCommand comm;
        public OleDbConnection myConnection;
        public string fullpath;
        public OpenFileDialog fb = new OpenFileDialog();

        public AddClient(int flag, double bilet_id, string surname, string name, string otch, double pasport, double phone, string adress)
        {
            InitializeComponent();
            label8.Text = flag.ToString();
            if (label8.Text != "0")
            {
                textBox1.ReadOnly = true;
                textBox1.Text = bilet_id.ToString();
                textBox2.Text = surname;
                textBox3.Text = name;
                textBox4.Text = otch;
                textBox5.Text = pasport.ToString();
                textBox6.Text = phone.ToString();
                textBox7.Text = adress;
            }
            else { textBox1.ReadOnly = false; }
        }
        public void bbbf(string x, string y, string z, out string box1, out string box2, out string box3)
        {
            string box11 = x.Substring(0, 1).ToUpper();
            string box22 = y.Substring(0, 1).ToUpper();
            string box33 = z.Substring(0, 1).ToUpper();

            box1 = box11 + x.Substring(1);
            box2 = box22 + y.Substring(1);
            box3 = box33 + z.Substring(1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string q = "";
                string w = "";
                string t = "";
                foreach (TextBox rBtn in this.Controls.OfType<TextBox>())
                {
                    if (rBtn.Text == "")
                    {
                        MessageBox.Show("Заполните все поля!");
                        return;
                    }
                }
                bbbf(textBox2.Text, textBox3.Text, textBox4.Text, out q, out w, out t);
                textBox2.Text = q;
                textBox3.Text = w;
                textBox4.Text = t;

                Books f1 = new Books();
                AddBooks f2 = new AddBooks();
                if (label8.Text != "1")
                {
                    string zaprosInsertClient = "INSERT INTO Читатели ([Номер читательского билета], [Фамилия Читателя], [Имя читателя], [Отчество читателя], " +
                        "[Паспорт читателя], [Телефон читателя], [Адрес читателя]) VALUES (@bilet, @surname, @name, @otch, @pasport, @phone, @adress)";
                    f1.comm = new OleDbCommand(zaprosInsertClient, f1.myConnection);
                    f1.comm.Parameters.AddWithValue("bilet", Convert.ToDouble(textBox1.Text));
                    f1.comm.Parameters.AddWithValue("surname", textBox2.Text);
                    f1.comm.Parameters.AddWithValue("name", textBox3.Text);
                    f1.comm.Parameters.AddWithValue("otch", textBox4.Text);
                    f1.comm.Parameters.AddWithValue("pasport", Convert.ToDouble(textBox5.Text));
                    f1.comm.Parameters.AddWithValue("phone", Convert.ToDouble(textBox6.Text));
                    f1.comm.Parameters.AddWithValue("adress", textBox7.Text);
                    f1.comm.ExecuteNonQuery();

                    if (System.Windows.Forms.Application.OpenForms["Clients"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["Clients"] as Clients).updateclients();
                    }

                    if (System.Windows.Forms.Application.OpenForms["Books"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["Books"] as Books).updatebooks(1);
                    }

                    if (System.Windows.Forms.Application.OpenForms["AddRent"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["AddRent"] as AddRent).newclientadded();
                    }
                    this.Close();
                }
                else
                {
                    this.Text = "Редактирование читателя";
                    double id = Convert.ToDouble(textBox1.Text);
                    string a = textBox2.Text;
                    string g = textBox3.Text;
                    string p = textBox4.Text;
                    double y = Convert.ToDouble(textBox5.Text);
                    double h = Convert.ToDouble(textBox6.Text);
                    string n = textBox7.Text;
                    update(id, a, g, p, y, h, n);
                    if (System.Windows.Forms.Application.OpenForms["Clients"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["Clients"] as Clients).updateclients();
                    }
                    this.Close();
                } 

            }
            catch (System.FormatException)
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        public void update(double bilet, string surname, string name, string otch, double pasport, double phone, string adress)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comm = new OleDbCommand($"UPDATE Читатели SET Читатели.[Фамилия Читателя] = '{surname}', Читатели.[Имя читателя] = '{name}', " +
                $"Читатели.[Отчество читателя] = '{otch}', Читатели.[Паспорт читателя] = {pasport}, " +
                $"Читатели.[Телефон читателя] = {phone}, Читатели.[Адрес читателя] = '{adress}' WHERE Читатели.[Номер читательского билета] = {bilet}", myConnection);
            comm.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            else
            e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back) return;
            else
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }
    }
}
