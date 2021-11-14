using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTry
{
    public class HeapSort
    {
        public int[] Array { get; set; }

        public HeapSort(int[] array)
        {
            Array = array;
        }

        public void Sort()
        {
            int n = Array.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(Array, n, i);

            // One by one extract an element from heap
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end
                int temp = Array[0];
                Array[0] = Array[i];
                Array[i] = temp;

                // call max heapify on the reduced heap
                Heapify(Array, i, 0);
            }

            foreach (var i in Array)
            {
                Console.Write($"{i} ");
            }
        }

        private void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
                largest = left;
            if (right < n && array[right] > array[largest])
                largest = right;

            if (largest != i)
            {
                int temp = array[largest];
                array[largest] = array[i];
                array[i] = temp;
                Heapify(array, n, largest);
            }
        }
    }
}
