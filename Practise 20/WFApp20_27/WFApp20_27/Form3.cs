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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Wallpaper' table. You can move, or remove it, as needed.
            this.wallpaperTableAdapter.Fill(this.database1DataSet.Wallpaper);
            // TODO: This line of code loads data into the 'database1DataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.database1DataSet.Supplier);
            // TODO: This line of code loads data into the 'database1DataSet.Wallpaper' table. You can move, or remove it, as needed.
            this.wallpaperTableAdapter.Fill(this.database1DataSet.Wallpaper);
            // TODO: This line of code loads data into the 'database1DataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.database1DataSet.Supplier);

            BindingSource bs = new BindingSource();
            bs.DataSource = database1DataSet.Supplier;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;

            BindingSource bs1 = new BindingSource();
            bs1.DataSource = database1DataSet.Wallpaper;
            bindingNavigator2.BindingSource = bs1;
            dataGridView2.DataSource = bs1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            supplierBindingSource.EndEdit();
            supplierTableAdapter.Update(database1DataSet);
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            wallpaperBindingSource.EndEdit();
            wallpaperTableAdapter.Update(database1DataSet);
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(this.dataGridView2.Width, this.dataGridView2.Height);
            dataGridView2.DrawToBitmap(bmp, new Rectangle(0,0, this.dataGridView2.Width, this.dataGridView2.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
