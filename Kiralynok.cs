using System;
using System.IO;

namespace Kiralynok
{
    class Kiralynok
    {
        static void Main(string[] args)
        {
            int r = 7;
            int c = 9;
            Console.WriteLine("4. feladat: Az üres tábla:");
            Tábla tábla = new Tábla('#', r, c);
            tábla.Megjelenít();

            Console.WriteLine("\n6. feladat: A feltöltött tábla:");
            tábla.Elhelyez(8);
            tábla.Megjelenít();

            Console.WriteLine("\n9. feladat: Üres oszlopok és sorok száma");
            Console.WriteLine($"Oszlopok: {tábla.ÜresOszlopokSzáma}");
            Console.WriteLine($"Sorok: {tábla.ÜresSorokSzáma}");

            //10. feladat
            const string fájlNeve = "tablak64.txt";
            Console.WriteLine($"10. feladat: {fájlNeve}");
            if (File.Exists(fájlNeve)) File.Delete(fájlNeve);
            StreamWriter sw = new StreamWriter(fájlNeve);
            for (int i = 1; i < 65; i++) // 1..64
            {
                Tábla aktTábla = new Tábla('*', r, c);
                aktTábla.Elhelyez(i); //1, 2, 3, .., 64 db 'K'-t
                aktTábla.FájlbaÍr(sw);
            }
            sw.Close(); // Stream (file) lezárása
            Console.ReadKey();
        }
    }
}
