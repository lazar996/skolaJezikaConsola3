using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skolaJezikaConsola3
{
    public class Skola
    {
        
        public string NazivSkole { get; set; }
        public string AdresaSkole { get; set; }
        public string TelefonSkole { get; set; }
        public string EmailSkole { get; set; }
        public string AdresaSajta { get; set; }
        public string PIB { get; set; }
        public string MaticniBrojSkole { get; set; }
        public string BrojZiroRacuna { get; set; }


        public Skola()

        {

        }

        public Skola(string nazivSkole, string adresaSkole, string telefonSkole, string emailSkole, string adresaSajta, string pib,
                     string maticniBrojSkole, string brojZiroRacuna)
        {
            this.NazivSkole = nazivSkole;
            this.AdresaSkole = adresaSkole;
            this.TelefonSkole = telefonSkole;
            this.EmailSkole = emailSkole;
            this.AdresaSajta = adresaSajta;
            this.PIB = pib;
            this.MaticniBrojSkole = maticniBrojSkole;
            this.BrojZiroRacuna = brojZiroRacuna;


        }
        public override string ToString()
        {
            return "Naziv skole: " + this.NazivSkole + "\nAdresa skole: " + this.AdresaSkole + "\nTelefon skole: "+ this.TelefonSkole
                   +"\nEmail skole: "+this.EmailSkole+"\nAdersa sajta: "+this.AdresaSajta+"\nPib: "+this.PIB+"\nMaticni br. skole: "
                   +this.MaticniBrojSkole+"\nBroj ziro racuna: "+this.BrojZiroRacuna+"\n";
        }
    }
}
