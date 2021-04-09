using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace skolaJezikaConsola3
{
    class UplataMenadzer
    {
        public static List<Uplata> uplate = new List<Uplata>();
        public static void PrikaziUplate()
        {

            foreach (Uplata k in uplate)
            {
                Console.WriteLine(k);

            }
        }

        public static void uplati()
        {

            Console.WriteLine("uneti Id ucenika");
            int id = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < uplate.Count; i++)
            {
                if (uplate[i].IdUplatnice == id)
                {
                         Console.WriteLine(  "unesi cenu koju uplacujute: ");
                         uplate[i].CenaUplate =Convert.ToInt32(Console.ReadLine());
                }

            }

        }
        public static void UcitajUplate()
        {

            string path = @"..\..\uplate.txt";
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
                        Jezik JezikKursa = KursMenadzer.pronadjiJezik(tokeni[0]);
                        TipKursa nivo = KursMenadzer.pronadjiTip(tokeni[1]);
                        double cena = Convert.ToDouble(tokeni[2]);
                        double cenaUpalte = Convert.ToDouble(tokeni[5]);
                        int idUplatnice = Convert.ToInt32(tokeni[6]);
                        Nastavnik Ime = KursMenadzer.pronadjiNastavnika(tokeni[3]);
                        Ucenik ImeUcenika = KursMenadzer.pronadjiUcenika(tokeni[4]);
                        uplate.Add(new Uplata(JezikKursa,nivo, cena,Ime,ImeUcenika,cenaUpalte,idUplatnice ));
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

        public static void SacuvajUplate()
        {

            string path = @"..\..\uplate.txt";
            if (!File.Exists(path))
            {
                File.Create(path);

            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Uplata k in uplate)
                {
                    sw.WriteLine(k.JezikKursa.Naziv + "|" + k.Nivo.NivoJezika + "|" + k.Cena + "|" + k.Ime.Ime + "|" + k.ImeUcenika.Ime+"|"+k.CenaUplate+"|"+k.IdUplatnice);

                }
            }
        }

    }
}
