using System;

namespace ArraySorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 81, 23, -1, 7, 50, 6, 9 };

           // BubbleSort(arr);
           // SelectionSort(arr);
           // MergeSort(arr);
            printArray(arr);
        }

        static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j]) { int temp = arr[i];   arr[i] = arr[j];    arr[j] = temp; }
                }
            }
        }

        static void SelectionSort(int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length-1; i++)
            {
                int smallest = i;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[smallest] > arr[j]) { smallest = j; }
                }
                temp = arr[i];
                arr[i] = arr[smallest];
                arr[smallest] = temp;
            }
        }
        /*
         * Merge Sort is a Divide and Conquer algorithm. It divides input array in 2 halves, calls itself for the 2 halves
         * and then merges the 2 sorted halves.
         * 2 Functions are involved in this algorithm: 
         *      1. merge() -- merging 2 halves;
         *      2. mergesort() -- recursively divide the array till size becomes 1.
         */
        static void MergeSort(int[] arr)
        {
            int[] tmp = new int[arr.Length];
            mergeSortHelper(arr, 0, arr.Length - 1, tmp);
        }

        static void mergeSortHelper(int[] arr, int start, int last, int[] tmp)
        {
            if (start < last)
            {
                int mid = (start+last) / 2;
                mergeSortHelper(arr, start, mid, tmp);
                mergeSortHelper(arr, mid + 1, last, tmp);
                Merge(arr, start, mid, last, tmp);
            }
        }

        static void Merge(int[] arr, int first, int mid, int last, int[] tmp)
        {
            int i = first, j = mid + 1, idx = first;

            while (i <= mid && j <= last)
            {
                if (arr[i] < arr[j])    { tmp[idx] = arr[i];  i++;  idx++; }
                else                    { tmp[idx] = arr[j];   idx++;  j++; }
            }

            // Copy leftovers
            while (i <= mid)    { tmp[idx] = arr[i]; i++; idx++; }
            while (j <= last)   { tmp[idx] = arr[j]; idx++; j++; }

            for (int m = first; m <= last; m++)
            {
                arr[m] = tmp[m];
            }
        }

        static void printArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }
    }
}
