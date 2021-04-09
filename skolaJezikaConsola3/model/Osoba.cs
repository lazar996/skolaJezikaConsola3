using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skolaJezikaConsola3
{
    public class Osoba
    {

        public string Ime { get; set; }
        public string Prezime{ get; set; }
        public int Jmbg {get; set;}

         public Osoba()
         {
       
         }
         public Osoba(string ime, string prezime, int jmbg)
         {
             this.Ime = ime;
             this.Prezime = prezime;
             this.Jmbg = jmbg;
         }

         public virtual void pozdrav()
         {
             Console.WriteLine("Pozdrav iz osobe!");
         
         
         }

        public override string ToString()
{
        return "Ime:  "+ this.Ime +"\nPrezime: "+ this.Prezime+"\nJMBG: "+ this.Jmbg+"\n";

}
}}
    
        
    

