using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;

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
            // TODO: This line of code loads data into the 'database1DataSet.Web_Density' table. You can move, or remove it, as needed.
            this.web_DensityTableAdapter.Fill(this.database1DataSet.Web_Density);
            // TODO: This line of code loads data into the 'database1DataSet.Color' table. You can move, or remove it, as needed.
            this.colorTableAdapter.Fill(this.database1DataSet.Color);
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

        private void btnWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Файлы Word (*.doc; *.docx)|*.doc?";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                // Экспорт в Word
                
             
                var fn = System.IO.Directory.GetCurrentDirectory() + "\\Pattern_doc.docx";

                int r = dataGridView2.CurrentCell.RowIndex;
                var Wallpaper_Article = dataGridView2.Rows[r].Cells[1].FormattedValue.ToString();
                var Supplier_Company = dataGridView2.Rows[r].Cells[2].FormattedValue.ToString();
                var Roll_Size = dataGridView2.Rows[r].Cells[3].FormattedValue.ToString();
                var Production_Date = dataGridView2.Rows[r].Cells[4].FormattedValue.ToString();
                string Picture;
                if (dataGridView2.Rows[r].Cells[5].FormattedValue.ToString() == "True") {
                    Picture = "Имеется";
                        }
                else
                    Picture = "Отсутствует";
                var Main_Color = dataGridView2.Rows[r].Cells[6].FormattedValue.ToString();
                var Web_Density = dataGridView2.Rows[r].Cells[7].FormattedValue.ToString();
                Word.Application wordApp = new Word.Application();
                wordApp.Visible = false;
                Word.Document wordDocument;
                try
                {
                    wordDocument = wordApp.Documents.Open(fn);
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Не удалось найти файл шаблона",
                        "Ошибка!",
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error
                        );
                    return ;
                }
                ReplaceWordStub("*/Wallpaper_Article*/", Wallpaper_Article, wordDocument);
                ReplaceWordStub("*/Supplier_Company*/", Supplier_Company, wordDocument);
                ReplaceWordStub("*/Roll_Size*/", Roll_Size, wordDocument);
                ReplaceWordStub("*/Production_Date*/", Production_Date, wordDocument);
                ReplaceWordStub("*/Picture*/", Picture, wordDocument);
                ReplaceWordStub("*/Main_Color*/", Main_Color, wordDocument);
                ReplaceWordStub("*/Web_Density*/", Web_Density, wordDocument);
                try
                {
                    wordDocument.SaveAs2(sd.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Не удалось сохранить документ, файл открыт другим приложением.",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                finally
                { 
                    wordApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                }
            }

        }
        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Файлы Word (*.xls; *.xlsx)|*.xls?";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.ActiveSheet;
                excelApp.Visible = false;
                for (int i = 1; i < dataGridView2.ColumnCount + 1; i++)
                    worksheet.Rows[1].Columns[i] = dataGridView2.Columns[i-1].HeaderText;
                for (int i = 2; i < dataGridView2.RowCount + 1; i++)
                    for (int j = 1; j < dataGridView2.ColumnCount + 1; j++)
                        worksheet.Rows[i].Columns[j] = dataGridView2.Rows[i - 2].Cells[j - 1].FormattedValue;
                worksheet.Columns.AutoFit();
                excelApp.AlertBeforeOverwriting = false;
                excelApp.DisplayAlerts = false;
                try
                {
                    workbook.SaveAs(sd.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Не удалось сохранить документ, файл открыт другим приложением.",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                finally
                {
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }   
            }
        }
    }
}
