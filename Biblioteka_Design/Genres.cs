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
    public partial class Genres : Form
    {

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb";
        public OleDbCommand comm;
        public OleDbConnection myConnection;
        public int prokrutka = 0;
        Form myform = null;
        public string zaprosgenres = "Select [Код жанра], [Название жанра] From Жанры";
        public Genres()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DataSource = zagruzka(zaprosgenres);
            dataGridView1.Columns["Код жанра"].Visible = false;
        }
        public DataTable zagruzka(string zapr)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            DataTable table = new DataTable();
            comm = new OleDbCommand(zapr, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
            adapter.Fill(table);
            return table;
        }
        public void updategenres()
        {
            try
            {
                prokrutka = dataGridView1.FirstDisplayedScrollingRowIndex;
                dataGridView1.DataSource = null;
                Thread.Sleep(500);
                dataGridView1.DataSource = zagruzka(zaprosgenres);
                dataGridView1.Columns["Код жанра"].Visible = false;
                dataGridView1.FirstDisplayedScrollingRowIndex = prokrutka;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                dataGridView1.DataSource = zagruzka(zaprosgenres);
                dataGridView1.Columns["Код жанра"].Visible = false;
            }
        }
        public void delete(string TabName, string StolbName, long ID)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comm = new OleDbCommand($"DELETE From [{TabName}] Where [{StolbName}] = {ID}", myConnection);
            comm.ExecuteNonQuery();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
            {
                dataGridView1.Columns[dataGridView1.SelectedCells[0].ColumnIndex].ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string delTableName = "Жанры";
                string delStolbName = "Код жанра";
                long delID = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[$"{delStolbName}"].Value.ToString());
                delete(delTableName, delStolbName, delID);
                updategenres();
                if (System.Windows.Forms.Application.OpenForms["AddBooks"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["AddBooks"] as AddBooks).newgenreadded();
                }
                if (System.Windows.Forms.Application.OpenForms["BookEdit"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["BookEdit"] as BookEdit).newgenreadded();
                }

            }
            else { }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int pubid = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код жанра"].Value.ToString());
            string pubname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Название жанра"].Value.ToString();


            if (System.Windows.Forms.Application.OpenForms["AddGenre"] == null)
            {
                Form addgen = null;
                addgen = new AddGenre(1, pubid, pubname);
                addgen.Show();
            }
            else { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int amountToIncrease = panel2.Width;
            if (panel2.Visible != false)
            {
                panel2.Visible = false;
                dataGridView1.Width += amountToIncrease;
                button1.Location = new Point(button1.Location.X + amountToIncrease, button1.Location.Y);
                button1.Text = "Показать";
            }
            else
            {
                panel2.Visible = true;
                dataGridView1.Width -= amountToIncrease;
                button1.Location = new Point(button1.Location.X - amountToIncrease, button1.Location.Y);
                button1.Text = "Скрыть";
            }
        }

        private void добавитьЖанрToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms["AddGenre"] == null)
            {
                Form addgen = null;
                addgen = new AddGenre(0, 0, null);
                addgen.Show();
            }
            else { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                (dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("[Название жанра] LIKE '{0}%'", textBox1.Text);
            }
            else { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            (dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter = null;
        }
    }
}
