using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
