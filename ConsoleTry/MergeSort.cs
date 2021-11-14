using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTry
{
    public class MergeSort
    {
        public int[] Array { get; set; }

        public MergeSort(int[] array)
        {
            Array = array;
        }

        public void PerformMergeSort()
        {
            PerformMergeSort(Array, 0, Array.Length-1);
            foreach (var i in Array)
            {
                Console.Write($"{i} ");
            }
        }

        public void PerformMergeSort(int[] array, int beg, int end)
        {
            if(beg >= end)
                return;
            //Find middle
            int m = (beg + end )/ 2;
            PerformMergeSort(array, beg , m);
            PerformMergeSort(array, m+1, end);
            PerformMerge(array, beg, m , end);
        }

        private void PerformMerge(int[] array, int beg, int mid, int end)
        {
            int i = 0;
            int j = 0;
            int k = beg;

            int n1 = mid - beg + 1;
            int n2 = end - mid;
            int[] Left = new int[n1];
            int[] Right = new int[n2];

            //Load 2 arrays
            for (i = 0; i < n1; i++)
                Left[i] = array[beg + i];
            for (j = 0; j < n2; j++)
                Right[j] = array[mid + 1 + j];

            i = 0;
            j = 0; 
            k = beg;

            while (i < n1 && j < n2)
            {
                if (Left[i] <= Right[j])
                {
                    array[k] = Left[i];
                    i++;
                }
                else
                {
                    array[k] = Right[j];
                    j++;
                }

                k++;
            }
            //Load Remaining array
            while (i < n1)
            {
                array[k] = Left[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                array[k] = Right[j];
                j++;
                k++;
            }

        }
    }
}
