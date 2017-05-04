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
        IPAddress _multicastIp = IPAddress.Parse("224.5.6.7");
        int _port = 15000;

        public void entryPoint()
        {
            send();
        }

        private void send()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            s.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(_multicastIp));
            s.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2); // 2 represents the TTL

            IPEndPoint ipEP = new IPEndPoint(_multicastIp, _port); s.Connect(ipEP);

            byte[] data = Encoding.ASCII.GetBytes("Data sent!");

            while (true)
            {
                s.Send(data, data.Length, SocketFlags.None);
                Console.WriteLine("I just sent a packet: <<< " + Encoding.ASCII.GetString(data) + " >>> --->" + s.LocalEndPoint.ToString());
            }
        }
    }
}
