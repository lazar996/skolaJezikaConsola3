using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace skolaJezikaConsola3
{
    class KursMenadzer
    {
        public static List<Kurs> kursevi = new List<Kurs>();

        public static void PrikaziKurseve()
        {
           
            foreach (Kurs k in kursevi)
            {
                Console.WriteLine(k);

            }

        }

        public static void randomBroj()
        {

            Random random = new Random();
            int randomNumber = random.Next(0, 100);


        }

        public static void DodajKurs()
        {
           
            Console.WriteLine("jezik kursa");
            JezikMenadzer.PrikaziJezike();
            int a= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-------------------------");
            Console.WriteLine("tip kursa");
            TipKursaMenadzer.PrikaziTipove();
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("cena kursa");
            double cena =Convert.ToDouble( Console.ReadLine());
            Console.WriteLine("-------------------------");
            NastavnikMenadzer.PrikaziNastavnika();
            int c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-------------------------");
            UcenikMenadzer.PrikaziUcenike();
            int d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-------------------------");
            Random random = new Random();
            int e = random.Next(0, 1000);
            kursevi.Add(new Kurs(JezikMenadzer.jezici[a], TipKursaMenadzer.tip[b], cena, NastavnikMenadzer.nastavnici[c],UcenikMenadzer.Ucenici[d]));
            UplataMenadzer.uplate.Add(new Uplata(JezikMenadzer.jezici[a], TipKursaMenadzer.tip[b], cena, NastavnikMenadzer.nastavnici[c], UcenikMenadzer.Ucenici[d],0,e));
        }

        public static void UcitajKurseve()
        {
            
            string path = @"..\..\kursevi.txt";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string line = "";
 
                while ((line = sr.ReadLine()) != null)
                {
                    string[] tokeni = line.Split('|');

                    if (tokeni.Length != 5)
                    {
                        throw new TokenException("Nedovoljan broj tokena");

                    }
                    else
                    {

                        Jezik JezikKursa = pronadjiJezik(tokeni[0]) ;
                        TipKursa nivo = pronadjiTip(tokeni[1]);
                        double cena = Convert.ToDouble( tokeni[2]);
                        Nastavnik Ime = pronadjiNastavnika(tokeni[3]);
                        Ucenik ImeUcenika = pronadjiUcenika(tokeni[4]);
                        kursevi.Add(new Kurs(JezikKursa, nivo, cena, Ime, ImeUcenika));
                        
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


        
          public static Jezik  pronadjiJezik(string Naziv)
        {
           
                foreach (Jezik Jezik in JezikMenadzer.jezici)
            {
                if (Jezik.Naziv.Equals(Naziv))
                {
                    return Jezik;
                }
            }
            return null;
    }

        public static TipKursa pronadjiTip(string NivoJezika)
        {

            foreach (TipKursa ti in TipKursaMenadzer.tip)
            {
                if (ti.NivoJezika.Equals(NivoJezika))
                {
                    return ti;
                }
            }
            return null;
        }
        public static Nastavnik pronadjiNastavnika(string ime)
        {

            foreach (Nastavnik na in NastavnikMenadzer.nastavnici)
            {
                if (na.Ime.Equals(ime))
                {
                    return na;
                }
            }
            return null;
        }

        public static Ucenik pronadjiUcenika(string ImeUcenika)
        {

            foreach (Ucenik uc in UcenikMenadzer.Ucenici)
            {
                if (uc.Ime.Equals(ImeUcenika))
                {
                    return uc;
                }
            }
            return null;
        }


        public static void SacuvajKurseve()
        {
            
            string path = @"..\..\kursevi.txt";
            if (!File.Exists(path))
            {
                File.Create(path);

            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Kurs k in kursevi)
                {
                  sw.WriteLine(k.JezikKursa.Naziv+ "|" +k.Nivo.NivoJezika+ "|" +k.Cena+"|"+k.Ime.Ime+ "|"+k.ImeUcenika.Ime);


                }
            }
        }


    }

}

