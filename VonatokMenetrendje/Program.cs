using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VonatokMenetrendje
{
    internal class Program
    {
        public static List<Vonat> trains = new List<Vonat>();
        static void Main(string[] args)
        {
            StreamReader r = new StreamReader("Vonatok.txt");
            while (!r.EndOfStream)
            {
                string line = r.ReadLine();
                string[] sor = line.Split(';');

                if (sor.Length >= 4)
                {
                    trains.Add(new Vonat(sor[0], DateTime.Parse(sor[1]), DateTime.Parse(sor[2]), sor[3]));
                }
                else
                {
                    Console.WriteLine(line);
                }
            }
            r.Close();

            Kilistaz();
            DateTime keresettIdopont = new DateTime(2024, 09, 17, 10, 00, 00);
            LegkozelebbiVonat(keresettIdopont);

            LeghosszabbUtazas();

            DateTime idopontElott = new DateTime(2024, 09, 17, 10, 00, 00);
            IndulasokIdopontElott(idopontElott);

            Console.Write("Adja meg az útszakasz nevét: ");
            string utszakasz = Console.ReadLine();
            VonatokUtszakaszra(utszakasz);

            Console.ReadKey();
        }

        public static void Kilistaz()
        {
            foreach (Vonat vonat in trains)
            {
                Console.WriteLine(vonat);
            }
        }

        public static void LegkozelebbiVonat(DateTime idopont)
        {
            Vonat legkozelebbi = null;
            TimeSpan legkisebbKulonbseg = TimeSpan.MaxValue;

            foreach (Vonat vonat in trains)
            {
                TimeSpan kulonbseg = vonat.IndulasIdo - idopont;
                if (kulonbseg >= TimeSpan.Zero && kulonbseg < legkisebbKulonbseg)
                {
                    legkozelebbi = vonat;
                    legkisebbKulonbseg = kulonbseg;
                }
            }

            if (legkozelebbi != null)
            {
                Console.WriteLine($"A legközelebbi vonat: {legkozelebbi}");
            }
            else
            {
                Console.WriteLine("Nincs induló vonat a megadott időpont után.");
            }
        }
        public static void LeghosszabbUtazas()
        {
            Vonat leghosszabb = null;
            TimeSpan maxIdotartam = TimeSpan.Zero;

            foreach (Vonat vonat in trains)
            {
                if (vonat.UtazasiIdo > maxIdotartam)
                {
                    leghosszabb = vonat;
                    maxIdotartam = vonat.UtazasiIdo;
                }
            }

            if (leghosszabb != null)
            {
                Console.WriteLine($"A leghosszabb utazás: {leghosszabb.VonatSzam}, időtartam: {maxIdotartam}");
            }
            else
            {
                Console.WriteLine("Nincs utazás az adatok között.");
            }
        }
        public static void IndulasokIdopontElott(DateTime idopont)
        {
            var indulok = trains.Where(v => v.IndulasIdo < idopont).ToList();

            if (indulok.Any())
            {
                Console.WriteLine($"Vonatok, amelyek {idopont} előtt indulnak:");
                foreach (var vonat in indulok)
                {
                    Console.WriteLine(vonat);
                }
            }
            else
            {
                Console.WriteLine("Nincs vonat, amely a megadott időpont előtt indulna.");
            }
        }
        public static void VonatokUtszakaszra(string utszakasz)
        {
            var vonatok = trains.Where(v => v.Utvonal == utszakasz).ToList();

            if (vonatok.Any())
            {
                Console.WriteLine($"Vonatok az {utszakasz} útszakaszra:");
                foreach (var vonat in vonatok)
                {
                    Console.WriteLine(vonat);
                }
            }
            else
            {
                Console.WriteLine("Nincs vonat az adott útszakaszra.");
            }
        }
    }
}
