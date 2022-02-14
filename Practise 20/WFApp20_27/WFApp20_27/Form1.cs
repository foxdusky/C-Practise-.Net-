using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFApp20_27
{
    public partial class Form1 : Form
    {
        string text;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AboutBox1 abtbx = new AboutBox1();
            Form2 form2 = new Form2();
            form2.richTextBox1.Text = abtbx.textBoxDescription.Text;
            form2.ShowDialog();
            if (form2.DialogResult == DialogResult.OK)
            {
                text = form2.richTextBox1.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AboutBox1 abtbx = new AboutBox1();
            if (text != null && text != "")
                abtbx.textBoxDescription.Text = text;
            abtbx.ShowDialog();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void вызовСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void дополнительноToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void базаДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Выйти из программы ?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
