using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Socket
{
    class Receiver
    {
        private readonly UdpClient uc = new UdpClient(15000);

        public void entryPoint()
        {
            receivePacket();
        }

        private void receivePacket()
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = uc.Receive(ref ip);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("I've received this datagram: " + message);
            Console.WriteLine("premi bottone:\n " );
            Console.ReadKey();
            entryPoint();
        }
    }
}
