using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace skolaJezikaConsola3
{
    class TipKursaMenadzer
    {

        public static List<TipKursa> tip = new List<TipKursa>();


        public static void DodajTip()
        {
            Console.WriteLine("Tip Kursa");
            string nivoJezika = Console.ReadLine();
            Console.WriteLine("Oznaka tipa");
            string oznakaNivoa = Console.ReadLine();
            tip.Add(new TipKursa(nivoJezika, oznakaNivoa));
        }

        public static void PrikaziTipove()
        {
            int a = 0;
            foreach (TipKursa tk in tip)
            {

                Console.WriteLine("RB. Nivoa jezika:  " + a++);
               
                Console.WriteLine(tk);
                Console.WriteLine("-------------------------");
            }

        }

        public static void ObrisiTip()
        {
            Console.WriteLine("Unesite ime tip jezika koji brisete: ");
            string naziv = Console.ReadLine();
            for (int i = 0; i < tip.Count; i++)
            {
                if (tip[i].NivoJezika == naziv)
                {
                    tip.Remove(tip[i]);
                }
            }
        }

        public static void UcitajTipove()
        {

            string path = @"..\..\tipovi.txt";
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

                        tip.Add(new TipKursa(tokeni[0], tokeni[1]));
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


        public static void SacuvajTipove()
        {

            string path = @"..\..\tipovi.txt";
            if (!File.Exists(path))
            {
                File.Create(path);

            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (TipKursa k in tip)
                {
                    sw.WriteLine(k.NivoJezika + "|" + k.OznakaNivo);

                }
            }
        }

    }
}
