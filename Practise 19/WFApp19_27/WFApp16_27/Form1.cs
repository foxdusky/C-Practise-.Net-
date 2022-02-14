namespace WFApp16_27
{
    public partial class Form1 : Form
    {
        string text;
        Form2 form2 = new Form2();
        public Form1()
        {
            InitializeComponent();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Âûéòè èç ïğîãğàììû ?", "Çàïğîñ",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
                Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void äîïîëíèòåëüíîToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void âûõîäToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void âûçîâÑïğàâêèToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void îÏğîãğàììåToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}