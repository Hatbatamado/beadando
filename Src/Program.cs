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
            Feladat_Rek fel = new Feladat_Rek(1, bejegy);
            Console.Write(fel.Kiir());

            Console.ReadKey();
        }

        static bool Ellenorzes(Bejegyzes[] bejegy)
        {
            //nincs két különböző bejegyzés, amelyekben mind az első, mind a második anyag megegyezne
            Bejegyzes seged;
            for (int i = 0; i < bejegy.Length; i++)
            {
                seged = bejegy[i];
                for (int j = i + 1; j < bejegy.Length; j++)
                {
                    if (seged.Kezdo_anyag == bejegy[j].Kezdo_anyag && seged.Veg_anyag == bejegy[j].Veg_anyag)
                        return false;
                }
                return true;
            }
            return false;
        }
    }
}
