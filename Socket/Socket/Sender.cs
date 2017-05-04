using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Socket
{
    class Sender
    {
        public void entryPoint()
        {
            UdpClient uc = new UdpClient();
            send(uc);
        }

        private void send(UdpClient uc)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, 15000);
            byte[] data = Encoding.ASCII.GetBytes("Data sent!");
            uc.Send(data, data.Length, ip);
            Console.WriteLine("I've just sent some data to: " + ip.ToString());
            uc.Close();
        }
    }
}
