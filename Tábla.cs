using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiralynok
{
    class Tábla // 1. feladat
    {
        // Privát mezők: 
        char[,] T; // 2. feladat
        char ÜresCella;  // 2. feladat
        static Random R = new Random();
        int Row;
        int Col;

        public Tábla(char üresCella, int row, int col) // 3. feladat ctor TAB-TAB -> konstruktort hoz létre
        {
            T = new char[row, col]; // 3.a
            ÜresCella = üresCella; // 3.b
            Row = row;
            Col = col;
            for (int sor = 0; sor < T.GetLength(0); sor++) // 3.c
            {
                for (int oszlop = 0; oszlop < T.GetLength(1); oszlop++)
                {
                    T[sor, oszlop] = ÜresCella;
                }
            }
        }

        public void Megjelenít()
        {
            for (int sor = 0; sor < T.GetLength(0); sor++)
            {
                for (int oszlop = 0; oszlop < T.GetLength(1); oszlop++)
                {
                    // Console.Write("{0,-2}", T[sor, oszlop]);
                    Console.Write($"{T[sor, oszlop],-2}");
                }
                Console.WriteLine(); // soremelés a sor kiírása után
            }
        }

        public void Elhelyez(int N) // 5. feladat
        {
            for (int i = 0; i < N; )
            {
                int sor = R.Next(0, Row);
                int oszlop = R.Next(0, Col);
                if (T[sor,oszlop] == ÜresCella)
                {
                    T[sor, oszlop] = 'K';
                    i++;
                }
            }
        }

        public bool ÜresSor(int sor) // 7. feladat
        {
            bool üres = true;
            for (int oszlop = 0; oszlop < T.GetLength(1); oszlop++)
            {
                if (T[sor, oszlop] == 'K')
                {
                    üres = false;
                    break;
                }
            }
            return üres;
        }

        public bool ÜresOszlop(int oszlop) // 7. feladat
        {
            bool üres = true;
            for (int sor = 0; sor < T.GetLength(0); sor++)
            {
                if (T[sor, oszlop] == 'K')
                {
                    üres = false;
                    break;
                }
            }
            return üres;
        }

        public int ÜresSorokSzáma // 8. feladat
        {
            get
            {
                int db = 0;
                for (int sor = 0; sor < T.GetLength(0); sor++)
                {
                    if (ÜresSor(sor)) db++;
                }
                return db;
            }
        }

        public int ÜresOszlopokSzáma // 8. feladat
        {
            get
            {
                int db = 0;
                for (int oszlop = 0; oszlop < T.GetLength(1); oszlop++)
                {
                    if (ÜresOszlop(oszlop)) db++;
                }
                return db;
            }
        }

        public void FájlbaÍr(StreamWriter sw)
        {
            for (int sor = 0; sor < T.GetLength(0); sor++)
            {
                for (int oszlop = 0; oszlop < T.GetLength(1); oszlop++)
                {
                    sw.Write($"{T[sor, oszlop]}");
                }
                sw.WriteLine(); // új sor a fájban
            }
            sw.WriteLine(); // új sor a tábla "után"
        }
    }
}
