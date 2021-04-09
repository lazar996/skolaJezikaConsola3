using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skolaJezikaConsola3
{
    public class Ucenik : Osoba
    {
        public string IdUcenika{ get; set; }
        public bool StanjeU { get; set; }
        public Ucenik() : base()
        {

        }
        public Ucenik(string ime, string prezime, int jmbg,string idUcenika,bool stanjeU) 
          
            :base(ime,prezime,jmbg)

        {
            this.IdUcenika= idUcenika;
            this.StanjeU = stanjeU;
        }
        public override string ToString()
        {
            return "Ime:  " + this.Ime + "\nPrezime: " + this.Prezime + "\nJMBG: " + this.Jmbg  + "\nID Ucenika: " + this.IdUcenika+"\n";

        }

    }

    }

