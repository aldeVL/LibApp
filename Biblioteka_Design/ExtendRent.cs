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
    public partial class ExtendRent : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb";
        public OleDbCommand comm;
        public OleDbConnection myConnection;
        public OpenFileDialog fb = new OpenFileDialog();

        public ExtendRent(DateTime data, int rentID)
        {
            InitializeComponent();
            label2.Text = rentID.ToString();
            dateTimePicker1.Value = data;
        }

        public void update(string TabName, string stolb, string cel, long ID)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comm = new OleDbCommand($"UPDATE [{TabName}] SET [{stolb}] = '{cel}' WHERE [Код] = {ID}", myConnection);
            comm.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update("Аренда", "Дата окончания аренды", dateTimePicker1.Text, Convert.ToInt32(label2.Text));
            Thread.Sleep(500);
            if (System.Windows.Forms.Application.OpenForms["Rent"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Rent"] as Rent).updatearent();
                (System.Windows.Forms.Application.OpenForms["Rent"] as Rent).PaintRows();
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
