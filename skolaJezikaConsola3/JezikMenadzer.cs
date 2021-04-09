using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace skolaJezikaConsola3
{
    class JezikMenadzer
    {

        public static List<Jezik> jezici = new List<Jezik>();

        public static void ObrisiJezika()
        {
            Console.WriteLine("Unesite ime jezika koji brisete: ");
            string naziv = Console.ReadLine();
            for (int i = 0; i < jezici.Count; i++)
            {
                if (jezici[i].Naziv == naziv)
                {
                    jezici.Remove(jezici[i]);
                }
            }
        }


        public static void DodajJezik()
        {
            Console.WriteLine("Naziv jezika");
            string naziv = Console.ReadLine();
            Console.WriteLine("Oznaka jezika");
            string oznaka = Console.ReadLine();
            jezici.Add(new Jezik(naziv,oznaka));
       
        }


        public static void PrikaziJezike()
  {
      int t = 0;
      foreach (Jezik j in jezici)
      {


          Console.WriteLine("RB. jezika:  "+ t++);
          
          Console.WriteLine(j);
          Console.WriteLine("------------------");
      }

  }


  public static void UcitajJezike()
  {

        string path = @"..\..\jezici.txt";
            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {

                    string[] tokeni = line.Split('|');
                    if (tokeni.Length != 2)
                    {
                        throw new TokenException("Nedovoljan broj tokena");

                    }
                    else
                    {

                        jezici.Add(new Jezik(tokeni[0], tokeni[1]));
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


        public static void SacuvajJezike()
        {

            string path = @"..\..\jezici.txt";
            if (!File.Exists(path))
            {
                File.Create(path);

            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Jezik k in jezici)
                {
                    sw.WriteLine(k.Naziv + "|" + k.Oznaka);


                }
            }
        }
    }
}


 