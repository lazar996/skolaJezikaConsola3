using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skolaJezikaConsola3
{
    public class Korisnik: Osoba
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string TipKorisnika { get; set; }
        public bool StanjeP { get; set; }
        public Korisnik(): base()
        {

        }
        public Korisnik(string ime, string prezime, int jmbg, string korisnickoIme, string lozinka, string tipKorisnika, bool stanjeP)
            : base(ime, prezime, jmbg)
     
        
        {
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            this.TipKorisnika = tipKorisnika;
            this.StanjeP = stanjeP;
        }
        public override string ToString()
{
 	     return base.ToString();
}
        public bool LogIn(string ime, string lozinka)
        {
            if (ime == this.KorisnickoIme && lozinka == this.Lozinka )
            {
                return true;


            }
            return false;
        }
    }
    }

