using System;
using System.Collections.Generic;

namespace Opgave_5._1._2
{
    class Program
    {

        /// <Opgave>
        /// <5.1.2> true
        /// Implementér et program der kan sortere en mængde tal ved hjælp af udvælgelsessortering.
        /// 
        /// <5.1.5> true
        /// Implementér et program der kan sortere en mængde tal ved hjælp af indsættelsessortering.
        /// 
        /// <5.1.7> true
        /// Implementér et program der kan sortere en mængde tal ved hjælp af bubble sort metoden.
        /// 
        /// <5.1.8>
        /// Gør dine sorteringsmetoder generiske, dvs. 
        /// man skal kunne sortere arrays (eller lister) af alle sorterbare typer (dem der implementerer IComparable).
        /// </Opgave>
        static int[] ArrayElements = { 12, 6, 14, 9, 2, 21, 15, 4, 20, 8, 13, 5, 17, 10, 11, 7, 18, 1, 16, 3, 19 };
        static List<int> ListElemnts = new List<int> { 1,5,72,6,61,0,7,4,1,6,2,6,7,1,7,1 };
        static void Main(string[] args)
        {
            #region the list

            foreach (int e in ArrayElements)
            {
                Console.Write(e + " ");
            }
            Console.WriteLine(
                "how do you want to sort you Array" +
                "\n(1) SelectSort" +
                "\n(2) InsertionSort" +
                "\n(3) BubbleSort");
            int UserChois = int.Parse(Console.ReadLine());

            switch (UserChois)
            {
                case 1:
                    SelectSort(ArrayElements);
                    break;

                case 2:
                    InsertionSort(ArrayElements);
                    break;

                case 3:
                    BubbleSort(ArrayElements);
                    break;

            }


            Console.WriteLine();
            foreach (int e in ArrayElements)
            {
                Console.Write(e + " ");
            }
            #endregion
        }

        //Sort Array
        #region
        public static void SelectSort(int[] values)
        {
            for (int sorted = 0; sorted < values.Length; sorted++) // hvilken plads er vi nået til 
            {
                int kandidat = sorted;
                for (int i = sorted; i < values.Length; i++)
                {
                    if (values[i] < values[kandidat]) // hvis det tal den er nåt til er mindre end den nuværende kandidat bliver det den nye kandidat (til at være mindst) 
                        kandidat = i;
                }

                //swap
                Swap(sorted, kandidat, values);
            }
        }

        public static void InsertionSort(int[] values)
        {
            for (int sorted = 1; sorted < values.Length; sorted++) // hvilken plads er vi nået til 
            {
                int kandidat = values[sorted];
                bool flag = false;
                for (int i = sorted - 1; i >= 0 && flag == false;)
                {
                    if (kandidat < values[i])
                    {
                        values[i + 1] = values[i];
                        i--;
                        values[i + 1] = kandidat;
                    }
                    else flag = true;
                }
                /*Console.WriteLine();
                foreach (int e in Elements) 
                { 
                    Console.Write(e + " "); 
                }*/
            }
        }

        public static void BubbleSort(int[] values)
        {
            int n = values.Length;
            for (int sorted = 0; sorted < n - 1; sorted++)
            {
                for (int i = 0; i < n - sorted - 1 /*&& flag == false*/; i++)
                {
                    if (values[i + 1] < values[i])
                    {
                        Swap(i + 1, i, values);
                    }
                }
                /*Console.WriteLine(); 
                foreach (int e in Elements) 
                { 
                    Console.Write(e + " "); 
                }*/
            }
        }

        // swap method
        static void Swap(int a, int b, int[] values)
        {
            int temp = values[b];
            values[b] = values[a];
            values[a] = temp;
        }
        #endregion

    }
}
