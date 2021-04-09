using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace skolaJezikaConsola3
{
    class NastavnikMenadzer
    {

        public static List<Nastavnik> nastavnici = new List<Nastavnik>();


        public static void PrikaziNastavnika()
        {
            int c = 0;
            for (int i = 0; i < nastavnici.Count; i++)
            {
                if (nastavnici[i].Stanje == true)
                {
                    Console.WriteLine("RB. Profesora:  " + c++);
                    Console.WriteLine("ime: "+nastavnici[i].Ime+ "\nprezime: " + nastavnici[i].Prezime+ "\nJMBG: " + nastavnici[i].Jmbg+ "\nID profesora: " + nastavnici[i].IDprofesora);
                    Console.WriteLine("-------------------------");
                }
            }
        }



        public static void DodajNastavnika()
        {
            Console.WriteLine("ime");
            string ime = Console.ReadLine();
            Console.WriteLine("prezime");
            string prezime = Console.ReadLine();
            Console.WriteLine("jmbg");
            int jmbg =Convert.ToInt32( Console.ReadLine());

            Console.WriteLine("IdProfesora: ");
            string IdProfesora = Console.ReadLine();
            bool stanje = true;



            nastavnici.Add(new Nastavnik(ime, prezime, jmbg, IdProfesora, stanje));
        }


        public static void IzmenaProfesora()
        {
            PrikaziNastavnika();
            Console.WriteLine("uneti ID profesora");
            string Id = Console.ReadLine();

            for (int i = 0; i < nastavnici.Count; i++)
            {
                if (nastavnici[i].IDprofesora == Id)
                {

                    Console.WriteLine("ime");
                    nastavnici[i].Ime = Console.ReadLine();
                    Console.WriteLine("prezime");
                    nastavnici[i].Prezime = Console.ReadLine();
                    Console.WriteLine("jmbg");
                    nastavnici[i].Jmbg = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("IdProfesora: ");
                    nastavnici[i].IDprofesora = Console.ReadLine();
                    nastavnici[i].Stanje = true;
                   
                }

            }

        }


        public static void ObrisiNastavnika()
        {

            PrikaziNastavnika();
            Console.WriteLine("Unesite Id profesora kojeg zelite da izbriste: ");
            string Id = Console.ReadLine();
            for (int i = 0; i < nastavnici.Count; i++)
            {
                if (nastavnici[i].IDprofesora == Id)
                {
                    nastavnici[i].Stanje = false;
                    // nastavnici.Remove(nastavnici[i]);
                }
            }
        }

        public static void PretragaNastavnika(string param)
        {

            StringBuilder sb = new StringBuilder();

            switch (param)
            {
                case "ime":
                    Console.WriteLine("unesite ime za pretragu:  ");
                    string ime = Console.ReadLine();
                    foreach (Nastavnik k in nastavnici)
                    {
                        if (k.Ime.ToLower().Contains(ime.ToLower()))
                        {
                            sb.AppendLine("ime: " + k.Ime);
                        }
                    }
                    Console.WriteLine(sb.ToString());
                    break;
                case "id":
                    Console.WriteLine("Unesite ID za pretragu: ");
                    string id = Console.ReadLine();
                    foreach (Nastavnik k in nastavnici)
                    {
                        if (k.IDprofesora.Contains(id))
                        {
                            sb.AppendLine("ID kod: " + k.IDprofesora + "\nime: " + k.Ime);
                        }
                    }
                    Console.WriteLine(sb.ToString());
                    break;

                default:
                    break;

            }

        }
        public static void SortirajNastavnike()
        {
            for (int i = 0; i < nastavnici.Count - 1; i++)
            {
                for (int j = i + 1; j < (nastavnici.Count); j++)
                {
                    if (nastavnici[i].Ime.CompareTo(nastavnici[j].Ime) == 1)
                    {
                        Nastavnik temp = nastavnici[i];
                        nastavnici[i] = nastavnici[j];
                        nastavnici[j] = temp;

                    }
                }
            }
            foreach (Nastavnik k in nastavnici)
            {
                Console.WriteLine(k);
            }
        }


        public static void UcitajNastavnike()
        {

            string path = @"..\..\profesori.txt";
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
                        int jmbg = Convert.ToInt32(tokeni[2]);
                        bool stanje = Convert.ToBoolean(tokeni[4]);
                        nastavnici.Add(new Nastavnik(tokeni[0], tokeni[1], jmbg, tokeni[3],stanje));
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

            string path = @"..\..\profesori.txt";
            if (!File.Exists(path))
            {
                File.Create(path);

            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Nastavnik k in nastavnici)
                {
                    sw.WriteLine(k.Ime + "|" + k.Prezime + "|" + k.Jmbg + "|" + k.IDprofesora + "|"+k.Stanje);

                }
            }
        }
    }
}


