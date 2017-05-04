
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketName
{
    class Receiver
    {
        IPAddress _multicastIp = IPAddress.Parse("224.5.6.7");
        int _port = 15000;

        public void entryPoint()
        {
            startListening();
        }

        private void startListening()
        {
            Receive();
        }

        private void Receive()
        {
            UdpClient client = new UdpClient(_port);
            IPEndPoint ipEP = new IPEndPoint(IPAddress.Any, _port);

            byte[] data = new byte[1024];

            while (true)
            {
                Console.WriteLine("Waiting for packet to arrive: ...");
                data = client.Receive(ref ipEP);
                Console.WriteLine("Packet received: <<<" + Encoding.ASCII.GetString(data) + " >>>");
            }
        }
    }
}