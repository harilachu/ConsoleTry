using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTry
{
    public class QuickSort
    {
        public static void Sort(int[] array, int beg, int end)
        {
            if (beg < end)
            {
                int mid = Partition(array, beg, end);
                Sort(array, beg, mid - 1);
                Sort(array, mid + 1, end);
            }
        }

        internal static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length-1);
        }

        private static int Partition(int[] array, int beg, int end)
        {
            int pivot = array[end];
            int i = beg - 1;
            int n = array.Length - 1;
            for (int j = beg; j <= n; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    swap(array, i, j);
                }
            }
            swap(array, i+1, end);
            return i + 1;
        }

        private static void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        // Function to print an array 
        static void printArray(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
                Console.Write(arr[i] + " ");

        }
    }
}
