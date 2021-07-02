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
using System.Reflection;
using System.IO;
using System.Security;
using System.Drawing.Imaging;
using Word = Microsoft.Office.Interop.Word;

namespace Biblioteka_Design
{
    public partial class Login : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public int LoginToken;
        public Login()
        {
            InitializeComponent();
            textBox1.Text = "admin";
            textBox2.Text = "admin";
            button1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usr = textBox1.Text;
            string psw = textBox2.Text;
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            string str = $"Select * From [Пользователи] Where Логин = '{textBox1.Text}' And Пароль = '{textBox2.Text}'";
            cmd.CommandText = str;

            dr = cmd.ExecuteReader();
            Menu f = new Menu();
            if (dr.Read())
            {
                if (textBox1.Text != "admin")
                {
                    f.toolStripMenuItem1.Text = "Вы вошли в систему как: Читатель";
                    f.Show();
                    this.Visible = false;
                }
                else
                {
                    f.toolStripMenuItem1.Text = "Вы вошли в систему как: Библиотекарь";
                    //MessageBox.Show("Добро пожаловать " + textBox1.Text);
                    f.Show();
                    this.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }

            con.Close();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label3.Visible == false)
            {
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
            }
            else
            {
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
            }
        }
    }
}
