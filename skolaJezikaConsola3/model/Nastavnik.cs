using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skolaJezikaConsola3
{
    public class Nastavnik : Osoba
    {

        public string IDprofesora { get; set; }
        public bool Stanje { get; set; }

        public Nastavnik() : base()
        {

        }
        public Nastavnik(string ime, string prezime, int jmbg,string IdProfesora, bool stanje)
            :base(ime,prezime,jmbg)
                 {
            this.IDprofesora = IdProfesora;
            this.Stanje = stanje;
        }
        public override string ToString()
        {
            return "Ime:  " + this.Ime + "\nPrezime: " + this.Prezime + "\nJMBG: " + this.Jmbg + "\nID profesora:" +this.IDprofesora+"\n";

        }

    }



}
