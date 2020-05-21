using System;
using System.Windows.Forms;

namespace Assignment6
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblLiveClock.Text = DateTime.Now.ToString("HH:mm:ss");
            LabelDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            
        }

        private void MainForm_Load(Object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void LabelLiveClock_Click(object sender, EventArgs e)
        {

        }
    }
}
