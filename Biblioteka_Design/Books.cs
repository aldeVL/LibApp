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
    public partial class Books : Form
    {

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=dbNew03042021.mdb";
        public OleDbCommand comm;
        public OleDbConnection myConnection;
        public Bitmap ggggg = new Bitmap(System.Environment.CurrentDirectory + @"\images\blank.png");
        public int prokrutka = 0;
        Form myform = null;

        public string zaprosbooks = "SELECT Книги.[Код книги], Книги.[Обложка книги], Книги.Название, Авторы.[Фамилия автора]+' '+Left(Авторы.[Имя автора],1)+'.'+Left(Авторы.[Отчество Автора],1) as Автор, Жанры.[Название жанра] as Жанр, Издателства.[Наименование издателсьтва] as Издательство, Книги.[Год издания], Книги.[ISBN], Книги.[Возрастное ограничение], Книги.[ББК]" +
            "FROM Авторы INNER JOIN(Жанры INNER JOIN (Издателства INNER JOIN Книги ON Издателства.[Код издательства] = Книги.Издательство) ON Жанры.[Код жанра] = Книги.Жанр) ON Авторы.[Код автора] = Книги.Автор";
        

        public Books()
        {
            InitializeComponent();
            label9.Text = "Название";
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //toolStripMenuItem1.Text = "Вы зашли в систему как: Eblan";


            dataGridView1.DataSource = zagruzka(zaprosbooks);
            dataGridView1.Columns["Код книги"].Visible = false;
            dataGridView1.Columns["Обложка книги"].Visible = false;
            exampleload();


        }

        public void exampleload()
        {
            string zaprosexample = "SELECT Экземпляр.[Код экземпляра], Экземпляр.Статус, Экземпляр.[Дата поступления], Экземпляр.[Код книги]" +
            "FROM Книги INNER JOIN Экземпляр ON Книги.[Код книги] = Экземпляр.[Код книги] WHERE(((Экземпляр.Статус)= 'В наличии') AND((Экземпляр.[Код книги]) = " + dataGridView1.Rows[0].Cells["Код книги"].Value.ToString() + "))";
            dataGridView2.DataSource = zagruzka(zaprosexample);
            //dataGridView2.Columns["Код экземпляра"].Visible = false;
            dataGridView2.Columns["Код книги"].Visible = false;
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



        public void update(string stolb, string cel, long ID, string TabName)
        {
            comm = new OleDbCommand($"UPDATE [{TabName}] SET [{stolb}] = '{cel}' WHERE [Код книги] = {ID}", myConnection);
            comm.ExecuteNonQuery();
        }

        public void updatebooks(int token)
        {
            if (token == 1)
            {
                try
                {
                    prokrutka = dataGridView1.FirstDisplayedScrollingRowIndex;
                    dataGridView1.Columns.Remove("lay");
                    dataGridView1.DataSource = null;
                    Thread.Sleep(500);
                    dataGridView1.DataSource = zagruzka(zaprosbooks);
                    dataGridView1.Columns["Код книги"].Visible = false;
                    dataGridView1.Columns["Обложка книги"].Visible = false;
                    imgstolb();
                    dataGridView1.FirstDisplayedScrollingRowIndex = prokrutka;
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    dataGridView1.DataSource = zagruzka(zaprosbooks);
                    //imgstolb2();
                }
            }
            else if (token == 0)
            {
                try
                {
                    prokrutka = dataGridView1.FirstDisplayedScrollingRowIndex;
                    dataGridView1.DataSource = zagruzka(zaprosbooks);
                    dataGridView1.Columns["Код книги"].Visible = false;
                    dataGridView1.Columns["Обложка книги"].Visible = false;
                    dataGridView1.FirstDisplayedScrollingRowIndex = prokrutka;
                    imgstolb();
                    //dataGridView1.FirstDisplayedScrollingRowIndex = prokrutka;
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    dataGridView1.DataSource = zagruzka(zaprosbooks);
                    dataGridView1.Columns["Код книги"].Visible = false;
                    dataGridView1.Columns["Обложка книги"].Visible = false;
                    //imgstolb();
                }
            }
            else
            {
                try
                {
                    prokrutka = dataGridView1.FirstDisplayedScrollingRowIndex;
                    dataGridView1.Columns.Remove("lay");
                    dataGridView1.DataSource = null;
                    Thread.Sleep(500);
                    dataGridView1.DataSource = zagruzka(zaprosbooks);
                    dataGridView1.Columns["Код книги"].Visible = false;
                    dataGridView1.Columns["Обложка книги"].Visible = false;
                    imgstolb();
                    dataGridView1.FirstDisplayedScrollingRowIndex = prokrutka;
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    dataGridView1.DataSource = zagruzka(zaprosbooks);
                    dataGridView1.Columns["Код книги"].Visible = false;
                    dataGridView1.Columns["Обложка книги"].Visible = false;
                    //imgstolb();
                }
            }
            exampleload();
        }

        public void imgstolb()
        {
            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            iconColumn.Name = "lay";
            iconColumn.HeaderText = "Обложка";
            dataGridView1.Columns.Insert(1, iconColumn);
            iconColumn.MinimumWidth = 90;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                string putb = dataGridView1.Rows[i].Cells["Обложка книги"].Value.ToString();

                try
                {

                    if (putb == "empty")
                    {
                        Bitmap BlankImg = new Bitmap(ggggg, new Size(90, 110));
                        dataGridView1.Rows[i].Cells["lay"].Value = BlankImg;
                    }
                    else
                    {
                        Bitmap test = new Bitmap(fakeimg(putb), new Size(90, 110));
                        dataGridView1.Rows[i].Cells["lay"].Value = test;

                    }
                }
                catch (System.ArgumentException)
                {
                    Bitmap BlankImg = new Bitmap(ggggg, new Size(90, 110));
                    dataGridView1.Rows[i].Cells["lay"].Value = BlankImg;
                }

            }
        }

        public void imgstolb2()
        {

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                string putb = dataGridView1.Rows[i].Cells["Обложка книги"].Value.ToString();
                try
                {

                    if (putb == "empty")
                    {
                        Bitmap BlankImg = new Bitmap(ggggg, new Size(90, 110));
                        dataGridView1.Rows[i].Cells["lay"].Value = BlankImg;
                    }
                    else
                    {
                        Bitmap test = new Bitmap(fakeimg(putb), new Size(90, 110));
                        dataGridView1.Rows[i].Cells["lay"].Value = test;
                        // Bitmap img2 = new Bitmap(putb); // get iamge location and conver to bit map.
                        // Bitmap objBitmap = new Bitmap(img2, new Size(90, 110));
                        //Bitmap kdhfdk = (Bitmap)objBitmap.Clone();
                        // dataGridView1.Rows[i].Cells["Обложка книги"].Value = putb; //set you newly added colomun     

                    }
                }
                catch (System.ArgumentException)
                {
                    Bitmap BlankImg = new Bitmap(ggggg, new Size(90, 110));
                    dataGridView1.Rows[i].Cells["lay"].Value = BlankImg;
                }

            }
        }

        public Bitmap fakeimg(string putimg)
        {
            Bitmap image;
            using (Bitmap tmpimg = new Bitmap(putimg))
            {
                image = new Bitmap(tmpimg.Width, tmpimg.Height, PixelFormat.Format32bppArgb);
                using (Graphics gr = Graphics.FromImage(image))
                {
                    gr.DrawImage(tmpimg, new Rectangle(0, 0, image.Width, image.Height));
                    return image;
                }
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            int amountToIncrease = panel2.Width;
            if (panel2.Visible != false)
            {
                panel2.Visible = false;
                dataGridView1.Width += amountToIncrease;
                dataGridView2.Width += amountToIncrease;
                button1.Location = new Point(button1.Location.X + amountToIncrease, button1.Location.Y);
                button1.Text = "Показать";
            }
            else
            {
                panel2.Visible = true;
                dataGridView1.Width -= amountToIncrease;
                dataGridView2.Width -= amountToIncrease;
                button1.Location = new Point(button1.Location.X - amountToIncrease, button1.Location.Y);
                button1.Text = "Скрыть";
            }
        }

        private void Books_Load(object sender, EventArgs e)
        {
            imgstolb();
            if (toolStripMenuItem1.Text == "Вы вошли в систему как: Гость")
            {
                отчетыToolStripMenuItem.Visible = false;
                действияToolStripMenuItem.Visible = false;
                contextMenuStrip1.Enabled = false;
                contextMenuStrip2.Enabled = false;
                contextMenuStrip3.Enabled= false;
                contextMenuStrip4.Enabled = false;
                int amountToIncrease = panel1.Width;
                if (panel1.Visible != false)
                {
                    panel1.Visible = false;
                    dataGridView1.Width += amountToIncrease;
                    dataGridView2.Width += amountToIncrease;

                    this.dataGridView1.Location = new Point(this.dataGridView1.Location.X - amountToIncrease, this.dataGridView1.Location.Y);
                    this.dataGridView2.Location = new Point(this.dataGridView2.Location.X - amountToIncrease, this.dataGridView2.Location.Y);
                    this.label6.Location = new Point(this.label6.Location.X - amountToIncrease, this.label6.Location.Y);
                    this.label7.Location = new Point(this.label7.Location.X - amountToIncrease, this.label7.Location.Y);
                    this.linkLabel1.Location = new Point(this.linkLabel1.Location.X - amountToIncrease, this.linkLabel1.Location.Y);
                }
                else
                {
                    panel1.Visible = true;
                    dataGridView1.Width -= amountToIncrease;
                    dataGridView2.Width -= amountToIncrease;
                    this.dataGridView1.Location = new Point(this.dataGridView1.Location.X + amountToIncrease, this.dataGridView1.Location.Y);
                    this.dataGridView1.Location = new Point(this.dataGridView2.Location.X + amountToIncrease, this.dataGridView2.Location.Y);
                    this.label6.Location = new Point(this.label6.Location.X + amountToIncrease, this.label6.Location.Y);
                    this.label7.Location = new Point(this.label7.Location.X + amountToIncrease, this.label7.Location.Y);
                    this.linkLabel1.Location = new Point(this.linkLabel1.Location.X + amountToIncrease, this.linkLabel1.Location.Y);
                }
            }
            else { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*
               (dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("Convert([{0}], System.String) LIKE '{1}%'", label9.Text, textBox1.Text);
               imgstolb2();
            */
        }

        private void изменитьToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            OpenFileDialog fb = new OpenFileDialog();
            string fullpath;
            string pathTo = System.Environment.CurrentDirectory + @"\images";
            string imgput;

            fb.FilterIndex = 2;
            fb.Filter = "jpg|*.jpg| png|*.png";

            if (fb.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    string bookname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Название"].Value.ToString();


                        File.Delete(Path.Combine("images", bookname + ".png"));

                        File.Copy(fb.FileName, Path.Combine("images", bookname + ".png"), false);

                        string tablename = "Книги";
                        string stolbknig = "Обложка книги";
                        imgput = Path.Combine("images", bookname + ".png");
                        long delID = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код книги"].Value.ToString());

                        update(stolbknig, imgput, delID, tablename);

                        updatebooks(1);
             }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Ошибка доступа!");
                }
            }
        }


        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string zaprosexample = "SELECT Экземпляр.[Код экземпляра], Экземпляр.Статус, Экземпляр.[Дата поступления], Экземпляр.[Код книги]" +
            "FROM Книги INNER JOIN Экземпляр ON Книги.[Код книги] = Экземпляр.[Код книги] WHERE(((Экземпляр.Статус)= 'В наличии') AND((Экземпляр.[Код книги]) = "+dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код книги"].Value.ToString()+"))";
            dataGridView2.DataSource = zagruzka(zaprosexample);
            //dataGridView2.Columns["Код экземпляра"].Visible = false;
            dataGridView2.Columns["Код книги"].Visible = false;

        }

        public void updspis(int ind)
        {
            dataGridView2.Rows.RemoveAt(ind);
        }
        public void updbk(int ind)
        {
            dataGridView1.Rows.RemoveAt(ind);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string jjj = Convert.ToString(dataGridView1.Columns[dataGridView1.SelectedCells[0].ColumnIndex].CellType);
            if (jjj == "System.Windows.Forms.DataGridViewImageCell")
            {
                for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                {

                    string putempt = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Обложка книги"].Value.ToString();
                    string putempt2 = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Название"].Value.ToString();

                    if (File.Exists(Path.Combine(System.Environment.CurrentDirectory + @"\images", putempt2 + ".png")))
                    {
                        //MessageBox.Show("Ok");
                        dataGridView1.Columns[1].ContextMenuStrip = contextMenuStrip1;
                    }
                    else
                    {
                        dataGridView1.Columns[1].ContextMenuStrip = contextMenuStrip1;
                        //dataGridView1.ContextMenuStrip = contextMenuStrip1;
                    }

                }
            }
            else
            {
                dataGridView1.Columns[dataGridView1.SelectedCells[0].ColumnIndex].ContextMenuStrip = contextMenuStrip2;
            }
        }

        private void добавлениеКнигToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms["AddBooks"] == null)
            {
                Form ed = null;
                ed = new AddBooks();
                ed.Show();
            }
            else { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (RadioButton rBtn in panel2.Controls.OfType<RadioButton>())
            {
                if (rBtn.Checked)
                {
                    rBtn.Checked = false;
                    textBox1.Text = "";
                    label9.Text = "Название";
                    (dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter = null;
                    imgstolb2();
                    break;
                }

            }
            if ((dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter != null)
            {
                (dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter = null;
                textBox1.Text = "";
                label9.Text = "Название";
                imgstolb2();
            }
        }

        private void изменитьКнигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                {
                    int bookid = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код книги"].Value.ToString());
                    string bookname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Название"].Value.ToString();
                    string author = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Автор"].Value.ToString();
                    string genre = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Жанр"].Value.ToString();
                    string publisher = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Издательство"].Value.ToString();
                    int year = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Год издания"].Value.ToString());
                    string vozrast = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Возрастное ограничение"].Value.ToString();
                    string section = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ББК"].Value.ToString();
                    string isbn = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ISBN"].Value.ToString();

                    if (System.Windows.Forms.Application.OpenForms["BookEdit"] == null)
                    {
                        Form ed = null;
                        ed = new BookEdit(bookid, bookname, author, genre, publisher, year, vozrast, section, isbn);
                        ed.Show();
                    }
                    else { }
                }
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Выберите запись!");
            }
        }

        private void изменитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
            {
                int bookid = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код книги"].Value.ToString());
                string bookname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Название"].Value.ToString();
                string author = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Автор"].Value.ToString();
                string genre = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Жанр"].Value.ToString();
                string publisher = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Издательство"].Value.ToString();
                int year = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Год издания"].Value.ToString());
                string vozrast = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Возрастное ограничение"].Value.ToString();
                string section = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ББК"].Value.ToString();
                string isbn = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ISBN"].Value.ToString();

                if (System.Windows.Forms.Application.OpenForms["BookEdit"] == null)
                {
                    Form ed = null;
                    ed = new BookEdit(bookid, bookname, author, genre, publisher, year, vozrast, section, isbn);
                    ed.Show();
                }
                else { }
                /*
                Form editing = new BookEdit(bookid, bookname, author, genre, publisher, year, vozrast, section);
                editing.ShowDialog();
                */
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string delTableName = "Книги";
                string delStolbName = "Код книги";
                long delID = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[$"{delStolbName}"].Value.ToString());
                string bookname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Название"].Value.ToString();
                delete(delTableName, delStolbName, delID, bookname);
                int ind = dataGridView1.SelectedCells[0].RowIndex;
                updbk(ind);
                dataGridView2.DataSource = null;
            }
            else { }
        }
        public void delete(string TabName, string StolbName, long ID, string namebook)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            File.Delete(Path.Combine(System.Environment.CurrentDirectory + @"\images", namebook + ".png"));
            comm = new OleDbCommand($"DELETE From [{TabName}] Where [{StolbName}] = {ID}", myConnection);
            comm.ExecuteNonQuery();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Authors"] == null)
            {
                Form aut = null;
                aut = new Authors();
                aut.Show();
            }
            else { }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView2.Columns[1].ContextMenuStrip = contextMenuStrip3;


                //dataGridView2.Columns[1].ContextMenuStrip = contextMenuStrip3;
                dataGridView2.Columns[dataGridView2.SelectedCells[0].ColumnIndex].ContextMenuStrip = contextMenuStrip3;

        }

        private void списатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string delTableName = "Экземпляр";
            string delStolbName = "Код экземпляра";
            string blank = "";
            long delID = int.Parse(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[$"{delStolbName}"].Value.ToString());
            int bookID = int.Parse(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["Код книги"].Value.ToString());
            string stat = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["Статус"].Value.ToString();
            int ind = dataGridView2.SelectedCells[0].RowIndex;
            if (stat != "В наличии")
            {
                MessageBox.Show("Сначала закройте аренду!");
            }
            else
            {
                if (System.Windows.Forms.Application.OpenForms["Spisanie"] == null)
                {
                    Form formspis = null;
                    formspis = new Spisanie(delTableName, delStolbName, delID, bookID, blank, ind);
                    formspis.Show();
                }
                else { }
            }
            //delete(delTableName, delStolbName, delID, blank);
        }

        private void label4_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms["Rent"] == null)
            {
                Rent formrent2 = new Rent();
                formrent2.toolStripMenuItem1.Text = this.toolStripMenuItem1.Text;
                formrent2.Show();
            }
            else { }
        }

        private void арендаКнигToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["AddRent"] == null)
            {
                Form formrent2 = null;
                formrent2 = new AddRent(0, 0);
                formrent2.Show();
            }
            else { }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string zaprosexample = "SELECT Экземпляр.[Код экземпляра], Экземпляр.Статус, Экземпляр.[Дата поступления], Экземпляр.[Код книги]" +
            "FROM Книги INNER JOIN Экземпляр ON Книги.[Код книги] = Экземпляр.[Код книги] WHERE((Экземпляр.[Код книги]) = " + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код книги"].Value.ToString() + ")";
            dataGridView2.DataSource = zagruzka(zaprosexample);
            //dataGridView2.Columns["Код экземпляра"].Visible = false;
            dataGridView2.Columns["Код книги"].Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            string zaprosexample = "SELECT Экземпляр.[Код экземпляра], Экземпляр.Статус, Экземпляр.[Дата поступления], Экземпляр.[Код книги]" +
            "FROM Книги INNER JOIN Экземпляр ON Книги.[Код книги] = Экземпляр.[Код книги] WHERE(((Экземпляр.Статус)= 'В наличии') AND((Экземпляр.[Код книги]) = " + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Код книги"].Value.ToString() + "))";
            dataGridView2.DataSource = zagruzka(zaprosexample);
            //dataGridView2.Columns["Код экземпляра"].Visible = false;
            dataGridView2.Columns["Код книги"].Visible = false;
        }

        private void арендоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int exid = Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["Код экземпляра"].Value.ToString());
            string stat = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["Статус"].Value.ToString();
            int bID = Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["Код книги"].Value.ToString());

            if (stat == "Арендована")
            {
                MessageBox.Show("Книги нет в наличии!");
            }
            else
            {
                if (System.Windows.Forms.Application.OpenForms["AddRent"] == null)
                {
                    Form formrent2 = null;
                    formrent2 = new AddRent(exid, bID);
                    formrent2.Show();
                }
                else { }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms["Publishers"] == null)
            {
                Form publ = null;
                publ = new Publishers();
                publ.Show();
            }
            else { }
        }

        private void label2_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms["Genres"] == null)
            {
                Form gen = null;
                gen = new Genres();
                gen.Show();
            }
            else { }
        }

        private void radioButton1_Click_1(object sender, EventArgs e)
        {
            
            foreach (RadioButton rBtn in panel2.Controls.OfType<RadioButton>())
            {
                if (rBtn.Checked)
                {
                    string ghg = rBtn.Text;
                    ghg = ghg.Replace("\r", string.Empty);
                    ghg = ghg.Replace("\n", string.Empty);
                    label9.Text = ghg;
                    //(dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("Convert([{0}], System.String) LIKE '{1}%'", label9.Text, textBox1.Text);
                    //imgstolb2();
                    break;
                }
            
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                (dataGridView1.DataSource as System.Data.DataTable).DefaultView.RowFilter = string.Format("Convert([{0}], System.String) LIKE '{1}%'", label9.Text, textBox1.Text);
                imgstolb2();
            }
            else { }
        }

        private void добавитьЭкземплярыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string bookname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Название"].Value.ToString();

            if (System.Windows.Forms.Application.OpenForms["AddExample"] == null)
            {
                Form addexam = null;
                addexam = new AddExample(bookname);
                addexam.Show();
            }
            else { }

        }

        private void label10_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms["Clients"] == null)
            {
               Clients client = new Clients();
                client.toolStripMenuItem1.Text = this.toolStripMenuItem1.Text;
                client.Show();
            }
            else { }
        }

        public void BooksWithRangeReport(string zapros1, string zapros2)
        {
            try
            {
                DataTable dt = zagruzka(zapros1);

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
                    oDoc.Application.Selection.Tables[1].Rows[1].HeightRule = Word.WdRowHeightRule.wdRowHeightExactly;
                    oDoc.Application.Selection.Tables[1].Rows[1].Height = 20;
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
                        headerRange.Text = "Список книг";
                        headerRange.Font.Size = 16;
                        headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }

                    oDoc.Application.Visible = true;
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {

            }
            catch (System.Data.OleDb.OleDbException)
            {
                string x = zapros1;
                string y = zapros2;
                BooksWithRangeReport(y,x);
            }
        }
        public void ListOfBooks()
        {
            string zaprosbooks = "SELECT Книги.Название, Авторы.[Фамилия автора]+' '+Left(Авторы.[Имя автора],1)+'.'+Left(Авторы.[Отчество Автора],1) as Автор, Жанры.[Название жанра] as Жанр, Издателства.[Наименование издателсьтва] as Издательство, Книги.[Год издания], Книги.[ISBN], Книги.[Возрастное ограничение], Книги.[ББК]" +
            "FROM Авторы INNER JOIN(Жанры INNER JOIN (Издателства INNER JOIN Книги ON Издателства.[Код издательства] = Книги.Издательство) ON Жанры.[Код жанра] = Книги.Жанр) ON Авторы.[Код автора] = Книги.Автор";
            DataTable dt = zagruzka(zaprosbooks);

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
                oDoc.Application.Selection.Tables[1].Rows[1].HeightRule = Word.WdRowHeightRule.wdRowHeightExactly;
                oDoc.Application.Selection.Tables[1].Rows[1].Height = 20;
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
                    headerRange.Text = "Список книг";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                oDoc.Application.Visible = true;
            }

        }

        private void экспортWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Otchets"] == null)
            {
                Form addexam = null;
                addexam = new Otchets();
                addexam.Show();
            }
            else { }
        }

        private void сменитьПользователяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Form log = null;

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

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Menu"] == null)
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
                        Menu main = new Menu();
                        main.toolStripMenuItem1.Text = this.toolStripMenuItem1.Text;
                        main.Show();
                    }
                }
            }
            else { }
        }

        private void Books_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Menu"] == null && System.Windows.Forms.Application.OpenForms["Login"].Visible == false)
            {
                Menu main = new Menu();
                main.toolStripMenuItem1.Text = this.toolStripMenuItem1.Text;
                main.Show();
            }
            else { }
        }
    }
}
