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
        private readonly UdpClient uc = new UdpClient();

        public void entryPoint()
        {
            
        }

        private void startListening()
        {
            this.uc.BeginReceive(Receive, new object());
        }

        private void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 15000);
            byte[] data = uc.EndReceive(ar, ref ip);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("I've received this datagram: " + message);
            //startListening();
        }
    }
}
