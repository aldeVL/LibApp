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
    public partial class AddRent : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb";
        public OleDbCommand comm;
        public OleDbConnection myConnection;
        public OpenFileDialog fb = new OpenFileDialog();

        public AddRent(int exID, int bookID)
        {
            InitializeComponent();
            label6.Text = bookID.ToString();
            label7.Text = exID.ToString();
        }

        public void loadcombos()
        {
            string zaprosReaders = "SELECT Читатели.[Номер читательского билета],Читатели.[Фамилия Читателя]+' '+Left(Читатели.[Имя читателя],1)+'.'+Left(Читатели.[Отчество читателя],1) as Читатель FROM Читатели";
            comboBox1.DataSource = nass(zaprosReaders);
            comboBox1.DisplayMember = "Читатель";
            comboBox1.ValueMember = "Номер читательского билета";
            DataRowView jab2 = (DataRowView)comboBox1.SelectedItem;
            String valueofitem = jab2["Номер читательского билета"].ToString();


            string zaprosSotr = "SELECT Сотрудники.[Код сотрудника], Сотрудники.[Фамилия сотрудника]+' '+Left(Сотрудники.[Имя сотрудника],1)+'.'+Left(Сотрудники.[Отчество Сотрудника],1) as Сотрудник FROM Сотрудники";
            comboBox6.DataSource = nass(zaprosSotr);
            comboBox6.DisplayMember = "Сотрудник";
            comboBox6.ValueMember = "Код сотрудника";
            DataRowView jab = (DataRowView)comboBox6.SelectedItem;
            String valueofitem1 = jab["Код сотрудника"].ToString();



            string zaprosBooks = "SELECT DISTINCT Книги.[Код книги], Книги.[Название] FROM Книги INNER JOIN Экземпляр ON Книги.[Код книги] = Экземпляр.[Код книги]" +
                "WHERE(([Книги].[Код книги] =[Экземпляр].[Код книги]) AND (Экземпляр.Статус = 'В наличии'))";
            comboBox7.DataSource = nass(zaprosBooks);
            comboBox7.DisplayMember = "Название";
            comboBox7.ValueMember = "Код книги";
            DataRowView jab3 = (DataRowView)comboBox7.SelectedItem;
            String valueofitem12= jab3["Код книги"].ToString();


        }

        public void loadforex()
        {
            try
            {
                string zaprosEx = $"SELECT Экземпляр.[Код экземпляра] FROM Экземпляр WHERE(([Экземпляр].[Код книги] = {comboBox5.Text}) AND (Экземпляр.Статус = 'В наличии'))";
                comboBox4.DataSource = nass(zaprosEx);
                comboBox4.DisplayMember = "Код экземпляра";
                comboBox4.ValueMember = "Код экземпляра";
                DataRowView jab3 = (DataRowView)comboBox4.SelectedItem;
                String valueofitem1 = jab3["Код экземпляра"].ToString();

                comboBox4.Text = label7.Text;
            }
            catch(System.NullReferenceException)
            {
                MessageBox.Show("Отсутствуют доступные экземпляры!");
            }
        }

        public void loadcomboscodes()
        {
            string zaprosReaders = "SELECT Читатели.[Номер читательского билета] FROM Читатели";
            comboBox2.DataSource = nass(zaprosReaders);
            comboBox2.DisplayMember = "Номер читательского билета";
            comboBox2.ValueMember = "Номер читательского билета";
            DataRowView jab7 = (DataRowView)comboBox2.SelectedItem;
            String valueofitem = jab7["Номер читательского билета"].ToString();


            string zaprosSotr = "SELECT Сотрудники.[Код сотрудника] FROM Сотрудники";
            comboBox3.DataSource = nass(zaprosSotr);
            comboBox3.DisplayMember = "Код сотрудника";
            comboBox3.ValueMember = "Код сотрудника";
            DataRowView jab2 = (DataRowView)comboBox3.SelectedItem;
            String valueofitem2 = jab2["Код сотрудника"].ToString();



            string zaprosBooks = "SELECT DISTINCT Книги.[Код книги] FROM Книги INNER JOIN Экземпляр ON Книги.[Код книги] = Экземпляр.[Код книги]"+
                "WHERE(((Книги.[Код книги]) = [Экземпляр].[Код книги]) AND (Экземпляр.Статус = 'В наличии'))";
            comboBox5.DataSource = nass(zaprosBooks);
            comboBox5.DisplayMember = "Код книги";
            comboBox5.ValueMember = "Код книги";
            DataRowView jab4 = (DataRowView)comboBox5.SelectedItem;
            String valueofitem4 = jab4["Код книги"].ToString();

            comboBox5.Text = label6.Text;
        }


        public void newclientadded()
        {
            
            string zaprosReaders = "SELECT Читатели.[Номер читательского билета],Читатели.[Фамилия Читателя]+' '+Left(Читатели.[Имя читателя],1)+'.'+Left(Читатели.[Отчество читателя],1) as Читатель FROM Читатели";
            comboBox1.DataSource = nass(zaprosReaders);
            comboBox1.DisplayMember = "Читатель";
            comboBox1.ValueMember = "Номер читательского билета";
            DataRowView jab2 = (DataRowView)comboBox1.SelectedItem;
            String valueofitem = jab2["Номер читательского билета"].ToString();

            string zaprosR = "SELECT Читатели.[Номер читательского билета] FROM Читатели";
            comboBox2.DataSource = nass(zaprosR);
            comboBox2.DisplayMember = "Номер читательского билета";
            comboBox2.ValueMember = "Номер читательского билета";
            DataRowView jab7 = (DataRowView)comboBox2.SelectedItem;
            String valueofitem2 = jab7["Номер читательского билета"].ToString();
        }



        public DataTable nass(string query)
        {
            OleDbConnection conn = new OleDbConnection(connectString);
            var adapter = new OleDbDataAdapter(query, conn);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            adapter.Dispose();
            return ds;
        }

        private void AddRent_Load(object sender, EventArgs e)
        {
            loadcombos();
            loadcomboscodes();
            loadforex();
            comboBox5.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox2.SelectedIndex = comboBox1.SelectedIndex;
                comboBox3.SelectedIndex = comboBox6.SelectedIndex;
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox5.SelectedIndex = comboBox7.SelectedIndex;
                loadforex();
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Books f1 = new Books();

            string zaprosInsertBooks = "INSERT INTO Аренда ([Номер читательского билета],[Код книги], [Код экземпляра], " +
                "[Дата начала аренды], [Дата окончания аренды], [Код сотрудника], [Аренда закрыта])" +
                "VALUES (@idchit,@idBOOK, @idEX, @date_start, @date_end, @id_sotr, @rent_ending)";
            f1.comm = new OleDbCommand(zaprosInsertBooks, f1.myConnection);
            f1.comm.Parameters.AddWithValue("idchit", Convert.ToDouble(comboBox2.Text));
            f1.comm.Parameters.AddWithValue("idBOOK", Convert.ToInt32(comboBox5.Text));
            f1.comm.Parameters.AddWithValue("idEX", Convert.ToInt32(comboBox4.Text));
            f1.comm.Parameters.AddWithValue("date_start", DateTime.Now.ToShortDateString());
            f1.comm.Parameters.AddWithValue("date_end", dateTimePicker1.Value.ToShortDateString());
            f1.comm.Parameters.AddWithValue("id_sotr", Convert.ToInt32(comboBox3.Text));
            f1.comm.Parameters.AddWithValue("rent_ending", "Нет");
            f1.comm.ExecuteNonQuery();

            update("Экземпляр", "Статус", "Арендована", Convert.ToInt32(comboBox4.Text));

            if (System.Windows.Forms.Application.OpenForms["Rent"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Rent"] as Rent).updatearent();
            }

            this.Close();

            if (System.Windows.Forms.Application.OpenForms["Rent"] == null)
            {
                Rent formspis = new Rent();
                formspis.toolStripMenuItem1.Text = "Вы вошли в систему как: Администратор";
                formspis.Show();
                (System.Windows.Forms.Application.OpenForms["Rent"] as Rent).updatearent();
            }
            else { }
        }

        public void update(string TabName, string stolb, string cel, long ID)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comm = new OleDbCommand($"UPDATE [{TabName}] SET [{stolb}] = '{cel}' WHERE [Код экземпляра] = {ID}", myConnection);
            comm.ExecuteNonQuery();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox7.SelectedIndex = comboBox5.SelectedIndex;
                loadforex();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Clients"] == null)
            {
                Clients client = new Clients();
                client.toolStripMenuItem1.Text = "Вы вошли в систему как: Администратор";
                client.Show();
            }
            else { }
        }
    }
}
