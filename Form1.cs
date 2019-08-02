using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace NFC
{
    public partial class Form1 : Form
    {
        public SerialPort serialPort;

        private string DispString;

        public string[] ports = SerialPort.GetPortNames();

        private string p;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetStatus("Initializing");
            ReadDataBox.Font = new Font("Lucida Sans Unicode", this.Font.Size);
            if (ports.Length == 1)
            {
                ComTextBox.Text = ports[0];
            } else if (ports.Length == 0)
            {
                MakeMessage("Ther are no com ports please plug in the NFC scanner, now closing...", "Com Error");
                Application.Exit();
            }
            else
            {
                IdentifyPorts();
            }

            ReadDataBox.Text = "NFC Reader/Writer ready for use!";
        }

        private void IdentifyPorts()
        {
            p = "";

            foreach (string port in ports)
            {
                string op;
                op = p;
                if (op == "")
                {
                    p = port;
                }
                else
                {
                    p = op + " | " + port;
                }
            }
            MakeMessage(p, "Ports");
        }

        public bool PortCheck()
        {
            bool IsOption = false;

            foreach (string port in ports)
            {
                string po = port.ToLower();
                string ppo = ComTextBox.Text.ToLower();
                if (po == ppo)
                {
                    IsOption = true;
                }
            }

            return IsOption;
        }

        private void StartComs(string com)
        {
            if (PortCheck() != true)
            {
                MakeMessage("Please choose another port", "Com Error");
                return;
            }

            serialPort = new SerialPort(com.Normalize(), 9600, Parity.None, 8, StopBits.One);
            serialPort.ReadTimeout = 5000;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            if (serialPort.IsOpen == false)
            {
                serialPort.Open();
            }

            if (serialPort.IsOpen == true)
            {
                SetStatus("Idle");
            }
            else
            {
                SetStatus("Com Error!");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            WriteToNFC(WriteInputField.Text);
        }

        public void WriteToNFC(string message)
        {
            if (PortCheck() != true)
            {
                MakeMessage("Please choose another port", "Com Error");
                return;
            }

            if (ComTextBox.Text == "")
            {
                MakeMessage("Please enter a com port for the NFC Scanner", "Com Error");
                return;
            }
            else
            {
                StartComs(ComTextBox.Text);
            }

            if (serialPort.IsOpen == false)
            {
                SetStatus("Error");
                MakeMessage("There was an issue with the communication to the port. Port not open or there was an error during an operation. please restart this application and try again.", "ERROR");
                return;
            }

            SetStatus("Writing");

            byte[] data = Encoding.ASCII.GetBytes(WriteInputField.Text);
            Debug.WriteLine(data);
            serialPort.Write(data, 0, data.Length);

            //Beep();

            serialPort.Close();
            MakeMessage("Your message was written to the NFC card.", "Success");
            SetStatus("Idle");
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //DispString = serialPort.ReadExisting();
            //this.Invoke(new EventHandler(DisplayText));
            int length = serialPort.BytesToRead;
            byte[] buf = new byte[length];

            serialPort.Read(buf, 0, length);
            System.Diagnostics.Debug.WriteLine("Received Data:" + buf);

            DispString = System.Text.Encoding.Default.GetString(buf, 0, buf.Length);
            this.Invoke(new EventHandler(DisplayText));
            serialPort.Close();
        }

        private void DisplayText(object sender, EventArgs e)
        {
            ReadDataBox.AppendText("\n" + DispString);
        }

        public void SetStatus(string status)
        {
            StatusText.Text = "Status: " + status;
        }

        public void MakeMessage(string MainText, string TitleText)
        {
            string message = MainText;
            string title = TitleText;
            MessageBox.Show(message, title);
        }

        public void Anticollision()
        {
            serialPort.Write(new byte[] { 0x02, 0x03, 0x05 }, 0, 3);
        }

        public void SelectCard()
        {
            serialPort.Write(new byte[] { 0x02, 0x04, 0x06 }, 0, 3);
        }

        public void Beep()
        {
            serialPort.Write(new byte[] { 0x02, 0x13, 0x15 }, 0, 3);
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            if (SectorText.Text == "" || BlockText.Text == "")
            {
                MakeMessage("Please enter a sector and block to look at.", "Read Error");
                return;
            }

            if (PortCheck() != true)
            {
                MakeMessage("Please choose another port", "Com Error");
                return;
            }

            if (ComTextBox.Text == "")
            {
                MakeMessage("Please enter a com port for the NFC Scanner", "Com Error");
                return;
            }
            else
            {
                StartComs(ComTextBox.Text);
            }

            if (serialPort.IsOpen == false)
            {
                SetStatus("Error");
                MakeMessage("There was an issue with the communication to the port. Port not open or there was an error during an operation. please restart this application and try again.", "ERROR");
                return;
            }

            SetStatus("Reading");

            //serialPort.Write(new byte[] { 0x03, 0x06, 0x00, 0x09 }, 0, 4);

            MakeMessage("Data read successfully.", "Success");
            SetStatus("Idle");
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Display a MsgBox asking the user to save changes or abort.
            if (MessageBox.Show("Do you want to exit?", "Closing", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Cancel the Closing event from closing the form.
                e.Cancel = true;
            }
            else
            {
                serialPort.Close();
                MakeMessage("You are now closing the application. Shutting down coms.", "Closing");
            }
        }

        public bool DoesCardExcist()
        {
            bool Excistance = false;

            serialPort.Write(new byte[] { 0x03, 0x02, 0x00, 0x05 }, 0, 4);

            //if ("")

            return Excistance;
        }

        private void ClearReadButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you would like to clear the read data bay.", "Clear?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ReadDataBox.Text = "";
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void ListComs_Click(object sender, EventArgs e)
        {
            IdentifyPorts();
        }


        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ReadDataBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void WriteInputField_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
