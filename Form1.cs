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

        public Form1()
        {
            InitializeComponent();

            SetStatus("Initializing");
            StartComs();
        }

        private void StartComs()
        {
           serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
           serialPort.ReadTimeout = 5000;
           serialPort.Open();
           SetStatus("Idle");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            WriteToNFC(WriteInputField.Text);
        }

        public void WriteToNFC(string message)
        {
            SetStatus("Writing");

            if(serialPort.IsOpen == false)
            {
                SetStatus("Error");
                MakeMessage("There was an issue with the communication to the port. Port not open or there was an error during an operation. please restart this application and try again.", "ERROR");
                return;
            }

            /// start work here || serialPort.Read

            MakeMessage("Your message was written to the NFC card.", "Success");
            SetStatus("Idle");
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

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Display a MsgBox asking the user to save changes or abort.
            if (MessageBox.Show("Do you want to exit?", "Closing", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Cancel the Closing event from closing the form.
                e.Cancel = true;
                // Call method to save file...
            }
            else
            {
                serialPort.Close();
                MakeMessage("You are now closing the application. Shutting down coms.", "Closing");
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
