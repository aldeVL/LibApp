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
namespace Biblioteka_Design
{
    public partial class Spisanie : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb";
        public OleDbCommand comm;
        public OleDbConnection myConnection;
        public string fullpath;
        public OpenFileDialog fb = new OpenFileDialog();

        public Spisanie(string tab, string zag, long IDex, int IDbook, string bl, int ggg)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            label2.Text = tab;
            label3.Text = zag;
            label4.Text = IDex.ToString();
            label5.Text = IDbook.ToString();
            label6.Text = bl;
            label8.Text = ggg.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Books f1 = new Books();
            AddBooks f2 = new AddBooks();

            string zaprosInsertSpis = "INSERT INTO Списанные ([Код книги], [Код экземпляра], [Дата списания], [Причина]) VALUES (@bookid, @exid, @date, @cause)";
            f1.comm = new OleDbCommand(zaprosInsertSpis, f1.myConnection);
            f1.comm.Parameters.AddWithValue("bookid", Convert.ToInt32(label5.Text));
            f1.comm.Parameters.AddWithValue("exid", Convert.ToInt32(label4.Text));
            f1.comm.Parameters.AddWithValue("date", DateTime.Now.ToShortDateString());
            f1.comm.Parameters.AddWithValue("cause", comboBox1.Text);
            f1.comm.ExecuteNonQuery();

            delete(label2.Text, label3.Text, Convert.ToInt32(label4.Text));
            this.Close();
            if (System.Windows.Forms.Application.OpenForms["Books"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Books"] as Books).updspis(Convert.ToInt32(label8.Text));
            }

        }

        public void delete(string TabName, string StolbName, int ID)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comm = new OleDbCommand($"DELETE From [{TabName}] Where [{StolbName}] = {ID}", myConnection);
            comm.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
