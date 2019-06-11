using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace SecNet_2
{
    class SecNetCommunications
    {
        private string portNum;
        private int baudRate;
        private string userPassword;
        private string systemAdminPassword;
        private string oksPassword;
        private SerialPort port;
      
        public SecNetCommunications(string port , int baudRate)
        {
            this.portNum = port;
            this.baudRate = baudRate;
        }

        public void begin()
        {
            port = new SerialPort(portNum, baudRate, Parity.None, 8, StopBits.One);
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            // Begin communications
            port.Open();

        }
        private void port_DataReceived(object sender , SerialDataReceivedEventArgs e)
        {
            string data = port.ReadExisting();
            // Show all the incoming data in the port's buffer
            Console.WriteLine(data);

            byte[] buff = Encoding.UTF8.GetBytes(data);
            Console.WriteLine("CHAR ARR: " + BitConverter.ToString(buff));
        }
        public void setUserPassword(string password)
        {
            this.userPassword = password;
        }
        public void setSystemAdminPassword(string password)
        {
            this.systemAdminPassword = password;
        }
        public void setOksPassword(string password)
        {
            this.oksPassword = password;
        }

        public bool checkUserPassword(string inputPassword)
        {
            return userPassword.Equals(inputPassword);
        }
        public bool checkSystemAdminPassword(string inputPassword)
        {
            return systemAdminPassword.Equals(inputPassword);
        }
        public bool checkOkPassword(string inputPassword)
        {
            return oksPassword.Equals(inputPassword);
        }
    }
}
