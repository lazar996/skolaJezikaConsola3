using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skolaJezikaConsola3
{
    public class Uplata : Kurs
    {
        public double CenaUplate { get; set; }
        public int IdUplatnice { get; set; }
        public Uplata() : base()
        {

        }
        public Uplata(Jezik jezikKursa, TipKursa nivo, double cena, Nastavnik ime, Ucenik imeUcenika, double cenaUplate, int idUplatnice)
            : base(jezikKursa,nivo,cena,ime,imeUcenika)
        {
            this.JezikKursa = jezikKursa;
            this.Nivo = nivo;
            this.Cena = cena;
            this.Ime = ime;
            this.ImeUcenika = imeUcenika;
            this.CenaUplate = cenaUplate;
            this.IdUplatnice = idUplatnice;
        }


        public override string ToString()
        {
            return "Naziv kursa: " + this.JezikKursa.Naziv + "\nNivo kursa: " + this.Nivo.NivoJezika + "\nCena: \t " + this.Cena + " din" + "\nNastavnik: " + this.Ime.Ime + "\nUcenik: " + this.ImeUcenika.Ime + "\nUplaceno: "+this.CenaUplate+"\nId Uplatnice: "+this.IdUplatnice + "\n" ;

        }
    }
}

