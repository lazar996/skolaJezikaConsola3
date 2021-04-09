using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skolaJezikaConsola3
{
     public class Kurs
    {

        public Jezik JezikKursa { get; set; }
        public  TipKursa Nivo { get; set; }
        public double Cena { get; set; }
        public Nastavnik Ime { get; set; }
        public Ucenik ImeUcenika { get; set; }

        public Kurs() : base()
        {

        }

        public Kurs(Jezik jezikKursa,TipKursa nivo, double cena, Nastavnik ime,Ucenik imeUcenika)
        {
            
            this.JezikKursa = jezikKursa;
            this.Nivo = nivo;
            this.Cena = cena;
            this.Ime = ime;
            this.ImeUcenika = imeUcenika;
        }


        public override string ToString()
        {
            return  "Naziv kursa: "+ this.JezikKursa.Naziv + "\nNivo kursa: "+this.Nivo.NivoJezika+"\nCena: \t "+this.Cena +" din"+ "\nNastavnik: "+ this.Ime.Ime+ "\nUcenik: " + this.ImeUcenika.Ime+ "\n";
        }
    }
}
