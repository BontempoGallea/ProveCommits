using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketName
{
    class Sender
    {
        int _port = 15000;

        public void entryPoint()
        {
            send();
        }

        private void send()
        {
            UdpClient client = new UdpClient();
            IPEndPoint ipEP = new IPEndPoint(IPAddress.Broadcast, _port);
            byte[] data = Encoding.ASCII.GetBytes("Data sent!");

            while (true)
            {
                client.Send(data, data.Length, ipEP);
                Console.WriteLine("I just sent a packet: <<< " + Encoding.ASCII.GetString(data) + " >>> ---> " + ipEP.ToString());
                Thread.Sleep(5000);
            }
        }
    }
}
