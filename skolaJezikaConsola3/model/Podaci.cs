using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skolaJezikaConsola3
{
    public class Podaci : Korisnik
    {
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }

        public Podaci(): base()
        {

        }
        public Podaci(string ime, string prezime, int jmbg, string korisnickoIme, string lozinka, string email, string adresa,string telefon,string tipKorisnika, bool stanjeP)
            :base(ime,prezime,jmbg,korisnickoIme,lozinka,tipKorisnika,stanjeP)
                 {

            this.Email = email;
            this.Adresa = adresa;
            this.Telefon = telefon;

        }

    }
}
