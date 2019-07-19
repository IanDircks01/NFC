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
            foreach (string port in ports)
            {
                string op;
                op = p;
                p = op + " | " + port;
            }
            MakeMessage(p, "Ports");
            ReadDataBox.Font = new Font("Lucida Sans Unicode", this.Font.Size);
        }

        private void StartComs(string com)
        {
           serialPort = new SerialPort(com.Normalize(), 9600, Parity.None, 8, StopBits.One);
           serialPort.ReadTimeout = 5000;
           serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
           serialPort.Open();
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
            if(ComTextBox.Text == "")
            {
                MakeMessage("Please enter a com port for the NFC Scanner", "Com Error");
                return;
            }
            else
            {
                StartComs(ComTextBox.Text);
            }

            if(serialPort.IsOpen == false)
            {
                SetStatus("Error");
                MakeMessage("There was an issue with the communication to the port. Port not open or there was an error during an operation. please restart this application and try again.", "ERROR");
                return;
            }

            SetStatus("Writing");

            SelectCard();
            Beep();

            MakeMessage("Your message was written to the NFC card.", "Success");
            SetStatus("Idle");
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            DispString = serialPort.ReadExisting();
            this.Invoke(new EventHandler(DisplayText));
            serialPort.Close();
        }

        private void DisplayText(object sender, EventArgs e)
        {
            ReadDataBox.AppendText(DispString);
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

        public void SelectCard()
        {
            serialPort.Write(new byte[] { 0x02, 0x04, 0x06}, 0, 3);
        }

        public void Beep()
        {
            serialPort.Write(new byte[] { 0x02, 0x13, 0x15 }, 0, 3);
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            //read data
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

        private void ClearReadButton_Click(object sender, EventArgs e)
        {
            ReadDataBox.Text = "";
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
    }
}
