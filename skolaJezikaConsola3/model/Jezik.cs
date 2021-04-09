using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skolaJezikaConsola3
{
    public class Jezik
    {
        public string Naziv { get; set; }
        public string Oznaka { get; set; }
        public Jezik() : base()
        {

        }
        public Jezik(string naziv, string oznaka)
        {
            this.Naziv = naziv;
            this.Oznaka = oznaka;


        }

        public override string ToString()
        {
            return "Naziv Jezika:  "+this.Naziv+"\n";
        }
    }
}
