using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mutithreading
{
    class Program
    {
        static bool _done;
        static void Main(string[] args)
        {
            ThreadStart action = () =>
            {
                entryPoint();
            };
            new Thread(action).Start();
            action();
            Console.ReadKey();
        }

        static void entryPoint()
        {
            if (!_done)
            {
                //_done = true;
                Console.WriteLine("Done!");
                _done = true;
            }
        }
    }
}
