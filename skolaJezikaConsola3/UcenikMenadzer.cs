using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace skolaJezikaConsola3
{
    class UcenikMenadzer
    {
        public static List<Ucenik> Ucenici = new List<Ucenik>();


        public static void PrikaziUcenike()
        {
            int d = 0;
            for (int i = 0; i < Ucenici.Count; i++)
            {
                if (Ucenici[i].StanjeU == true)
                {
                    Console.WriteLine("Redni broj ucenika: "+d++);
                    Console.WriteLine("ime: " + Ucenici[i].Ime + "\nprezime: " + Ucenici[i].Prezime + "\nJMBG: " + Ucenici[i].Jmbg + "\n");
                    Console.WriteLine("-------------------------");
                }
            }
        }
        public static void PretragaUcenika(string param)
        {

            StringBuilder sb = new StringBuilder();

            switch (param)
            {
                case "ime":
                    Console.WriteLine("unesite ime za pretragu:  ");
                    string ime = Console.ReadLine();
                    foreach (Ucenik k in Ucenici)
                    {
                        if (k.Ime.ToLower().Contains(ime.ToLower()))
                        {
                            sb.AppendLine("ime: "+k.Ime);
                        }
                    }
                    Console.WriteLine(sb.ToString());
                    break;
                case "id":
                    Console.WriteLine("Unesite ID za pretragu: ");
                    string id = Console.ReadLine();
                    foreach (Ucenik k in Ucenici)
                    {
                        if (k.IdUcenika.Contains(id))
                        {
                            sb.AppendLine("ID kod: "+ k.IdUcenika+"\nime: "+k.Ime);
                        }
                    }
                    Console.WriteLine(sb.ToString());
                    break;

                default:
                    break;
  
        }

    }

        public static void ObrisiUcenika()
        {

            PrikaziUcenike();
            Console.WriteLine("Unesite Id ucenika kojeg zelite da izbriste: ");
            string Id = Console.ReadLine();
            for (int i = 0; i < Ucenici.Count; i++)
            {
                if (Ucenici[i].IdUcenika == Id)
                {
                    Ucenici.Remove(Ucenici[i]);
                }
            }
        }

        public static void SortirajUcenike()
        {
            for (int i = 0; i < Ucenici.Count - 1; i++)
            {
                for (int j = i + 1; j < (Ucenici.Count); j++)
                {
                    if (Ucenici[i].Ime.CompareTo(Ucenici[j].Ime) == 1)
                    {
                        Ucenik temp = Ucenici[i];
                        Ucenici[i] = Ucenici[j];
                        Ucenici[j] = temp;

                    }
                }
            }
            foreach (Ucenik k in Ucenici)
            {
                Console.WriteLine(k);
            }
        }


        public static void IzmeniUcenika()
        {

            Console.WriteLine("uneti Id ucenika");
            string id = Console.ReadLine();

            for (int i = 0; i < Ucenici.Count; i++)
            {
                if (Ucenici[i].IdUcenika == id)
                {

                    Console.WriteLine("ime");
                    Ucenici[i].Ime = Console.ReadLine();
                    Console.WriteLine("prezime");
                    Ucenici[i].Prezime = Console.ReadLine();
                    Console.WriteLine("jmbg");
                    Ucenici[i].Jmbg =Convert.ToInt32( Console.ReadLine());          
                    Console.WriteLine("Id ucenika: ");
                    Ucenici[i].IdUcenika = Console.ReadLine();
                    Ucenici[i].StanjeU = true;
                }

            }

        }

        public static void DodajUcenika()
        {
            Console.WriteLine("ime");
            string ime = Console.ReadLine();
            Console.WriteLine("prezime");
            string prezime = Console.ReadLine();
            Console.WriteLine("jmbg");
            int jmbg = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Id ucenika: ");
            string IdUcenika = Console.ReadLine();
            bool StanjeU = true;

            Ucenici.Add(new Ucenik(ime, prezime, jmbg, IdUcenika,StanjeU));
        }

        public static void UcitajUcenike()
        {

            string path = @"..\..\ucenici.txt";
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
                        int jmbg =Convert.ToInt32( tokeni[2]);
                        bool StanjeU = Convert.ToBoolean(tokeni[4]);
                        Ucenici.Add(new Ucenik(tokeni[0], tokeni[1], jmbg, tokeni[3],StanjeU));
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

        public static void SacuvajUcenike()
        {

            string path = @"..\..\ucenici.txt";
            if (!File.Exists(path))
            {
                File.Create(path);

            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Ucenik k in Ucenici)
                {
                    sw.WriteLine(k.Ime + "|" + k.Prezime + "|" + k.Jmbg + "|"+ k.IdUcenika + "|" +k.StanjeU);

                }
            }
        }
    }
}

