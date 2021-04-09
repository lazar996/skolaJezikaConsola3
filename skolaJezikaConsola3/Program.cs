using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skolaJezikaConsola3
{
    public class Program
    {
        static bool ulogovan = false;
        static void Main(string[] args)
        {

            try
            {
                KorisnikMenadzer.UcitajKorisnike();
                JezikMenadzer.UcitajJezike();
                NastavnikMenadzer.UcitajNastavnike();
                TipKursaMenadzer.UcitajTipove();
                PodaciSkola.UcitajSkolu();
                UcenikMenadzer.UcitajUcenike();
                KursMenadzer.UcitajKurseve();
                UplataMenadzer.UcitajUplate();

            }
            catch (TokenException te)
            {
                Console.WriteLine(te.Message + "\n" + te.StackTrace);
            }
            catch (Exception)
            {

                throw;
            }


            while (!ulogovan)
            {
                Console.WriteLine("Unesite korisnicko ime: ");
                string ime = Console.ReadLine();
                Console.WriteLine("uneti lozinku ");
                string lozinka = Console.ReadLine();
                for (int i = 0; i < KorisnikMenadzer.korisnici.Count; i++)
                {

                    if (KorisnikMenadzer.korisnici[i].LogIn(ime, lozinka))
                    {
                        for (int d = 0; d < KorisnikMenadzer.korisnici.Count; i++)
                        {
                            if (KorisnikMenadzer.korisnici[i].TipKorisnika == "admin")
                            {
                                ulogovan = true;
                                Console.WriteLine("Ulogvani ste kao administrator: "+KorisnikMenadzer.korisnici[i].Ime);
                                MainMenu();
                                break;

                            }
                            if (KorisnikMenadzer.korisnici[i].TipKorisnika == "zaposlen")
                            {

                                Console.WriteLine("Ulogovani ste kao korisnik: "+KorisnikMenadzer.korisnici[i].Ime);
                                ulogovan = true;
                               MainKorisnik();
                                break;

                            }
                        }

                    }

                }

                if (!ulogovan) Console.WriteLine("Pogresno uneti podaci, pokusajte ponovo ");


                KorisnikMenadzer.SacuvajKorisnike();
                JezikMenadzer.SacuvajJezike();
                TipKursaMenadzer.SacuvajTipove();
                KursMenadzer.SacuvajKurseve();
                PodaciSkola.SacuvajPodatke();
                NastavnikMenadzer.SacuvajPodatke();
                UcenikMenadzer.SacuvajUcenike();
                UplataMenadzer.SacuvajUplate();
            }
        }


        private static void MainKorisnik()
        {
            string unos = "";
            while (unos != "0")
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Podaci o ucenicima");
                Console.WriteLine("2. Dodavanje ucenika");
                Console.WriteLine("3. Dodaj ucenika na kurs");
                Console.WriteLine("4. Podaci o jezicima, tipovima");
                Console.WriteLine("5. Podaci o kursevima");
                Console.WriteLine("[0]. Exit");
                unos = Console.ReadLine();

                switch (unos)
                {

                    case "1": UcenikMenadzer.PrikaziUcenike(); break;
                    case "2": UcenikMenadzer.DodajUcenika(); break;
                    case "3": KursMenadzer.DodajKurs(); break;
                    case "4": Ucenici(); break;
                    case "5": KursMenadzer.PrikaziKurseve(); break;
         
                    default:
                        break;
                }

            }
        }

        private static void MainMenu()
        {
            string unos = "";
            while (unos != "0")
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Podaci o korisncima");
                Console.WriteLine("2. Podaci o skoli");
                Console.WriteLine("3. Podaci o Profesoru");
                Console.WriteLine("4. Podaci o Ucenicima");
                Console.WriteLine("5. Podaci o jezicima, tipovima");
                Console.WriteLine("6. Podaci o kursevima");
                Console.WriteLine("7. Podaci o uplati");
                Console.WriteLine("[0]. Exit");     
                unos = Console.ReadLine();

                switch (unos)
                {

                    case "1": Meni(); break;
                    case "2":PodaciSkole(); break;
                    case "3": Nastavnik();break;
                    case "4": Ucenici(); break;
                    case "5": JeziciTipoviKursevi(); break;
                    case "6": Kursevi(); break;
                    case "7": Uplate(); break;

                    default:
                        break;
                }
            }
        }

        private static void Uplate()
        {

            string unos = "";
            while (unos != "0")
            {
                Console.WriteLine("1. Prikazi sve kurseve");
                Console.WriteLine("2. Prikazi sve kurseve sa uplatama");
                Console.WriteLine("3. Uplati kurs");
                Console.WriteLine("[0]. Exit");
                unos = Console.ReadLine();

                switch (unos)
                {

                    case "1": KursMenadzer.PrikaziKurseve(); break;
                    case "2": UplataMenadzer.PrikaziUplate(); break;
                    case "3": UplataMenadzer.uplati(); break;
                    case "4": break;

                    default:
                        break;
                }
            }
        }
        private static void Ucenici()
        {

            string unos = "";
            while (unos != "0")
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Prikazi sve ucenike");
                Console.WriteLine("2. Dodaj novog ucenika");
                Console.WriteLine("3. Izmeni podatke ucenika");
                Console.WriteLine("4. Pronadji ucenika po imenu");
                Console.WriteLine("5. Pronadji ucenika po id-u");
                Console.WriteLine("6. Izbrisi ucenika");
                Console.WriteLine("7. Sortiraj ucenike po imenu");
                Console.WriteLine("[0]. Exit");
                unos = Console.ReadLine();
                switch (unos)
                {

                    case "1": UcenikMenadzer.PrikaziUcenike(); ; break;
                    case "2": UcenikMenadzer.DodajUcenika(); break;
                    case "3": UcenikMenadzer.IzmeniUcenika(); break;
                    case "4": UcenikMenadzer.PretragaUcenika("ime"); break;
                    case "5": UcenikMenadzer.PretragaUcenika("id"); break;
                    case "6": UcenikMenadzer.ObrisiUcenika(); break;
                    case "7": UcenikMenadzer.SortirajUcenike();break;
                    default:
                        break;
                }
            }
        }
        private static void PodaciSkole()
        {
            string unos = "";
            while (unos != "0")
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("1. Podaci o skoli");
                Console.WriteLine("2. Izmena podataka o skoli");
                Console.WriteLine("[0]. Exit");
                Console.WriteLine("----------------------------");
                unos = Console.ReadLine();
                switch (unos)
                {

                    case "1": PodaciSkola.PrikaziSkolu(); break;
                    case "2": PodaciSkola.IzmeniPodatkeSkola(); break;    
                    default:
                        break;      
                }
            }
        }


        private static void JeziciTipoviKursevi()
        {
            Console.WriteLine("\n");
            string unos = "";
            while (unos != "0")
            {
                Console.WriteLine("1. Podaci o jezicima");
                Console.WriteLine("2. Dodaj jezik");
                Console.WriteLine("3. Obrisi jezik");
                Console.WriteLine("---------------------");
                Console.WriteLine("4. Podaci o tipovima");
                Console.WriteLine("5. Dodaj tip jezika");
                Console.WriteLine("6. Obrisi tip jezik");
                Console.WriteLine("---------------------");
                Console.WriteLine("[0]. Exit");
                
                unos = Console.ReadLine();

                switch (unos)
                {
                    case "1": JezikMenadzer.PrikaziJezike(); break;
                    case "2": JezikMenadzer.DodajJezik(); break;
                    case "3": JezikMenadzer.ObrisiJezika(); break;                 
                    case "4": TipKursaMenadzer.PrikaziTipove(); break;
                    case "5": TipKursaMenadzer.DodajTip(); break;
                    case "6": TipKursaMenadzer.ObrisiTip();break;
                    default:
                        break;
                }

            }
        }

        private static void Kursevi()
        {

            string unos = "";
            while (unos != "0")
            {
                Console.WriteLine("1. Prikazi sve kurseve");
                Console.WriteLine("2. Dodaj nov kurs");
                Console.WriteLine("3. Izmeni podatke kursa");
                Console.WriteLine("[0]. Exit");
                unos = Console.ReadLine();

                switch (unos)
                {

                    case "1": KursMenadzer.PrikaziKurseve(); break;
                    case "2": KursMenadzer.DodajKurs(); break;
                    case "3": break;
                    case "4": break;

                    default:
                        break;
                }
            }
        }

        private static void  Nastavnik()
        {

            string unos = "";
            while (unos != "0")
            {
                Console.WriteLine("1. Prikazi sve Profesore");
                Console.WriteLine("2. Dodaj novog profesora");
                Console.WriteLine("3. Izmeni podatke profesora");
                Console.WriteLine("4. Pronadji korisnika po imenu");
                Console.WriteLine("5. Pronadji korisnika po ID ");
                Console.WriteLine("6. Izbrisi profesora");
                Console.WriteLine("7. Sortiraj profesore po imenu");
                Console.WriteLine("[0]. Exit");
                unos = Console.ReadLine();

                switch (unos)
                {
                    
                    case "1": NastavnikMenadzer.PrikaziNastavnika(); break;
                    case "2": NastavnikMenadzer.DodajNastavnika(); break;
                    case "3": NastavnikMenadzer.IzmenaProfesora(); break;
                    case "4": NastavnikMenadzer.PretragaNastavnika("ime"); break;
                    case "5": NastavnikMenadzer.PretragaNastavnika("id"); break;
                    case "7": NastavnikMenadzer.SortirajNastavnike(); break;
                    case "6": NastavnikMenadzer.ObrisiNastavnika(); break;
                    default:
                        break;
                }

            }

        }

        private static void Meni()
        {

            string unos = "";
            while (unos != "0")
            {    
                Console.WriteLine("\n"+"1. Prikaz korisnika");
                Console.WriteLine("2. Dodavanje");
                Console.WriteLine("3. Izmena");
                Console.WriteLine("4. Brisanje");
                Console.WriteLine("5. Sortiranje korisnika");
                Console.WriteLine("6. Pretraga korisnika po imenu");
                Console.WriteLine("7. Pretraga korisnika po JMBG");
                Console.WriteLine("[0]. Exit");

                unos = Console.ReadLine();

                switch (unos)
                {
                    case "1": KorisnikMenadzer.PrikaziKorisnika();  break ;
                    case "2": KorisnikMenadzer.DodajKorisnika();break ;
                    case "3": KorisnikMenadzer.IzmeniKorisnika();break ;
                    case "4": KorisnikMenadzer.ObrisiKorisnika(); break ;
                    case "5": KorisnikMenadzer.SortirajKorisnike(); break;
                    case "6": KorisnikMenadzer.PretragaKorisnika("ime"); break;
                    case "7":KorisnikMenadzer.PretragaKorisnika("Jmbg");break;

                    default:
                        break;
                }
            }

        }
    }
}
