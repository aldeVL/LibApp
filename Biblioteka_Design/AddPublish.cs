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
    public partial class AddPublish : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb";
        public OleDbCommand comm;
        public OleDbConnection myConnection;
        public string fullpath;
        public OpenFileDialog fb = new OpenFileDialog();

        public AddPublish(int token, int id, string name, string adress)
        {
            InitializeComponent();
            label5.Text = token.ToString();
            label6.Text = id.ToString();
            textBox1.Text = name;
            textBox2.Text = adress;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Books f1 = new Books();
                AddBooks f2 = new AddBooks();
                if (label5.Text != "1")
                {
                    string zaprosInsertPublish = "INSERT INTO Издателства ([Наименование издателсьтва], [Адрес издательства]) VALUES (@name, @adress)";
                    f1.comm = new OleDbCommand(zaprosInsertPublish, f1.myConnection);
                    f1.comm.Parameters.AddWithValue("name", textBox1.Text);
                    f1.comm.Parameters.AddWithValue("adress", textBox2.Text);
                    f1.comm.ExecuteNonQuery();

                    if (System.Windows.Forms.Application.OpenForms["Publishers"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["Publishers"] as Publishers).updateauthors();
                    }
                    if (System.Windows.Forms.Application.OpenForms["AddBooks"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["AddBooks"] as AddBooks).newapublishadded();
                    }

                    if (System.Windows.Forms.Application.OpenForms["BookEdit"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["BookEdit"] as BookEdit).newapublishadded();
                    }
                    this.Close();
                }
                else
                {
                    this.Text = "Редактирование издательства";
                    int id = Convert.ToInt32(label6.Text);
                    string a = textBox1.Text;
                    string g = textBox2.Text;
                    update(id, a, g);
                    if (System.Windows.Forms.Application.OpenForms["Publishers"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["Publishers"] as Publishers).updateauthors();
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

        public void update(int idauth, string nameauth, string surname)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comm = new OleDbCommand($"UPDATE Издателства SET Издателства.[Наименование издателсьтва] = '{nameauth}', Издателства.[Адрес издательства] = '{surname}' WHERE Издателства.[Код издательства] = {idauth}", myConnection);
            comm.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }
    }
}
