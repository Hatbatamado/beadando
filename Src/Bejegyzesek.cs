using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace beadando
{
    class Bejegyzes
    {
        int kezdo_anyag, veg_anyag;

        public int Veg_anyag
        {
            get { return veg_anyag; }
        }

        public int Kezdo_anyag
        {
            get { return kezdo_anyag; }
        }
        string katalizator;
        public Bejegyzes(int kezdo_anyag, string katalizator, int veg_anyag)
        {
            this.kezdo_anyag = kezdo_anyag;
            this.katalizator = katalizator;
            this.veg_anyag = veg_anyag;
        }

        public static Bejegyzes[] Beolvas(string eleres)
        {
            Bejegyzes[] bejegy;
            StreamReader sr = new StreamReader(eleres);
            int db = Convert.ToInt32(sr.ReadLine()); //hány bejegyzés
            bejegy = new Bejegyzes[db];
            string[] seged;
            for (int i = 0; i < db; i++)
            {
                seged = sr.ReadLine().Split(' ');
                bejegy[i] = new Bejegyzes(Convert.ToInt32(seged[0]), seged[1], Convert.ToInt32(seged[2]));
            }
            sr.Close();
            return bejegy;
        }
    }
}
