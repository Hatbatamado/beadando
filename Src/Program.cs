using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace beadando
{
    class Program
    {
        static Bejegyzes[] bejegy;
        static void Main(string[] args)
        {
            Console.Write("A fálj elérési útvonala: ");
            Feladat_Rek fel = null;
            int hiba = Beolvas(Console.ReadLine());
            switch (hiba)
            {
                case -1:
                    Console.Write("A megadott fájl nem található\nIndítsa újra a programot és írjon be helyes elérési útvonalat!");
                    break;
                case 1:
                    Console.Write("A fájl első sorában található bejegyzések db száma túl nagy, max 1000 lehet\nJavítsa ki a fájlt, majd indítsa újra programot!");
                    break;
                case 2:
                    Console.Write("A fájlban található bejegyzések száma több, mint 1000, maximum 1000 lehet\nJavítsa ki a fájlt, majd indítsa újra programot!");
                    break;
                case 3:
                    Console.Write("Az első sorban lévő db szám és a bejegyzések száma nem egyezik meg\nJavítsa ki a fájlt, majd indítsa újra programot!");
                    break;
                case 4:
                    Console.Write("Valamelyik kezdő/vég anyag száma meghaladja a maximumot, a 200-at\nJavítsa ki a fájlt, majd indítsa újra programot!");
                    break;
                case 5:
                    Console.Write("Van két különböző bejegyzés, ahol a kezdő és a vég anyag megegyezik\nJavítsa ki a fájlt, majd indítsa újra programot!");
                    break;
                case 0:
                    Console.Write("A fájl tartalma sikeresen beolvasva\n");
                    fel= new Feladat_Rek(1, bejegy);
                    Console.Write("\nA feladat megoldása(i): \n" + fel.Megoldas());
                    break;
                default:
                    break;
            }            

            Console.ReadKey();
        }

        static int Beolvas(string eleres)
        {
            int hiba = -1;
            if (File.Exists(eleres))
            {
                StreamReader sr = new StreamReader(eleres);
                int db = Convert.ToInt32(sr.ReadLine()); //hány bejegyzés
                sr.Close();
                hiba = Ellenorzes(db);
                if (hiba == 0)
                {
                    int bejegyzesek_db = 0;
                    sr = new StreamReader(eleres);
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        sr.ReadLine();
                        bejegyzesek_db++;
                    }
                    sr.Close();
                    hiba = Ellenorzes(db, bejegyzesek_db);
                    if (hiba == 0)
                    {
                        bejegy = new Bejegyzes[db];
                        string[] seged;
                        sr = new StreamReader(eleres);
                        sr.ReadLine();
                        int i = 0;
                        while (!sr.EndOfStream && hiba == 0)
                        {
                            seged = sr.ReadLine().Split(' ');
                            hiba = Ellenorzes(seged[0], seged[2]);
                            bejegy[i++] = new Bejegyzes(Convert.ToInt32(seged[0]), seged[1], Convert.ToInt32(seged[2]));
                        }
                        sr.Close();
                    }
                }
                if (bejegy.Length != 0)
                    hiba = Ellenorzes(bejegy);
            }
            return hiba;
        }

        static int Ellenorzes(int db)
        {
            if (db > 1000)
                return 1;
            else
                return 0;
        }

        static int Ellenorzes(int db, int bejegyzesek_db)
        {
            if (bejegyzesek_db > 1000)
                return 2;
            else if (db != bejegyzesek_db)
                return 3;
            else return 0;
        }

        static int Ellenorzes(string kezd_a, string veg_a)
        {
            if (int.Parse(kezd_a) > 200 || int.Parse(veg_a) > 200)
                return 4;
            else
                return 0;
        }

        static int Ellenorzes(Bejegyzes[] bejegy)
        {
            //nincs két különböző bejegyzés, amelyekben mind az első, mind a második anyag megegyezne
            Bejegyzes seged;
            for (int i = 0; i < bejegy.Length; i++)
            {
                seged = bejegy[i];
                for (int j = i + 1; j < bejegy.Length; j++)
                {
                    if (seged.Kezdo_anyag == bejegy[j].Kezdo_anyag && seged.Veg_anyag == bejegy[j].Veg_anyag)
                        return 5;
                }
                return 0;
            }
            return 5;
        }
    }
}
