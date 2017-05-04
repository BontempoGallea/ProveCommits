using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TimeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = System.DateTime.Now;
            System.Threading.Thread.Sleep(5000);
            DateTime dt1 = System.DateTime.Now;

            Console.WriteLine("Date time 1: " + dt);
            Console.WriteLine("Date time 2: " + dt1);
            Console.WriteLine("Difference in time: " + (dt1 - dt));

            bool moreThan3 = ((dt1 - dt).TotalSeconds > 3) ? true : false;

            Console.WriteLine("Is the difference greater than 3s ? " + moreThan3);

            Console.ReadKey();
        }
    }
}
