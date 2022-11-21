using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace StanBudAlpha
{
    internal class Program
    {
        public static int flats;
        public static float[][] readyHomes = new float[(int)flats][];
        public static float[][] widithHomes = new float[(int)flats][];
        public static float[][] lengthHomes = new float[(int)flats][];
        public static float[][] priceHomes = new float[(int)flats][];
        //BARTŁOMIEJ WILMAN K35
        //Funkcja bezpiecznie parsująca int
        static int IntNumber()
        {
            int number;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number) == true && number > 0)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Błędna wartość");
                }
            }
        }
        //Funkcja bezpiecznie parsująca float
        static float FloatNumber()
        {
            float number;
            while (true)
            {
                if (float.TryParse(Console.ReadLine(), out number) == true && number > 0)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Błędna wartość");
                }
            }
        }
        //Funkcja tworząca zmiennoprzecinkową tablicę tablic
        static void FloatTables(ref float[][] tab, int firstIndex, string word)
        {
            tab = new float[(int)firstIndex][];
            for (int i = 0; i < firstIndex; i++)
            {
                Console.WriteLine($"{word} {(i + 1)}");
                float number = FloatNumber();
                tab[i] = new float[(int)number];
                tab[i][0] = number;
            }
        }
        static void CreateBase(ref float[][] firstTable,ref float[][] secondTable,ref float[][] thirdTable,ref float[][] fourthTable)
        {
            Console.WriteLine("Podaj ilość bloków");
            flats = IntNumber();
            Console.WriteLine("LICZBA MIESZKAŃ");
            FloatTables(ref firstTable, flats, "Podaj ilość mieszkań w bloku numer ");

            Console.WriteLine("SZEROKOŚĆ MIESZKAŃ");
            FloatTables(ref secondTable, flats, "Podaj szerokość mieszkań w bloku numer ");

            Console.WriteLine("DŁUGOŚĆ MIESZKAŃ");
            FloatTables(ref thirdTable, flats, "Podaj długość mieszkań w bloku numer ");

            Console.WriteLine("CENA ZA METR KWADRATOWY");
            FloatTables(ref fourthTable, flats, "Podaj cenę za metr kwadratowy w bloku numer");
        }
        //Dokładne szukanie metraż lub cena
        static void ExactSearch(ref float [][] firstTable,ref float[][] secondTable,ref float[][] thirdTable,ref float[][] fourthTable)
        {
            if (firstTable.GetLength(0) > 0)
            {
                string looking = "";
                while (looking != "3")
                {

                    Console.WriteLine("1 - szukaj po metrażu\n2 - szukaj po cenie\n3 - wróć");
                    looking = Console.ReadLine();
                    //Szukanie po metrażu
                    if (looking == "1")
                    {
                        Console.WriteLine("Podaj metraż mieszkania w metrach kwadratowych");
                        float byDimension;
                        int found = 0;
                        byDimension = FloatNumber();
                        for (int j = 0; j < firstTable.GetLength(0); j++)
                        {
                            if (((secondTable[j][0]) * (thirdTable[j][0])) == byDimension)
                            {
                                Console.WriteLine($"W bloku numer {j + 1} jest {readyHomes[j].Length} mieszkań o takim metrażu");
                                found++;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (found == 0)
                        {
                            Console.WriteLine("Brak mieszkań w takim metrażu");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Brak więcej mieszkań o takim metrażu");
                            Console.ReadLine();
                        }
                    }
                    //Szukanie po cenie
                    else if (looking == "2")
                    {
                        float byPrice;
                        int found = 0;
                        Console.WriteLine("Podaj cenę za metr kwadratowy, jaką chcesz zapłacić");
                        byPrice = FloatNumber();
                        for (int i = 0; i < firstTable.GetLength(0); i++)
                        {
                            if (fourthTable[i][0] == byPrice)
                            {
                                Console.WriteLine($"W bloku numer {i + 1} są {readyHomes[i].Length} mieszkania w takiej cenie");
                                found++;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (found == 0)
                        {
                            Console.WriteLine("Brak mieszkań w takiej cenie za metr kwadratowy");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Brak więcej mieszkań w takiej cenie za metr kwadratowy");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Błędna wartość");
                    }
                }
            }
            else
            {
                Console.WriteLine("Brak bazy mieszkań");
            }
        }
        //Przegląd mieszkań
        static void Overview(ref float[][] firstTable, ref float[][] secondTable, ref float[][] thirdTable, ref float[][] fourthTable)
        {
            if (firstTable.Length > 0)
            {
                for (int i = 0; i < firstTable.Length; i++)
                {

                    Console.WriteLine($"W bloku numer {(i + 1)}, jest tyle mieszkań {firstTable[i].Length} o wymiarach {secondTable[i][0]} na {thirdTable[i][0]}, w cenie {fourthTable[i][0]} zł za metr kwadratowy.");

                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Brak bazy mieszkań");
                Console.ReadLine();
            }
        }
        static void Meat()
        {
            
            string menu = "1 - stwórz bazę mieszkań\n2 - przejrzyj mieszkania\n3 - szukaj konkretnego mieszkania\n0 - wyjdź";
            string chose = "";
            //Pętla głownego menu działania
            while (chose != "0")
            {
                Console.WriteLine("StanBud");
                Console.WriteLine(menu);
                Console.WriteLine("Wybieram ");
                chose = Console.ReadLine();
                //Dodanie bazy mieszkań (ilość bloków, mieszkań w blokach, metraż, cena za metr kwadratowy
                if (chose == "1")
                {
                    CreateBase(ref readyHomes, ref widithHomes, ref lengthHomes, ref priceHomes);
                }
                //Przejrzenie dodanej bazy mieszkań
                else if (chose == "2")
                {
                    Overview(ref readyHomes, ref lengthHomes, ref widithHomes, ref priceHomes);
                }
                //Szukanie mieszkania o konkretnych parametrach
                else if (chose == "3")
                {
                    ExactSearch(ref readyHomes, ref lengthHomes, ref widithHomes, ref priceHomes);
                }
            }
        }
        //tablice
        

        static void Main(string[] args)
        {
            Meat();
        }
        }
    }

