using System;

namespace Opgave5._4._3.HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 2, 9, 5, 1, 6, 3 };
            HeapSort(arr);
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            // Output: 1 2 3 4 5 6 9
        }

        #region
        /* virker ved at tage det højeste nummmer til toppen og derefter skifte det ned i bunden */
        public static void HeapSort(int[] arr)
        {
            int n = arr.Length;



            // Build heap (rearrange array)
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i);



            // One by one extract an element from heap
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;



                // Call max heapify on the reduced heap
                Heapify(arr, i, 0);
            }
        }

        private static void Heapify(int[] array, int n, int i)
        {
            int largest = i; // Initialize largest as root or the current parent
            int l = 2 * i + 1; // left = 2*i + 1
            int r = 2 * i + 2; // right = 2*i + 2



            // If left child is larger than root
            if (l < n && array[l] > array[largest])
                largest = l;



            // If right child is larger than largest so far
            if (r < n && array[r] > array[largest])
                largest = r;



            // If largest is not root
            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;



                // Recursively heapify the affected sub-tree
                Heapify(array, n, largest);
            }
        }

   /*     private static void Heapify(int[] array, int arrayLeng, int i)
        {
            int Parent = i; // Initialize largest as root or the current parent
            int left = 2 * i + 1; // left = 2*i + 1
            int right = 2 * i + 2; // right = 2*i + 2

            // If left child is larger than root
            if (left < arrayLeng && array[left] > array[Parent])
                Parent = left;
            // If right child is larger than largest so far
            if (right < arrayLeng && array[left] > array[Parent])
                Parent = right;

            if(Parent != i)
            {
                int swap = array[i];
                array[i] = array[Parent];
                array[Parent] = swap;

                // Recursively heapify the affected sub-tree
                Heapify(array, arrayLeng, i);
            }
        }*/
        #endregion
    }
}
