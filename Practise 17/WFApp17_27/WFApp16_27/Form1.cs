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
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}