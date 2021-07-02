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
    public partial class Clients : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb";
        public OleDbCommand comm;
        public OleDbConnection myConnection;
        public int prokrutka = 0;
        Form myform = null;

        public string zaprosclients = "Select * From Читатели";

        public Clients()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DataSource = zagruzka(zaprosclients);
            dataGridView1.Columns["Код"].Visible = false;
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
            if (System.Windows.Forms.Application.OpenForms["Books"] != null)
            {
                this.Close();
            }
            else if (System.Windows.Forms.Application.OpenForms["Menu"] == null)
            {
                Menu main = new Menu();
                main.toolStripMenuItem1.Text = this.toolStripMenuItem1.Text;
                main.Show();
            }
            else { }
        }

        private void добавитьЧитателяToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms["AddClient"] == null)
            {
                Form addcl = null;
                addcl = new AddClient(0, 0, null, null, null, 0, 0, null);
                addcl.Show();
            }
            else { }
        }

        public void updateclients()
        {
            try
            {
                prokrutka = dataGridView1.FirstDisplayedScrollingRowIndex;
                dataGridView1.DataSource = null;
                Thread.Sleep(500);
                dataGridView1.DataSource = zagruzka(zaprosclients);
                dataGridView1.Columns["Код"].Visible = false;
                dataGridView1.FirstDisplayedScrollingRowIndex = prokrutka;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                dataGridView1.DataSource = zagruzka(zaprosclients);
                dataGridView1.Columns["Код"].Visible = false;
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                double client_id = Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Номер читательского билета"].Value.ToString());
                string client_surname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Фамилия Читателя"].Value.ToString();
                string client_name = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Имя читателя"].Value.ToString();
                string otch = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Отчество читателя"].Value.ToString();
                double pasport = Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Паспорт читателя"].Value.ToString());
                double phone = Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Телефон читателя"].Value.ToString());
                string adress = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Адрес читателя"].Value.ToString();

                if (System.Windows.Forms.Application.OpenForms["AddClient"] == null)
                {
                    Form addcl = null;
                    addcl = new AddClient(1, client_id, client_surname, client_name, otch, pasport, phone, adress);
                    addcl.Show();
                }
                else { }
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Выберите запись!");
            }
            catch (System.FormatException)
            {

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
                string delTableName = "Читатели";
                string delStolbName = "Номер читательского билета";
                long delID = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[$"{delStolbName}"].Value.ToString());
                delete(delTableName, delStolbName, delID);
                updateclients();
                if (System.Windows.Forms.Application.OpenForms["AddRent"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["AddRent"] as AddRent).newclientadded();
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

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (RadioButton rBtn in panel2.Controls.OfType<RadioButton>())
            {
                rBtn.Checked = false;
                textBox1.Text = "";
                label1.Text = "Фамилия читателя";
            }
            (dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter = null;
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

        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "Login")
                {
                    f.Close();
                }
                else
                {
                    f.Show();
                }
            }
        }

        private void Clients_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Menu"] == null && System.Windows.Forms.Application.OpenForms["Login"].Visible == false && System.Windows.Forms.Application.OpenForms["Books"] == null)
            {
                Menu main = new Menu();
                main.toolStripMenuItem1.Text = this.toolStripMenuItem1.Text;
                main.Show();
            }
            else { }
        }
    }
}
