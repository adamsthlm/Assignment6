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
            comboBox1.Items.Clear(); // clear combo box
            txtBoxToDoStuff.Text = string.Empty; // clear txtbox
            lstBoxWstuff.Items.Clear(); // clear listbox 
            this.Text = "To Do Reminder" + " - Carl-Adam Berglund, Malmö University 2020";

           // Initializing the combobox and introducing string priority 
            string[] priority = Enum.GetNames(typeof(PriorityType));
            foreach (var item in priority)
            {
                comboBox1.Items.Add(item.Replace("_", " "));

            }
            comboBox1.SelectedIndex = (int)PriorityType.Normal;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            
            // disable open and save menu items
            openDatafileToolStripMenuItem.Enabled = false;
            saveDatafileToolStripMenuItem.Enabled = false;


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

        private void Menu_Exit_Click()
        {
            Close();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            var res = MessageBox.Show(this, "You really want to quit?", "Exit",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (res != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
        }
        

        // menuItem Exit Alt-F4, check if user really want to quit else go back an InitGUI (created by 2-click) 
        private void ExitAltF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(this, "You really want to quit?", "Exit",
           MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (res != DialogResult.Yes)
            {
                // e.Cancel = true;
                InitializeGUI();
            }
            else
            {
                Menu_Exit_Click();
            }
        }

        private void openDatafileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveDatafileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    } // Class 
} // NAMESPACE
