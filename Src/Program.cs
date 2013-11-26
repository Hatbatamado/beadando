using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beadando
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("A fálj elérési útvonala: ");
            Bejegyzes[] bejegy = Bejegyzes.Beolvas(Console.ReadLine());

            Console.ReadKey();
        }
    }
}
