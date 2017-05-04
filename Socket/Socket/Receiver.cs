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
        private readonly UdpClient uc = new UdpClient();
        private static int _port = 15000;
        private static IPAddress _multicast = IPAddress.Parse("224.5.6.7");

        public void entryPoint()
        {
            startListening();
        }

        private void startListening()
        {
            this.uc.BeginReceive(Receive, new object());
        }

        private void Receive(IAsyncResult ar)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipEP = new IPEndPoint(IPAddress.Any, _port);
            s.Bind(ipEP);
            
            s.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(_multicast, IPAddress.Any));

            while (true)
            {
                byte[] data = new byte[1024];
                s.Receive(data);
                string str = Encoding.ASCII.GetString(data, 0, data.Length);
                Console.WriteLine("Data received: " + str);
            }
        }
    }
}
