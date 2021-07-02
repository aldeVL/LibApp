using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka_Design
{
    public partial class Otchets : Form
    {
        public Otchets()
        {
            InitializeComponent();
            panel1.Visible = false;
        }

        private void Otchets_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Books"] != null)
            {
                string a = dateTimePicker1.Value.ToShortDateString();
                string b = dateTimePicker2.Value.ToShortDateString();
                string americanFormat = dateTimePicker1.Value.ToString("MM/dd/yyyy");
                string americanFormat2 = dateTimePicker2.Value.ToString("MM/dd/yyyy");
                string newAmerica1 = americanFormat.Replace(".", "/");
                string newAmerica2 = americanFormat2.Replace(".", "/");

                string ZaprosWithRange = "SELECT Книги.Название, Авторы.[Фамилия автора]+' '+Left(Авторы.[Имя автора],1)+'.'+Left(Авторы.[Отчество Автора],1) as Автор, " +
                   "Жанры.[Название жанра] as Жанр, Издателства.[Наименование издателсьтва] as Издательство, Книги.[Год издания], Книги.[ISBN], " +
                   "Книги.[Возрастное ограничение] as Ограничение, Книги.ББК, Экземпляр.[Код экземпляра], Экземпляр.[Дата поступления] FROM " +
                   "Авторы INNER JOIN(Издателства INNER JOIN (Жанры INNER JOIN " +
                   "(Книги INNER JOIN Экземпляр ON Книги.[Код книги] = Экземпляр.[Код книги]) ON Жанры.[Код жанра] = Книги.Жанр) ON" +
                   " Издателства.[Код издательства] = Книги.Издательство) ON Авторы.[Код автора] = Книги.Автор WHERE" +
                   "(((Книги.Автор) =[Авторы].[Код автора]) AND((Книги.Жанр) =[Жанры].[Код жанра]) AND" +
                   "((Книги.Издательство) =[Издателства].[Код издательства]) " +
                   $"AND((Экземпляр.[Код книги]) = [Книги].[Код книги] And [Экземпляр].[Дата поступления] Between #{americanFormat}# And #{americanFormat2}#)) ORDER BY [Экземпляр].[Дата поступления]";

                string ZaprosWithRange2 = "SELECT Книги.Название, Авторы.[Фамилия автора]+' '+Left(Авторы.[Имя автора],1)+'.'+Left(Авторы.[Отчество Автора],1) as Автор, " +
                   "Жанры.[Название жанра] as Жанр, Издателства.[Наименование издателсьтва] as Издательство, Книги.[Год издания], Книги.[ISBN]," +
                   "Книги.[Возрастное ограничение] as Ограничение, Книги.ББК, Экземпляр.[Код экземпляра], Экземпляр.[Дата поступления] FROM " +
                   "Авторы INNER JOIN(Издателства INNER JOIN (Жанры INNER JOIN " +
                   "(Книги INNER JOIN Экземпляр ON Книги.[Код книги] = Экземпляр.[Код книги]) ON Жанры.[Код жанра] = Книги.Жанр) ON" +
                   " Издателства.[Код издательства] = Книги.Издательство) ON Авторы.[Код автора] = Книги.Автор WHERE" +
                   "(((Книги.Автор) =[Авторы].[Код автора]) AND((Книги.Жанр) =[Жанры].[Код жанра]) AND" +
                   "((Книги.Издательство) =[Издателства].[Код издательства]) " +
                   $"AND((Экземпляр.[Код книги]) = [Книги].[Код книги] And [Экземпляр].[Дата поступления] Between #{newAmerica1}# And #{newAmerica2}#)) ORDER BY [Экземпляр].[Дата поступления]";

                string ZaprosSpis = "SELECT * FROM Списанные "
+$"WHERE(([Списанные].[Дата списания] Between #{americanFormat}# And #{americanFormat2}#)) GROUP BY [Списанные].[Дата списания]";

                string ZaprosSpis2 = "SELECT * FROM Списанные "
+ $"WHERE(([Списанные].[Дата списания] Between #{newAmerica1}# And #{newAmerica2}#)) GROUP BY [Списанные].[Дата списания]";
                if (radioButton1.Checked == true)
                {
                    (System.Windows.Forms.Application.OpenForms["Books"] as Books).BooksWithRangeReport(ZaprosWithRange, ZaprosWithRange2);
                }
                else if (radioButton2.Checked == true)
                {
                    (System.Windows.Forms.Application.OpenForms["Books"] as Books).BooksWithRangeReport(ZaprosSpis, ZaprosSpis2);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            button3.Visible = false;
            button2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Books"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Books"] as Books).ListOfBooks();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            button3.Visible = true;
            button2.Visible = true;
        }
    }
}
