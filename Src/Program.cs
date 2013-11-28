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
        static Bejegyzes[] bejegy; //bejegyzéseket tartalmazó változó
        static void Main(string[] args)
        {
            string menu = ""; //program újraindítása, bezárása a beolvasott értéknek megfelelően
            do //menüs szerkezet
            {
                Console.Clear();
                Console.Write("A fálj elérési útvonala: ");
                Feladat_Rek fel;
                int hiba = Beolvas(Console.ReadLine()); //fájl beolvasása a megadott útvonalon, majd pedig hiba keresése
                switch (hiba)
                {
                    case -1: //rossz elérési útvonal / a fájl nem létezik
                        Console.Write("A megadott helyen fájl nem található vagy nem létezik\n\nA program újraindításához írja be, hogy: vissza\nA program"
                            +"bezárásához írja be, hogy: exit\n");
                        menu = Console.ReadLine();
                        break;
                    case 1: //a fájl első sora nem megfelelő értékű
                        Console.Write("A fájl első sorában található bejegyzések db száma túl nagy, max 1000 lehet\n\nJavítsa ki a fájlt, majd ha kész, akkor"
                        +"program újraindításához írja be, hogy: vissza\nA program bezárásához írja be, hogy: exit\n");
                        menu = Console.ReadLine();
                        break;
                    case 2: //a bejegyzések száma meghaladja az 1000-et
                        Console.Write("A fájlban található bejegyzések száma több, mint 1000, maximum 1000 lehet\n\nJavítsa ki a fájlt, majd ha kész, akkor"
                        +"program újraindításához írja be, hogy: vissza\nA program bezárásához írja be, hogy: exit\n");
                        menu = Console.ReadLine();
                        break;
                    case 3: //a bejegyzések száma és az első sorban lévő érték nem egyezik meg
                        Console.Write("Az első sorban lévő db szám és a bejegyzések száma nem egyezik meg\n\nJavítsa ki a fájlt, majd ha kész, akkor"
                        +"program újraindításához írja be, hogy: vissza\nA program bezárásához írja be, hogy: exit\n");
                        menu = Console.ReadLine();
                        break;
                    case 4: //a használt anyagok száma maximum 200 lehet
                        Console.Write("Valamelyik kezdő/vég anyag száma meghaladja a maximumot, a 200-at\n\nJavítsa ki a fájlt, majd ha kész, akkor"
                        +"program újraindításához írja be, hogy: vissza\nA program bezárásához írja be, hogy: exit\n");
                        menu = Console.ReadLine();
                        break;
                    case 5: //van két különböző bejegyzés, ahol a kezdő és a vég anyag megegyezik
                        Console.Write("Van két különböző bejegyzés, ahol a kezdő és a vég anyag megegyezik\n\nJavítsa ki a fájlt, majd ha kész, akkor"
                        +"program újraindításához írja be, hogy: vissza\nA program bezárásához írja be, hogy: exit\n");
                        menu = Console.ReadLine();
                        break;
                    case 6: //rossz katalizátor érték van megadva
                        Console.Write("Az egyik katalizátor nem az angol abc betűi közé tartozik\n\nJavítsa ki a fájlt, majd ha kész, akkor"
                        +"program újraindításához írja be, hogy: vissza\nA program bezárásához írja be, hogy: exit\n");
                        menu = Console.ReadLine();
                        break;
                    case 0:
                        Console.Write("A fájl tartalma sikeresen beolvasva\n"); //a program nem talált hibát és sikeresen beolvasta a fájlt a bejegy nevű változóba
                        fel = new Feladat_Rek(1, bejegy);                       //így meghívja a feladat rekurzív megoldásást
                        Console.Write("\nA feladat megoldása(i): \n" + fel.Megoldas()); //feladat megoldásának kiírása a képernyőre
                        Console.Write("\nA program újra futtatásához írja be, hogy: ujra\nA program bezárásához írja be, hogy: exit\n");
                        menu = Console.ReadLine();
                        break;
                }
            } while (menu != "exit" && menu == "vissza" || menu == "ujra");
        }

        static int Beolvas(string eleres)
        {
            int hiba = -1; //rossz elérési útvonal / a fájl nem létezik
            if (File.Exists(eleres))
            {
                StreamReader sr = new StreamReader(eleres);
                int db = Convert.ToInt32(sr.ReadLine()); //hány bejegyzés
                sr.Close();
                hiba = Ellenorzes(db); //az első sorban megadott érték ellenőrzése
                if (hiba == 0)         //ha az érték megfelelő akkor:
                {
                    int bejegyzesek_db = 0;
                    sr = new StreamReader(eleres);
                    sr.ReadLine(); //első sor átugrása
                    while (!sr.EndOfStream)
                    {
                        sr.ReadLine(); //1 sor beolvasása
                        bejegyzesek_db++; //sorok megszámlálása
                    }
                    sr.Close();
                    hiba = Ellenorzes(db, bejegyzesek_db); //sorszámok és a sorszámok és első sor értékének ellenőrzése
                    if (hiba == 0)
                    {
                        bejegy = new Bejegyzes[db]; //a helyes értékkel a tömb létrehozása
                        string[] seged; //beolvasott sor feldarabolásához szükséges változó
                        sr = new StreamReader(eleres);
                        sr.ReadLine();
                        int i = 0;
                        int kezd_a, veg_a; //kiindulási anyag, végtermék
                        while (!sr.EndOfStream && hiba == 0)
                        {
                            seged = sr.ReadLine().Split(' ');
                            kezd_a = Convert.ToInt32(seged[0]);
                            veg_a = Convert.ToInt32(seged[2]);
                            hiba = Ellenorzes(kezd_a, seged[1], veg_a); //kiindulási anyag, végtermék és a katalizátor ellenőrzése
                            if (hiba == 0)
                                bejegy[i++] = new Bejegyzes(kezd_a, seged[1], veg_a); //a megfelelő értékekkel a tömb feltöltése
                        }
                        sr.Close();
                    }
                }
                if (bejegy.Length != 0 && hiba == 0)
                    hiba = Ellenorzes(bejegy); //bejegyzések ellenőrzése
            }
            return hiba;
        }

        static int Ellenorzes(int db) //az első sorban megadott érték ellenőrzése
        {
            if (db > 1000) //az értéknek 1000-nél kisebb kell lennie
                return 1;
            else
                return 0;
        }

        static int Ellenorzes(int db, int bejegyzesek_db) //sorszámok és a sorszámok és első sor értékének ellenőrzése
        {
            if (bejegyzesek_db > 1000) //sorszámok értéknek 1000-nél kisebb kell lennie
                return 2;
            else if (db != bejegyzesek_db) //sorszámok és első sor értékének meg kell egyeznie
                return 3;
            else
                return 0;
        }

        static int Ellenorzes(int kezd_a, string katalizator, int veg_a) //kiindulási anyag, végtermék és a katalizátor ellenőrzése
        {
            string katalizatorok = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //katalizátor ellenőrzéséhez szükséges változó
            int db = 0;
            char kat = Convert.ToChar(katalizator.ToUpper()); //beolvasott érték nagy betűssé alakítása, így elég egyszer végig menni a betűkön
            if (kezd_a > 200 || veg_a > 200) //a használt anyagok száma maximum 200 lehet
                return 4;
            else if (kezd_a < 200 && veg_a < 200)
            {
                for (int i = 0; i < katalizatorok.Length; i++)
                    if (katalizatorok[i] == kat)
                        db++; //ha a beolvasott katalizátor és a változó értékei nem egyeznek, akkor növeljük a db értékét
                if (db == 0)
                    return 6;
                else
                    return 0;
            }
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
