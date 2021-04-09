using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace skolaJezikaConsola3
{
    class PodaciSkola
    {
        public static List<Skola> podaci = new List<Skola>();



        public static void PrikaziSkolu()
        {

            foreach (Skola s in podaci)
            {
                Console.WriteLine(s);

            }
        }

        public static void IzmeniPodatkeSkola()
        {

            for (int i = 0; i < podaci.Count; i++)
            {
               

                    Console.WriteLine("Naziv Skole");
                    podaci[i].NazivSkole = Console.ReadLine();
                    Console.WriteLine("Ulica Skole");
                    podaci[i].AdresaSkole = Console.ReadLine();
                    Console.WriteLine("Broje telefona skole");
                    podaci[i].TelefonSkole = Console.ReadLine();
                    Console.WriteLine("Mail adresa skole");
                    podaci[i].EmailSkole = Console.ReadLine();
                    Console.WriteLine("Web stranica skole");
                    podaci[i].AdresaSajta = Console.ReadLine();
                    Console.WriteLine("PIB");
                    podaci[i].PIB = Console.ReadLine();
                    Console.WriteLine("Maticni broj skole");
                    podaci[i].MaticniBrojSkole = Console.ReadLine();
                    Console.WriteLine("broj ziro racuna");
                    podaci[i].BrojZiroRacuna = Console.ReadLine();
            
            }   

        }

        public static void UcitajSkolu()
        {
          
            
            string path = @"..\..\podaciSkola.txt";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {

                    string[] tokeni = line.Split('|');
                    if (tokeni.Length != 8)
                    {
                        throw new TokenException("Nedovoljan broj tokena");

                    }
                    else
                    {

                        podaci.Add(new Skola(tokeni[0], tokeni[1], tokeni[2], tokeni[3], tokeni[4], tokeni[5], tokeni[6], tokeni[7]));
                    }


                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("Datoteka" + path + " ne postoji");

                File.Create(path);

            }
        }

        public static void SacuvajPodatke()
        {

            string path = @"..\..\podaciSkola.txt";
            if (!File.Exists(path))
            {
                File.Create(path);

            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Skola k in podaci)
                {
                    sw.WriteLine(k.NazivSkole+"|"+k.AdresaSkole+"|"+k.TelefonSkole+"|"+k.EmailSkole+"|"+k.AdresaSajta+"|"+k.PIB+"|"+k.MaticniBrojSkole+"|"+k.BrojZiroRacuna);

                }
            }
        }


        /*    public static void UcitajSkolu()
            {
                Skola s = new Skola("st.", "Bul. Oslobodjenja 125", "0212551", "st@gmail.com", "www.st.com", "7858", "12123", "23232");
                podaciSkola.Add(s);
            }
        }*/
    }
}
