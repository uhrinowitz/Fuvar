using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fuvar
{
    class Program
    {
        static void Main(string[] args)
        {
            //string file = "fuvar.csv";
            string file = "fuvar.csv";
            string[] sorok = File.ReadAllLines(file);
            List <Táblázat> táblázatok = new List<Táblázat>();

            // táblázatok tömb feltöltése
            foreach (string sor in sorok.Skip(1))
            {
                táblázatok.Add(new Táblázat(sor));
            }

            // 3. feladat
            Console.WriteLine($"3. feladat: {táblázatok.Count} fuvar");

            // 4. feladat
            int fuvarSzám = 0;
            double fuvarBevétel = 0;
            foreach (Táblázat táblázat in táblázatok)
            {
                if(táblázat.id == 6185)
                {
                    fuvarSzám++;
                    fuvarBevétel += táblázat.viteldíj;
                }
            }
            Console.WriteLine($"4. feladat: {fuvarSzám} fuvar alatt {fuvarBevétel}$");

            // 5. feladat
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach(Táblázat táblázat in táblázatok)
            {
                if (dictionary.ContainsKey(táblázat.fizetésiMód))
                {
                    dictionary[táblázat.fizetésiMód]++;
                } else
                {
                    dictionary.Add(táblázat.fizetésiMód, 1);
                }
            }

            Console.WriteLine("5. feladat:");
            foreach(KeyValuePair<string, int> kvp in dictionary)
            {
                Console.WriteLine(" \t{0}: {1} fuvar", kvp.Key, kvp.Value);
            }

            // 6. feladat
            double összesKM = 0;
            foreach (Táblázat táblázat in táblázatok)
            {
                double kmToMiles = 1.6;
                összesKM += táblázat.távolság * kmToMiles;
            }

            Console.WriteLine($"6. feladat: {összesKM:N2}");

            // 7. feladat
            int leghosszabbIndex = 0;
            int length = táblázatok.Count;
            for (int i = 0; i < length; i++)
            {
                if(táblázatok[i].időtartam > táblázatok[leghosszabbIndex].időtartam)
                {
                    leghosszabbIndex = i;
                }
            }
            Console.WriteLine($"7. feladat: Leghosszabb fuvar:\n\tFuvar hossza: {táblázatok[leghosszabbIndex].időtartam}\n\tTaxi azonosító: {táblázatok[leghosszabbIndex].id} \n\tMegtett távolság: {táblázatok[leghosszabbIndex].távolság} \n\tViteldíj: {táblázatok[leghosszabbIndex].viteldíj}");

            // 8. feladat
            // hibás adatok meghatározása és mentése a "hibák" listába
            string outFile = "hibák.txt";
            IEnumerable<Táblázat> IEhibák = from táblázat in táblázatok
                                            where táblázat.viteldíj >= 0 && táblázat.időtartam >= 0 && táblázat.távolság <= 0
                                            select táblázat;

            // rendezés indulási dátum szerint
            IEnumerable<Táblázat> rendezettAdatok = IEhibák.OrderBy(c => c.indulás);

            // konvertálás stringgé a kiíráshoz
            IEnumerable<string> kiírRendezettAdatok = from táblázat in rendezettAdatok
                                                      select táblázat.ToString();

            // kiírás
            Console.WriteLine("8. feladat: " + outFile);
            string fejléc = sorok[0] + "\n";
            File.WriteAllText(outFile, fejléc);
            File.AppendAllLines(outFile, kiírRendezettAdatok);
            Console.ReadLine();
        }
    }
}
