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
        private readonly TaskManager taskManager = new TaskManager();
       
        // konstigt fel
        private Task task = new Task();                  // Kompilatorn säger att jag kan ta bort denna rad
                                                         // men när jag gör det kommer det där skumma Error igen
                                                         // Kan du förklara varför detta sker?

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
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "hh:mm:ss";
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

        private void NewCtrlNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeGUI();
        }

        private void OmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.Show();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < new DateTime(2000, 01, 01) || dateTimePicker1.Value >= new DateTime(2222, 01, 01))
            {
                MessageBox.Show("Wrong date, must be between 2000 - 2222");
                return;

            }


            Task newTask = GetTaskFromUserInputs(out bool success);
            if (newTask != null)
            {
                if (success)
                {
                    taskManager.Add(newTask);
                    UpdateGUI();
                }
            }

        }

        private void UpdateGUI()
        {
            lstBoxWstuff.Items.Clear();
            lstBoxWstuff.Items.AddRange(taskManager.ListToStringArray());
            task = new Task();

        }

        private Task GetTaskFromUserInputs(out bool success)
        {

            Task task2Add = new Task
            {
                
                Date = ReadDateTimeFromPicker(out success)
            };
            if (!success)
            {
                return null;
            }
            task2Add.Priority = ReadpriorityType(out success);
            if (!success)
            {
                return null;
            }
            task2Add.Description = ReadDescription(out success);
            return task2Add;
        }


        private PriorityType ReadpriorityType(out bool success)
        {
            success = false;
            PriorityType Ptype = PriorityType.Normal;
            if (comboBox1.SelectedIndex >= 0)
            {
                success = true;
                Ptype = (PriorityType)comboBox1.SelectedIndex;
            }
            else
                MessageBox.Show("Wrong Priority type");
            return Ptype;
        }

        private string ReadDescription(out bool success)
        {
            string text = txtBoxToDoStuff.Text.ToString();
            success = false;
            if (!string.IsNullOrEmpty(text))
            {
                success = true;
            }
            else
                MessageBox.Show("Enter a description");
            return text;
        }

        private DateTime ReadDateTimeFromPicker(out bool success)
        {
            success = false;
            DateTime dtt = Convert.ToDateTime(dateTimePicker1.Value); 
            DateTime dtt2 = Convert.ToDateTime(dateTimePicker2.Value); 
            DateTime datum = new DateTime(dtt.Year, dtt.Month, dtt.Day, dtt2.Hour, dtt2.Minute, dtt2.Second);
            if (!datum.Equals(null))
            {
                success = true;
            }
            else
                MessageBox.Show("Please enter a valid date / time");
            return datum;
        }

      
    } // Class 
} // NAMESPACE
