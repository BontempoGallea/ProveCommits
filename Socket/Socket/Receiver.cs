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
<<<<<<< HEAD
        private readonly UdpClient uc = new UdpClient(15000);

        public void entryPoint()
        {
            receivePacket();
=======
        private readonly UdpClient uc = new UdpClient();
        private static int _port = 15000;
        private static IPAddress _multicast = IPAddress.Parse("224.5.6.7");

        public void entryPoint()
        {
            startListening();
>>>>>>> refs/remotes/origin/master
        }

        private void receivePacket()
        {
<<<<<<< HEAD
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = uc.Receive(ref ip);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("I've received this datagram: " + message);
            Console.WriteLine("premi bottone:\n " );
            Console.ReadKey();
            entryPoint();
=======
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
>>>>>>> refs/remotes/origin/master
        }
    }
}
