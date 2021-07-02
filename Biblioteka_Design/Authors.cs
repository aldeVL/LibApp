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
    public partial class Authors : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb";
        public OleDbCommand comm;
        public OleDbConnection myConnection;
        public Bitmap ggggg = new Bitmap(System.Environment.CurrentDirectory + @"\images\blank.png");
        public int prokrutka = 0;
        Form myform = null;

        public string zaprosauthor = "Select [Код автора], [Фамилия автора], [Имя автора], [Отчество автора], [Страна автора] From Авторы";

        public Authors()
        {
            InitializeComponent();
            label1.Text = "Фамилия автора";
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            dataGridView1.DataSource = zagruzka(zaprosauthor);
            dataGridView1.Columns["Код автора"].Visible = false;
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

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void добавитьАвтораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["AddAuthor"] == null)
            {
                Form addaut = null;
                addaut = new AddAuthor(0, 0, null, null, null, null);
                addaut.Show();
            }
            else { }
        }

        public void updateauthors()
        {
            try
            {
                prokrutka = dataGridView1.FirstDisplayedScrollingRowIndex;
                dataGridView1.DataSource = null;
                Thread.Sleep(500);
                dataGridView1.DataSource = zagruzka(zaprosauthor);
                dataGridView1.Columns["Код автора"].Visible = false;
                dataGridView1.FirstDisplayedScrollingRowIndex = prokrutka;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                dataGridView1.DataSource = zagruzka(zaprosauthor);
                dataGridView1.Columns["Код автора"].Visible = false;
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int authid = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код автора"].Value.ToString());
                string surname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Фамилия автора"].Value.ToString();
                string authorname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Имя автора"].Value.ToString();
                string otch = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Отчество Автора"].Value.ToString();
                string countr = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Страна автора"].Value.ToString();

                if (System.Windows.Forms.Application.OpenForms["AddAuthor"] == null)
                {
                    Form addaut = null;
                    addaut = new AddAuthor(1, authid, surname, authorname, otch, countr);
                    addaut.Show();
                }
                else { }
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Выберите запись!");
            }
        }

        public void delete(string TabName, string StolbName, long ID)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comm = new OleDbCommand($"DELETE From [{TabName}] Where [{StolbName}] = {ID}", myConnection);
            comm.ExecuteNonQuery();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string delTableName = "Авторы";
                string delStolbName = "Код автора";
                long delID = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[$"{delStolbName}"].Value.ToString());
                delete(delTableName, delStolbName, delID);
                updateauthors();
                if (System.Windows.Forms.Application.OpenForms["AddBooks"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["AddBooks"] as AddBooks).newauthoradded();
                }
                if (System.Windows.Forms.Application.OpenForms["BookEdit"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["BookEdit"] as BookEdit).newauthoradded();
                }
            }
            else { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
            {
                dataGridView1.Columns[dataGridView1.SelectedCells[0].ColumnIndex].ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void изменитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int authid = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код автора"].Value.ToString());
            string surname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Фамилия автора"].Value.ToString();
            string authorname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Имя автора"].Value.ToString();
            string otch = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Отчество Автора"].Value.ToString();
            string countr = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Страна автора"].Value.ToString();

            if (System.Windows.Forms.Application.OpenForms["AddAuthor"] == null)
            {
                Form addaut = null;
                addaut = new AddAuthor(1, authid, surname, authorname, otch, countr);
                addaut.Show();
            }
            else { }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                (dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("Convert([{0}], System.String) LIKE '{1}%'", label1.Text, textBox1.Text);
            }
            else { }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            foreach (RadioButton rBtn in panel2.Controls.OfType<RadioButton>())
            {
                if (rBtn.Checked)
                {
                    string ghg = rBtn.Text;
                    ghg = ghg.Replace("\r", string.Empty);
                    ghg = ghg.Replace("\n", string.Empty);
                    label1.Text = ghg;
                    //(dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("Convert([{0}], System.String) LIKE '{1}%'", label9.Text, textBox1.Text);
                    //imgstolb2();
                    break;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (RadioButton rBtn in panel2.Controls.OfType<RadioButton>())
            {
                rBtn.Checked = false;
                textBox1.Text = "";
                label1.Text = "Фамилия автора";
                
            }
            (dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter = null;
        }
    }
}
