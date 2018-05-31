using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace UDPapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Нажмите любую клавишу и все компьютеры, получившие сообщение, выключаться!");
            Console.ReadLine();

            UdpClient client = new UdpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("224.1.8.5"), 3535));

            byte[] data = Encoding.Default.GetBytes("shutdown /s /t 0");

            try
            {
                client.Send(data, data.Length);
            }
            catch(SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }

            client.Close();
            Console.ReadLine();
        }
    }
}
