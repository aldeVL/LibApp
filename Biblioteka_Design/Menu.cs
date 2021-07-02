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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Books"] == null)
            { 
                Books book = new Books();
                book.toolStripMenuItem1.Text = this.toolStripMenuItem1.Text;
                book.Show();
                this.Close();
            }
            else { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Books"] == null)
            {
                Rent arenda = new Rent();
                arenda.toolStripMenuItem1.Text = this.toolStripMenuItem1.Text;
                arenda.Show();
                this.Close();
            }
            else { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Clients"] == null)
            {
                Clients chit = new Clients();
                chit.toolStripMenuItem1.Text = this.toolStripMenuItem1.Text;
                chit.Show();
                this.Close();
            }
            else { }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            if (System.Windows.Forms.Application.OpenForms["Login"].Visible == true)
            {
                Login log = new Login();
                log.textBox2.Text = "";
                log.Show();
                //this.Close();
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (toolStripMenuItem1.Text == "Вы вошли в систему как: Читатель")
            {
                button3.Visible = false;
                button2.Visible = false;
            }
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Menu"] == null && System.Windows.Forms.Application.OpenForms["Login"].Visible == false && System.Windows.Forms.Application.OpenForms["Books"] == null && System.Windows.Forms.Application.OpenForms["Rent"] == null && System.Windows.Forms.Application.OpenForms["Clients"] == null)
            {
                Login log = new Login();
                log.textBox2.Text = "";
                log.Show();
            }
            else { }
        }
    }
}
