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
    class Program
    {
        private static IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        private static IPAddress myIP = null;

        static void Main(string[] args)
        {
            // Mi cerco il mio indirizzo IPv4
            foreach(var ip in host.AddressList)
            {
                Console.WriteLine("Ip address: " + ip.ToString() +
                                   " --- family: " + ip.AddressFamily);
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    myIP = ip;
                }
            }

            Console.WriteLine("My ip address is ---> " + myIP.ToString());
            Console.Write("Premi un tasto per continuare...");
            Console.ReadKey();

            Sender s = new Sender();
            Thread st = new Thread(s.entryPoint);
            st.Start();

            /*
            Receiver r = new Receiver(myIP);
            Thread rt = new Thread(r.entryPoint);
            rt.Start();
            */
        }
    }
}
