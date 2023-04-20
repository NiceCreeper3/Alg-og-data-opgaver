using System;

namespace Opgave_5._1._2
{
    class Program
    {
        static int[] Elements = { 12, 6, 14, 9, 2, 21, 15, 4, 20, 8, 13, 5, 17, 10, 11, 7, 18, 1, 16, 3, 19 };
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region the list
            Console.ReadLine();

            foreach (int e in Elements)
            {
                Console.Write(e + " ");
            }
            SelectSort(Elements);
            Console.WriteLine();
            foreach (int e in Elements)
            {
                Console.Write(e + " ");
            }
            #endregion
        }

        //Sort List
        #region
        public static void SelectSort(int[] values)
        {
            for (int sorted = 0; sorted < values.Length; sorted++) // hvilken plads er vi nået til 
            {
                int kandidat = sorted;
                for (int i = sorted; i < values.Length; i++)
                {
                    if (values[i] < values[kandidat]) // hvis det tal den er net til er mindre end den nuværende kandidat bliver det den nye kandidat (til at være mindst) 
                        kandidat = i;
                }
                // swap: 
                int temp = values[kandidat];
                values[kandidat] = values[sorted];
                values[sorted] = temp;
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

        static void Swap(int a, int b, int[] values)
        {
            int temp = values[b];
            values[b] = values[a];
            values[a] = temp;
        }
        #endregion

    }
}
