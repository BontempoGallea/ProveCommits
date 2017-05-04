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
        UdpClient uc = new UdpClient();
        IPAddress _multicastIp = IPAddress.Parse("224.5.6.7");
        int _port = 15000;

        public void entryPoint()
        {
            send();
        }

        private void send()
        {
            foreach(IPAddress localIp in Dns.GetHostAddresses(Dns.GetHostName()).Where(i => i.AddressFamily == AddressFamily.InterNetwork))
            {
                IPAddress ipToUse = localIp;
                using(var mSendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    mSendSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership,
                                       new MulticastOption(_multicastIp, localIp));
                    mSendSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 255);
                    mSendSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    mSendSocket.MulticastLoopback = true;
                    mSendSocket.Bind(new IPEndPoint(ipToUse, _port));

                    while (true)
                    {
                        byte[] data = Encoding.ASCII.GetBytes("Data sent!");
                        var ipEP = new IPEndPoint(_multicastIp, _port);
                        mSendSocket.SendTo(data, ipEP);
                        Console.WriteLine("I've sent some data. --- " + Encoding.ASCII.GetString(data) + " ---> " + _multicastIp.ToString());
                        Thread.Sleep(5000);
                    }
                }
                
            }
        }
    }
}
