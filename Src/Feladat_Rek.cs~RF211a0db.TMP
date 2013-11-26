using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beadando
{
    class Feladat_Rek
    {
        int db = 0; //keresett anyag db száma
        string elag_in = ""; //elágazások indexe
        string[] elag_t; //elágazások tömbje
        int elag_sor = 0; //elágazások tömbjének sorszáma
        Bejegyzes[] bejegy;

        public Feladat_Rek(int keresett_anyag, Bejegyzes[] bejegy)
        {
            this.bejegy = bejegy;
            Rekur(keresett_anyag);
        }

        private void Rekur(int keresett_anyag)
        {
            ////if (Ellenorzes(bejegy, keresett_anyag))
            {
                if (keresett_anyag != 0)
                {
                    db = 0;
                    elag_in = "";
                    for (int i = 0; i < bejegy.Length; i++) //hány db keresett anyag van
                        if (bejegy[i].Kezdo_anyag == keresett_anyag)
                        {
                            db++;
                            elag_in += i + ",";
                        }
                    if (db > 1) //ha több, mint 1, akkor hívjuk meg a függvényt újra az első elágazás elemével
                    {
                        elag_t = Tomb(elag_t, elag_sor++, elag_in); //tömbbe berakjuk az elágazások indexjét és növeljük a tömb méretét
                        string[] elag_in2 = elag_t[elag_t.Length - 1].Split(',');
                        if (elag_in2.Length > 0)
                        {
                            elag_in = elag_in.Substring(0, elag_in.LastIndexOf(','));
                            ////Tomb_Eredmeny(elag_in);
                            Rekur(bejegy[Convert.ToInt32(elag_in2[0])].Veg_anyag); //elágazás első elemével megyünk tovább
                        }
                    }
                    else if (db == 1) //ha 1 db van, akkor ezzel megyünk tovább
                    {
                        elag_in = elag_in.Substring(0, elag_in.LastIndexOf(','));
                        ////Tomb_Eredmeny(elag_in);
                        Rekur(bejegy[Convert.ToInt32(elag_in)].Veg_anyag);
                    }
                    else
                    {
                        ////Tomb_Eredmeny_Torles(1);
                        Tomb_torol();
                    }
                }
                else
                {
                    //0 (arany) megtalálva
                    ////Tomb_Eredmeny_Torles(0);
                    Tomb_torol();
                }
            }
            /*else
            {
                Tomb_Eredmeny_Torles(1);
                Tomb_torol(bejegy);
            }*/
        }

        private string[] Tomb(string[] tomb, int index, string elemek) //tömbhöz új elem hozzáadása és a végén ez a tömb használata
        {
            string[] segedtomb;
            if (tomb == null)
            {
                segedtomb = new string[++index];
                segedtomb[--index] = elemek.Substring(0, elemek.LastIndexOf(','));
            }

            else
            {
                segedtomb = new string[tomb.Length + 1];
                for (int i = 0; i < tomb.Length; i++)
                    segedtomb[i] = tomb[i];
                segedtomb[tomb.Length] = elemek.Substring(0, elemek.LastIndexOf(','));
            }

            return segedtomb;
        }

        private void Tomb_torol()
        {
            elag_t = Torol(elag_t); //töröljük az elázasás(oka)t, amin már átmentünk
            if (elag_t.Length != 0) //ha van még elágazás, amin nem mentünk keresztül, akkor azzal folytatjuk
            {
                string[] seged2 = elag_t[elag_t.Length - 1].Split(',');
                Rekur(bejegy[Convert.ToInt32(seged2[0])].Veg_anyag);
            }
        }

        static string[] Torol(string[] tomb)
        {
            string[] segedtomb = null;
            string seged = "";
            if (tomb != null)
            {
                string[] seged2 = tomb[tomb.Length - 1].Split(',');
                if (seged2.Length >= 1) //van még elágazás
                {
                    segedtomb = new string[tomb.Length];
                    for (int i = 0; i < segedtomb.Length - 1; i++) //az utolsó elágazás kivételével, átmentjük az elágazásokat
                        segedtomb[i] = tomb[i];
                    for (int j = 1; j < seged2.Length; j++) //az utolsó elágazást, amin átmentünk azt kihagyjuk és elmentjük a többit
                        seged += seged2[j] + ",";
                    if (seged.Length > 1) //ha van még elagzás, akkor azzal folytatjuk
                    {
                        seged = seged.Substring(0, seged.LastIndexOf(','));
                        segedtomb[segedtomb.Length - 1] = seged;
                    }
                    else //ha az elágazás tömb adott indexén nincs már több elágazás, akkor megkeressük, hogy
                    //a tömbben van-e még olyan elágazás, amin nem mentünk keresztül
                    {
                        int a = tomb.Length;
                        seged2 = tomb[a - 1].Split(',');
                        while (a > 0 && seged2.Length < 2) //keresés
                        {
                            a--;
                            seged2 = tomb[a].Split(',');
                        }
                        if (a >= 0) //találtunk olyan elágazást, amin még nem mentünk át
                        {
                            segedtomb = new string[a + 1];
                            for (int i = 0; i < segedtomb.Length - 1; i++) //az utolsó elágazás kivételével, átmentjük az elágazásokat
                                segedtomb[i] = tomb[i];
                            seged2 = tomb[a].Split(',');
                            for (int j = 1; j < seged2.Length; j++) //az utolsó elágazást, amin átmentünk azt kihagyjuk és elmentjük a többit
                                seged += seged2[j] + ",";
                            if (seged.Length > 1) //ha van még elagzás, akkor azzal folytatjuk
                            {
                                seged = seged.Substring(0, seged.LastIndexOf(','));
                                segedtomb[a] = seged;
                            }
                            else //ha nincs, akkor minden lehetséges módon bejártuk az elágazásokat
                                segedtomb = null;
                        }
                    }
                }
            }

            return segedtomb;
        }
    }
}
