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
    public partial class Rent : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb";
        public OleDbCommand comm;
        public OleDbConnection myConnection;
        public int prokrutka = 0;
        Form myform = null;

       /* public string rentzapros = "SELECT Аренда.Код, Читатели.[Фамилия Читателя]+' '+Left(Читатели.[Имя читателя],1)+'.'+Left(Читатели.[Отчество читателя],1) as Читатель, Аренда.[Код экземпляра], " +
            "Аренда.[Дата начала аренды], Аренда.[Дата окончания аренды], Сотрудники.[Фамилия сотрудника]+' '+Left(Сотрудники.[Имя сотрудника],1)+'.'+Left(Сотрудники.[Отчество Сотрудника],1) as Сотрудник, Аренда.[Аренда закрыта]" +
            "FROM Читатели INNER JOIN(Аренда INNER JOIN Сотрудники ON Аренда.[Код сотрудника] = Сотрудники.[Код сотрудника]) ON Читатели.[Номер читательского билета] = Аренда.[Номер читательского билета]"+
            "WHERE (([Аренда].[Аренда закрыта]='Нет') AND ((Читатели.[Номер читательского билета])=[Аренда].[Номер читательского билета]) AND ((Сотрудники.[Код сотрудника])=[Аренда].[Код сотрудника]))";
       */
        public string rentzapros = "SELECT Аренда.Код, Читатели.[Фамилия Читателя]+' '+Left(Читатели.[Имя читателя],1)+'.'+Left(Читатели.[Отчество читателя],1) as Читатель, " +
            "Книги.Название as [Название книги], Аренда.[Код экземпляра], Аренда.[Дата начала аренды], Аренда.[Дата окончания аренды], " +
            "Сотрудники.[Фамилия сотрудника]+' '+Left(Сотрудники.[Имя сотрудника],1)+'.'+Left(Сотрудники.[Отчество Сотрудника],1) as Сотрудник, " +
            "Аренда.[Аренда закрыта] FROM " +
            "Книги INNER JOIN((Экземпляр INNER JOIN (Читатели INNER JOIN Аренда ON Читатели.[Номер читательского билета] = Аренда.[Номер читательского билета]) ON " +
            "Экземпляр.[Код экземпляра] = Аренда.[Код экземпляра]) INNER JOIN Сотрудники ON Аренда.[Код сотрудника] = Сотрудники.[Код сотрудника]) ON(Аренда.[Код книги] = Книги.[Код книги]) " +
            "AND(Книги.[Код книги] = Экземпляр.[Код книги]) WHERE(([Аренда].[Номер читательского билета]=[Читатели].[Номер читательского билета]) AND([Аренда].[Код книги]=[Книги].[Код книги]) AND([Аренда].[Код сотрудника]=[Сотрудники].[Код сотрудника]) AND([Аренда].[Аренда закрыта]= 'нет')) Order By Аренда.[Дата окончания аренды] desc;";
        public Rent()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            dataGridView1.DataSource = zagruzka(rentzapros);
            dataGridView1.Columns["Код"].Visible = false;
            dataGridView1.Columns["Аренда закрыта"].Visible = false;


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

        public DataTable nass(string query)
        {
            OleDbConnection conn = new OleDbConnection(connectString);
            var adapter = new OleDbDataAdapter(query, conn);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            adapter.Dispose();
            return ds;
        }

        public void updatearent()
        {
            try
            {
                prokrutka = dataGridView1.FirstDisplayedScrollingRowIndex;
                dataGridView1.DataSource = null;
                Thread.Sleep(500);
                dataGridView1.DataSource = zagruzka(rentzapros);
                dataGridView1.Columns["Код"].Visible = false;
                dataGridView1.Columns["Аренда закрыта"].Visible = false;
                PaintRows();
                dataGridView1.FirstDisplayedScrollingRowIndex = prokrutka;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                dataGridView1.DataSource = zagruzka(rentzapros);
                dataGridView1.Columns["Код"].Visible = false;
                dataGridView1.Columns["Аренда закрыта"].Visible = false;
                PaintRows();
            }
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

        private void назажToolStripMenuItem_Click(object sender, EventArgs e)
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
                this.Close();
            }
            else { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Columns[dataGridView1.SelectedCells[0].ColumnIndex].ContextMenuStrip = contextMenuStrip1;
        }

        private void закрытьАрендуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы действительно хотите закрыть аренду?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                int exID = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код экземпляра"].Value.ToString());
                int rentID = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код"].Value.ToString()); 
                update("Экземпляр", "Статус", "В наличии", exID, "Код экземпляра");
                update("Аренда", "Аренда закрыта", "Да", rentID, "Код");
                backup(rentID);

                if (System.Windows.Forms.Application.OpenForms["Rent"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["Rent"] as Rent).updatearent();
                }

            }
            else { }
        }

        public void update(string TabName, string stolb, string cel, long ID, string exid)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comm = new OleDbCommand($"UPDATE [{TabName}] SET [{stolb}] = '{cel}' WHERE [{exid}] = {ID}", myConnection);
            comm.ExecuteNonQuery();
        }

        public void backup(int ID)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comm = new OleDbCommand($"INSERT INTO [Аренда_Прошлая] SELECT * FROM [Аренда] WHERE [Код] = {ID}", myConnection);
            comm.ExecuteNonQuery();
        }

        private void закрытьАрендуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            закрытьАрендуToolStripMenuItem1.PerformClick();
        }

        private void продлитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DateTime dat = DateTime.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Дата окончания аренды"].Value.ToString());
            dat.ToShortDateString();
            int rentid = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код"].Value.ToString());

            if (System.Windows.Forms.Application.OpenForms["ExportArenda"] == null)
            {
                Form extendrent = new ExtendRent(dat, rentid);
                extendrent.Show();
            }
            else { }
        }

        public void PaintRows()
        {
            DateTime dtnow2 = DateTime.Now;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DateTime dtcell = Convert.ToDateTime(row.Cells[5].Value);
                TimeSpan nnn = dtnow2 - dtcell;
                if (dtnow2 > dtcell)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 177, 166);
                }
                else if (Math.Round(Convert.ToDouble(nnn.TotalDays)) >= 1 && Math.Round(Convert.ToDouble(nnn.TotalDays)) < 2)
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void Rent_Load(object sender, EventArgs e)
        {
            loading();
            PaintRows();
        }
        public void loading()
        {
            loadCombosCodes();
            loadCombos();
            comboBox3.SelectedIndex = 0;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
        }
        public void loadCombos()
        {
            //comboBox1.SelectedIndex = 0;
            //comboBox2.SelectedIndex = 0;
            //--------------Заполнение читателей
            string zaprosReaders = "SELECT Читатели.[Номер читательского билета],Читатели.[Фамилия Читателя]+' '+Left(Читатели.[Имя читателя],1)+'.'+Left(Читатели.[Отчество читателя],1) as Читатель FROM Читатели";
            comboBox1.DataSource = nass(zaprosReaders);
            comboBox1.DisplayMember = "Читатель";
            comboBox1.ValueMember = "Номер читательского билета";
            DataRowView jab2 = (DataRowView)comboBox1.SelectedItem;
            String valueofitem = jab2["Номер читательского билета"].ToString();

            //--------------Заполнение жанров
            string zaprosBooks = "SELECT DISTINCT Книги.Название, Книги.[Код книги] FROM(Аренда_Прошлая INNER JOIN " +
                "Книги ON Аренда_Прошлая.[Код книги] = Книги.[Код книги]) INNER JOIN Читатели ON " +
                "Аренда_Прошлая.[Номер читательского билета] = Читатели.[Номер читательского билета] WHERE" +
                "(([Книги].[Код книги] =[Аренда_Прошлая].[Код книги]) AND([Книги].[Код книги] =[Аренда_Прошлая].[Код книги]))";
            comboBox2.DataSource = nass(zaprosBooks);
            comboBox2.DisplayMember = "Название";
            comboBox2.ValueMember = "Код книги";
            DataRowView jab3 = (DataRowView)comboBox2.SelectedItem;
            String valueofite3 = jab3["Название"].ToString();
        }

        public void loadCombosCodes()
        {
            //--------------Заполнение кодов авторов
            string zaprosReaders = "SELECT Читатели.[Номер читательского билета] FROM Читатели";
            comboBox4.DataSource = nass(zaprosReaders);
            comboBox4.DisplayMember = "Номер читательского билета";
            comboBox4.ValueMember = "Номер читательского билета";
            DataRowView jab7 = (DataRowView)comboBox4.SelectedItem;
            String valueofitem = jab7["Номер читательского билета"].ToString();

            //--------------Заполнение жанров
            string zaprosBooks = "SELECT DISTINCT Книги.Название, Книги.[Код книги] FROM(Аренда_Прошлая INNER JOIN " +
                "Книги ON Аренда_Прошлая.[Код книги] = Книги.[Код книги]) INNER JOIN Читатели ON " +
                "Аренда_Прошлая.[Номер читательского билета] = Читатели.[Номер читательского билета] WHERE" +
                "(([Книги].[Код книги] =[Аренда_Прошлая].[Код книги]) AND([Книги].[Код книги] = [Аренда_Прошлая].[Код книги]))";
            comboBox5.DataSource = nass(zaprosBooks);
            comboBox5.DisplayMember = "Код книги";
            comboBox5.ValueMember = "Код книги";
            DataRowView jab8 = (DataRowView)comboBox5.SelectedItem;
            try
            {
                String valueofite8 = jab8["Код книги"].ToString();
            }
            catch(System.NullReferenceException)
            {
                MessageBox.Show("нет записей");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && (radioButton1.Checked == false && radioButton2.Checked == false) && radioButton3.Checked == false)
            {

            }
            else
            {
                dataGridView1.DataSource = zagruzka(rentzapros);
                dataGridView1.Columns["Код"].Visible = false;
                dataGridView1.Columns["Аренда закрыта"].Visible = false;
                PaintRows();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                textBox1.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string zaprosbooks = "";
            string zaprosreaders = "";
            if (textBox1.Text != "")
            {
                (dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("Convert([{0}], System.String) LIKE '{1}%'", comboBox3.Text, textBox1.Text);
                PaintRows();
            }
            else
            {
                foreach (RadioButton rBtn in groupBox1.Controls.OfType<RadioButton>())
                {
                    if (rBtn.Checked)
                    {
                        if (rBtn.Text == "На руках")
                        {
                            (dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("Читатель LIKE '{0}%'", comboBox1.Text);
                            PaintRows();
                        }
                        else if (rBtn.Text == "Прошлые")
                        {
                            zaprosbooks = "SELECT Аренда_Прошлая.Код, Читатели.[Фамилия Читателя]+' '+Left(Читатели.[Имя читателя],1)+'.'+Left(Читатели.[Отчество читателя],1) as Читатель, " +
                "Книги.Название as [Название книги], Аренда_Прошлая.[Код экземпляра], Аренда_Прошлая.[Дата начала аренды], Аренда_Прошлая.[Дата окончания аренды], " +
                "Сотрудники.[Фамилия сотрудника]+' '+Left(Сотрудники.[Имя сотрудника],1)+'.'+Left(Сотрудники.[Отчество Сотрудника],1) as Сотрудник, " +
                "Аренда_Прошлая.[Аренда закрыта] FROM " +
                "Книги INNER JOIN((Экземпляр INNER JOIN (Читатели INNER JOIN Аренда_Прошлая ON Читатели.[Номер читательского билета] = Аренда_Прошлая.[Номер читательского билета]) ON " +
                "Экземпляр.[Код экземпляра] = Аренда_Прошлая.[Код экземпляра]) INNER JOIN Сотрудники ON Аренда_Прошлая.[Код сотрудника] = Сотрудники.[Код сотрудника]) ON(Аренда_Прошлая.[Код книги] = Книги.[Код книги]) " +
                $"AND(Книги.[Код книги] = Экземпляр.[Код книги]) WHERE(([Аренда_Прошлая].[Номер читательского билета]=[Читатели].[Номер читательского билета]) AND([Аренда_Прошлая].[Код книги]=[Книги].[Код книги]) AND([Аренда_Прошлая].[Код сотрудника]=[Сотрудники].[Код сотрудника])) AND([Аренда_Прошлая].[Номер читательского билета]= {comboBox4.Text})";
                            dataGridView1.DataSource = zagruzka(zaprosbooks);
                            dataGridView1.Columns["Код"].Visible = false;
                            dataGridView1.Columns["Аренда закрыта"].Visible = false;
                            PaintRows();
                        }
                    }

                }

                foreach (RadioButton rBtn in groupBox2.Controls.OfType<RadioButton>())
                {
                    if (rBtn.Checked)
                    {
                        zaprosreaders = "SELECT Аренда_Прошлая.Код, Читатели.[Фамилия Читателя]+' '+Left(Читатели.[Имя читателя],1)+'.'+Left(Читатели.[Отчество читателя],1) as Читатель, " +
                "Книги.Название as [Название книги], Аренда_Прошлая.[Код экземпляра], Аренда_Прошлая.[Дата начала аренды], Аренда_Прошлая.[Дата окончания аренды], " +
                "Сотрудники.[Фамилия сотрудника]+' '+Left(Сотрудники.[Имя сотрудника],1)+'.'+Left(Сотрудники.[Отчество Сотрудника],1) as Сотрудник, " +
                "Аренда_Прошлая.[Аренда закрыта] FROM " +
                "Книги INNER JOIN((Экземпляр INNER JOIN (Читатели INNER JOIN Аренда_Прошлая ON Читатели.[Номер читательского билета] = Аренда_Прошлая.[Номер читательского билета]) ON " +
                "Экземпляр.[Код экземпляра] = Аренда_Прошлая.[Код экземпляра]) INNER JOIN Сотрудники ON Аренда_Прошлая.[Код сотрудника] = Сотрудники.[Код сотрудника]) ON(Аренда_Прошлая.[Код книги] = Книги.[Код книги]) " +
                $"AND(Книги.[Код книги] = Экземпляр.[Код книги]) WHERE(([Аренда_Прошлая].[Номер читательского билета]=[Читатели].[Номер читательского билета]) AND([Аренда_Прошлая].[Код книги]=[Книги].[Код книги]) AND([Аренда_Прошлая].[Код сотрудника]=[Сотрудники].[Код сотрудника])) AND([Аренда_Прошлая].[Код книги]= {comboBox5.Text})";
                        dataGridView1.DataSource = zagruzka(zaprosreaders);
                        dataGridView1.Columns["Код"].Visible = false;
                        dataGridView1.Columns["Аренда закрыта"].Visible = false;
                        PaintRows();
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.SelectedIndex = comboBox1.SelectedIndex;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.SelectedIndex = comboBox2.SelectedIndex;
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            PaintRows();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void экспортWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["ExportArenda"] == null)
            {
                Form rentfired = null;
                rentfired = new ExportArenda();
                rentfired.Show();
            }
            else { }
        }

        public void Dolzhniki()
        {
            string zapross = "SELECT Аренда.[Номер читательского билета], Читатели.[Фамилия Читателя], Читатели.[Телефон читателя], Книги.Название as [Название книги], Аренда.[Код экземпляра], Аренда.[Дата начала аренды], Аренда.[Дата окончания аренды]"
+ "FROM((Читатели INNER JOIN Аренда ON Читатели.[Номер читательского билета] = Аренда.[Номер читательского билета]) INNER JOIN Книги ON Аренда.[Код книги] = Книги.[Код книги]) INNER JOIN Сотрудники ON Аренда.[Код сотрудника] = Сотрудники.[Код сотрудника]"
+"WHERE(([Читатели].[Номер читательского билета] =[Аренда].[Номер читательского билета]) AND([Читатели].[Номер читательского билета] =[Аренда].[Номер читательского билета]) AND([Книги].[Код книги] =[Аренда].[Код книги]))";

            DataTable dt = zagruzka(zapross);

            int RowCount = dt.Rows.Count;
            int ColumnCount = dt.Columns.Count;
            Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];
            //int RowCount = 0; int ColumnCount = 0;
            int r = 0;

            for (int c = 0; c <= ColumnCount - 1; c++)
            {
                DataArray[r, c] = dt.Columns[c].ColumnName;
                for (r = 0; r <= RowCount - 1; r++)
                {
                    DataArray[r, c] = dt.Rows[r][c];
                } //end row loop
            } //end column loop

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (*.docx)|*.docx";
            sfd.FileName = "exportBooks.docx";
            string path = string.Empty;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Word.Document oDoc = new Word.Document();

                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
                path = sfd.FileName;
                oDoc.SaveAs(path);
                oDoc.Application.Visible = true;
                this.SendToBack();
                dynamic oRange = oDoc.Content.Application.Selection.Range;
                String oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";
                    }
                }

                oRange.Text = oTemp;

                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                //object Separator = Word.WdTableFieldSeparator.wdSeparateByParagraphs;
                object Format = Word.WdTableFormat.wdTableFormatWeb1;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator,
            ref RowCount, ref ColumnCount, Type.Missing, ref Format,
            ref ApplyBorders, Type.Missing, Type.Missing, Type.Missing,
             Type.Missing, Type.Missing, Type.Missing,
             Type.Missing, ref AutoFit, ref AutoFitBehavior,
             Type.Missing);

                oRange.Select();

                //Стиль заголовка таблицы
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 2;
                oDoc.Application.Selection.Tables[1].Rows[1].HeightRule = Word.WdRowHeightRule.wdRowHeightAuto;
                //oDoc.Application.Selection.Tables[1].Rows[1].Height = 20;
                oDoc.Application.Selection.Tables[1].Range.Font.Name = "Times New Roman";
                oDoc.Application.Selection.Tables[1].Range.Font.Size = 12;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                //oDoc.Application.Selection.Tables[1].set_Style(Word.WdTableFormat.wdTableFormatGrid4);

                //gotta do the header row manually
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = dt.Columns[c].ColumnName;
                }

                oDoc.Application.Selection.Tables[1].set_Style("Таблица-сетка 4");
                oDoc.Application.Selection.Tables[1].AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);
                oDoc.Application.Selection.Tables[1].Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;
                //oDoc.Application.Selection.Tables[1].set_Style("Автоподбор по содержимому");

                //Текст шапки
                foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "Список должников";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                oDoc.Application.Visible = true;
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

        private void Rent_FormClosed(object sender, FormClosedEventArgs e)
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
