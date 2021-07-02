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
    public partial class AddExample : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb";
        public OleDbCommand comm;
        public OleDbConnection myConnection;
        public string fullpath;
        public string pathTo = System.Environment.CurrentDirectory + @"\images";
        public OpenFileDialog fb = new OpenFileDialog();

        public int nomer;

        public AddExample(string t)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            label4.Text = t;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string zaprosNaid = "";
                    foreach (TextBox rBtn in this.Controls.OfType<TextBox>())
                    {
                        if (rBtn.Text == "")
                        {
                            MessageBox.Show("Заполните все поля!");
                            return;
                        }
                    }
                    Books f1 = new Books();
                    AddBooks f2 = Application.OpenForms["AddBooks"] as AddBooks;
                    if (label4.Text != "1" && label4.Text != "0")
                    {                 
                        zaprosNaid = $"Select [Код книги] From Книги Where [Название] = '{label4.Text}'";
                    }
                    else 
                    {
                        zaprosNaid = $"Select [Код книги] From Книги Where [Название] = '{f2.Book_Name_TextBox.Text}'";
                    }
                    string zaprosInsertBooks = "INSERT INTO Экземпляр ([Статус], [Дата поступления], [Код книги])" +
                        "VALUES (@status, @date_coming, @book_id)";
                    int nomer = vibor_id(zaprosNaid);
                    f1.comm = new OleDbCommand(zaprosInsertBooks, f1.myConnection);
                    f1.comm.Parameters.AddWithValue("status", comboBox1.Text);
                    f1.comm.Parameters.AddWithValue("date_coming", dateTimePicker1.Text);
                    f1.comm.Parameters.AddWithValue("book_id", nomer);

                    if (textBox3.Text != null)
                    {
                        for (int i = 0; i < Convert.ToInt32(textBox3.Text); i++)
                        {
                            f1.comm.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите кол-во экземпляров");
                    }

                    if (System.Windows.Forms.Application.OpenForms["Books"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["Books"] as Books).updatebooks(2);
                    }
                    this.Close();
                    f2.Close();
                    /* Thread.Sleep(1000);
                     f1.updatebooks(0);
                     f1.Show();
                     */
                    /*
                   this.Close();
                   if (System.Windows.Forms.Application.OpenForms["Books"] != null)
                   {
                       (System.Windows.Forms.Application.OpenForms["Books"] as Books).updatebooks(2);
                   }
                   */
                
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Неверный формат данных!");
            }
            catch (System.Data.OleDb.OleDbException)
            {
                MessageBox.Show("Книга не найдена!");
            }
            catch (System.NullReferenceException)
            {

            }



        }

        public int vibor_id(string zapr)
        {
            
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comm = new OleDbCommand(zapr, myConnection);
            OleDbDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                nomer = Convert.ToInt32(reader.GetValue(0).ToString());
            }
            return nomer;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back) return;
            else
                e.Handled = true;
        }
    }
}
