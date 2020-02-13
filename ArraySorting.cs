using System;

namespace ArraySorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 81, 23, -1, 7, 50, 6, 9 };

            MergeSort(arr);
            printArray(arr);
        }

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
