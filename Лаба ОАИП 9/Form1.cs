namespace Лаба_ОАИП_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Init.pen = new Pen(Color.Black, 5);
            Init.pictureBox = pictureBox1;
            _ = new ShapeContainer();
        }
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string inputString = textBox1.Text.Trim();

                    bool result = ReversePolishNotation.CalculateRPN(inputString);

                    if (result)
                    {
                        listBox1.Items.Add(inputString);

                    }
                    else
                    {
                        listBox1.Items.Add("Invalid command: " + inputString);
                    }
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add("Error: " + ex.Message);
                }
                finally
                {
                    textBox1.Text = "";
                }

            }
        }
        
    }
}
