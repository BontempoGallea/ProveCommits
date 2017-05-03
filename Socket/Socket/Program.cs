using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Socket
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress a1 = new IPAddress(new byte[] { 100, 101, 102, 103 });
            IPAddress a2 = IPAddress.Parse("100.101.102.103");
            IPAddress a3 = IPAddress.Parse("[3ADE:4567:890A:9:8:1:ADFE:7]");
            IPEndPoint ep1 = new IPEndPoint(a1, 2000);

            Console.WriteLine(a1.Equals(a2));
            Console.WriteLine(a1 + " family: " + a1.AddressFamily);
            Console.WriteLine(a3.AddressFamily);
            Console.WriteLine(ep1.ToString());
            Console.ReadKey();
        }
    }
}
