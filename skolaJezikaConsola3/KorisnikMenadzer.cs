using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace skolaJezikaConsola3
{
    public class KorisnikMenadzer
    {
        public static List<Korisnik> korisnici = new List<Korisnik>();

        public static void DodajKorisnika()
        {
            Console.WriteLine("ime");
            string ime = Console.ReadLine();
            Console.WriteLine("prezime");
            string prezime = Console.ReadLine();
            Console.WriteLine("jmbg");
            int jmbg = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Korisnicko ime");
            string korisnickoIme = Console.ReadLine();
            Console.WriteLine("lozinka");
            string lozinka = Console.ReadLine();
            Console.WriteLine("Tip korisnika");
            string tipKorisnika = Console.ReadLine();
            bool stanjeP = true;
            korisnici.Add(new Korisnik(ime, prezime, jmbg, korisnickoIme, lozinka,tipKorisnika,stanjeP));
        }

        public static void SortirajKorisnike()
        {
            for (int i = 0; i < korisnici.Count-1; i++)
            {
                for (int j = i + 1; j < (korisnici.Count); j++)
                {
                    if (korisnici[i].Ime.CompareTo(korisnici[j].Ime)==1)
                    {
                        Korisnik temp = korisnici[i];
                        korisnici[i] = korisnici[j];
                        korisnici[j] = temp;

                    }
                }
            }
            foreach (Korisnik k in korisnici)
            {
                Console.WriteLine(k);
            }
        }

        public static void IzmeniKorisnika()
        {
            
            Console.WriteLine("uneti JMBG");
            int jmbg = Convert.ToInt32( Console.ReadLine());

            for (int i = 0; i < korisnici.Count; i++)
            {
                if (korisnici[i].Jmbg == jmbg)
                {

                    Console.WriteLine("ime");
                    korisnici[i].Ime = Console.ReadLine();
                    Console.WriteLine("prezime");
                    korisnici[i].Prezime = Console.ReadLine();
                    Console.WriteLine("jmbg");
                    korisnici[i].Jmbg = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Korisnicko ime");
                    korisnici[i].KorisnickoIme = Console.ReadLine();
                    Console.WriteLine("lozinka");
                    string lozinka = Console.ReadLine();
                    Console.WriteLine("Tip korisnika");
                    string tipKorisnika = Console.ReadLine();
                    korisnici[i].StanjeP = true;
                   
                }

            }

        }


        public static void ObrisiKorisnika()
        {
            Console.WriteLine("Unesite JMBG korisnika kojeg zelite da obriste: ");
            int jmbg =Convert.ToInt32( Console.ReadLine());
            for (int i = 0; i < korisnici.Count; i++)
            {
                if (korisnici[i].Jmbg == jmbg)
                {
                    korisnici[i].StanjeP = false;
                }
            }
        }



        public static void PrikaziKorisnika()
        {
            for (int i = 0; i < korisnici.Count; i++)
            {
                if (korisnici[i].StanjeP == true)
                {
                    Console.WriteLine("ime: " + korisnici[i].Ime + "\nprezime: " + korisnici[i].Prezime + "\nJMBG: " + korisnici[i].Jmbg + "\n");

                }
            }
        }

        public static void UcitajKorisnike()
        {
            string path = @"..\..\korisnici.txt";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {

                    string[] tokeni = line.Split('|');
                    if (tokeni.Length != 7)
                    {
                        throw new TokenException("Nedovoljan broj tokena");

                    }
                    else
                    {
                        int jmbg = Convert.ToInt32(tokeni[2]);
                        bool stanjeP = Convert.ToBoolean(tokeni[6]);
                        korisnici.Add(new Korisnik(tokeni[0], tokeni[1], jmbg, tokeni[3], tokeni[4],tokeni[5], stanjeP));
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


        public static void SacuvajKorisnike()
        {

            string path = @"..\..\korisnici.txt";
            if (!File.Exists(path))
            {
                File.Create(path);

            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Korisnik k in korisnici)
                {
                    sw.WriteLine(k.Ime + "|" + k.Prezime + "|" + k.Jmbg + "|" + k.KorisnickoIme + "|" + k.Lozinka+"|"+k.TipKorisnika + "|" +k.StanjeP);


                }
            }
        }

        public static void PretragaKorisnika(string param)
        {

            StringBuilder sb = new StringBuilder();

            switch (param)
            {
                case "ime":
                    Console.WriteLine("unesite ime za pretragu:  ");
                    string ime = Console.ReadLine();
                    foreach (Korisnik k in korisnici)
                    {
                        if (k.Ime.ToLower().Contains(ime.ToLower()))
                        {
                            sb.AppendLine(k.Ime);
                        }             
                    }
                    Console.WriteLine("Korisnicko ime postoji : "+sb.ToString());
                    break;

                case "Jmbg":
                    Console.WriteLine("Unesite jmbg za pretragu: ");
                    int jmbg = Convert.ToInt32( Console.ReadLine());
                    foreach (Korisnik k in korisnici)
                    {
                        if (k.Jmbg.Equals(jmbg))
                        {
                            sb.Append(k.Jmbg);
                        }
                    }
                    Console.WriteLine("Korisnik sa jmbg-om postoji: "+sb);
                    break;
                    
                default:
                    break;
            }

           
        }

    }
}
