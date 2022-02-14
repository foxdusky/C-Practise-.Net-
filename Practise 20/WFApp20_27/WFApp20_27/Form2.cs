using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFApp20_27
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.BackColor = colorDialog1.Color;
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = fontDialog1.Font;
        }

        private void сохранитьВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //создаем новый файл для записи
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create,
                FileAccess.Write);
                //создаем поток записи
                StreamWriter sw = new StreamWriter(fs);
                //записываем данные
                sw.WriteLine(richTextBox1.Text);
                //закрываем стримы
                sw.Close();
                fs.Close();
            }
        }

        private void загрузитьИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //создаем новый файл для чтения
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open,
                FileAccess.Read);
                //создаем поток чтения
                StreamReader sr = new StreamReader(fs);
                richTextBox1.Text = sr.ReadToEnd();
                //закрываем стримы
                sr.Close();
                fs.Close();
            }
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument1.PrintPage += PrintPageHandler;
            printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printPreviewDialog1.Document.Print();
        }
        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, Font, Brushes.Black, 20, 20);
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
