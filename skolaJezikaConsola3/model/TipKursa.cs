using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skolaJezikaConsola3
{
    public class TipKursa
    {
        public string NivoJezika { get; set; }
        public string OznakaNivo { get; set; }

        public TipKursa() : base()
        {

        }
        public TipKursa(string nivoJezika, string oznakaNivoa)
        {
            this.NivoJezika = nivoJezika;
            this.OznakaNivo = oznakaNivoa;



        }
        public override string ToString()
        {
            return  "Nivo jezika: "+this.NivoJezika+ "\nOznaka jezika: "  + this.OznakaNivo+ "\n";
        }
    }
}
