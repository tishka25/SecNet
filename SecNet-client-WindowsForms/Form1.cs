using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;



namespace SecNet
{
    public partial class Form1 : Form
    {



        SerialPort port;
        public Form1()
        {
            InitializeComponent();
        }

        private void ConectBtn_Click(object sender, EventArgs e)
        {
            port = new SerialPort(comPortField.Text , int.Parse(baudRateField.Text) , Parity.None , 8 , StopBits.One);
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            //port.ErrorReceived+= 

            // Begin communications
            port.Open();
            //Show a dialog message after the port has been opened
            DialogResult r = MessageBox.Show("Успешно свързване към устройство!");
            

        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = port.ReadExisting();
            // Show all the incoming data in the port's buffer
            Console.WriteLine(data);

            byte[] buff = Encoding.UTF8.GetBytes(data);
            Console.WriteLine("CHAR ARR: " + BitConverter.ToString(buff));

        }
    }
}
