
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
        private static IPAddress _multicast = IPAddress.Parse("224.168.100.2");
        private static IPAddress myip;
        private static EndPoint mipep;

        public Receiver(IPAddress a)
        {
            myip = a;
        }

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
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipEP = new IPEndPoint(myip, _port);
            s.Bind(ipEP);

            s.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(_multicast, IPAddress.Any));
            IPEndPoint groupEP = new IPEndPoint(_multicast, _port);
            EndPoint remoteEP = (EndPoint)new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                byte[] data = new byte[1024];
                s.ReceiveFrom(data, ref remoteEP);
                string str = Encoding.ASCII.GetString(data, 0, data.Length);
                Console.WriteLine("Data received: " + str);
            }
        }
    }
}