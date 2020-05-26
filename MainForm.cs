/*
Denna fil har skapats som en del av kursen [C# I] på Malmö Universitet 2020
Namn: Carl-Adam Berglund
e-mail: ak7764@mau.se
*/  


using System;
using System.Windows.Forms;

namespace Assignment6
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();

        }

        private void InitializeGUI()
        {
            comboBox1.Items.AddRange(Enum.GetNames(typeof(PriorityType)));
            comboBox1.SelectedIndex = (int)PriorityType.DO_IT_RIGHT_NOW;
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

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd        hh:mm:ss";
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtBoxToDoStuff_TextChanged(object sender, EventArgs e)
        {

        }

        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {
            toolTip1.SetToolTip(dateTimePicker1, "Click to open calender for date, write in time here");
        }
    }
}
