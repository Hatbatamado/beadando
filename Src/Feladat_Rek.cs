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
                        ////elag_t = Tomb(elag_t, elag_sor++, elag_in); //tömbbe berakjuk az elágazások indexjét és növeljük a tömb méretét
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
                        ////Tomb_torol(bejegy);
                    }
                }
                else
                {
                    //0 (arany) megtalálva
                    ////Tomb_Eredmeny_Torles(0);
                    ////Tomb_torol(bejegy);
                }
            }
            /*else
            {
                Tomb_Eredmeny_Torles(1);
                Tomb_torol(bejegy);
            }*/
        }
    }
}
