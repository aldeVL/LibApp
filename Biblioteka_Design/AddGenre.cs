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
    public partial class AddGenre : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb";
        public OleDbCommand comm;
        public OleDbConnection myConnection;
        public string fullpath;
        public OpenFileDialog fb = new OpenFileDialog();
        public AddGenre(int marker, int genid, string genname)
        {
            InitializeComponent();
            label2.Text = marker.ToString();
            label3.Text = genid.ToString();
            label4.Text = genname;
            textBox1.Text = genname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Books f1 = new Books();
                AddBooks f2 = new AddBooks();
                if (label2.Text != "1")
                {
                    string zaprosInsertGenre = "INSERT INTO Жанры ([Название жанра]) VALUES (@name)";
                    f1.comm = new OleDbCommand(zaprosInsertGenre, f1.myConnection);
                    f1.comm.Parameters.AddWithValue("name", textBox1.Text);
                    f1.comm.ExecuteNonQuery();

                    if (System.Windows.Forms.Application.OpenForms["Genres"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["Genres"] as Genres).updategenres();
                    }

                    if (System.Windows.Forms.Application.OpenForms["AddBooks"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["AddBooks"] as AddBooks).newgenreadded();
                    }

                    if (System.Windows.Forms.Application.OpenForms["BookEdit"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["BookEdit"] as BookEdit).newgenreadded();
                    }
                    this.Close();
                }
                else
                {
                    this.Text = "Редактирование жанра";
                    int id = Convert.ToInt32(label3.Text);
                    string a = textBox1.Text;
                    update(id, a);
                    if (System.Windows.Forms.Application.OpenForms["Genres"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["Genres"] as Genres).updategenres();
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
        public void update(int idauth, string nameauth)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comm = new OleDbCommand($"UPDATE Жанры SET Жанры.[Название жанра] = '{nameauth}' WHERE Жанры.[Код жанра] = {idauth}", myConnection);
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
