using System;

namespace ConsoleTry
{
    class Program
    {
        static void Main(string[] args)
        {
            //DecisionTree();
            //MergeSortArray();
            //HeapSortArray();
            //BubbleSortArray();
            //QuickSortArray();
            //BuildGraph();
            Console.ReadLine();
        }

        private static void QuickSortArray()
        {
            int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
            QuickSort.Sort(arr);
            Console.WriteLine("Sorted array");
            BubbleSort.PrintArray(arr);
        }

        private static void BubbleSortArray()
        {
            int[] arr = {64, 34, 25, 12, 22, 11, 90};
            BubbleSort.Sort(arr);
            Console.WriteLine("Sorted array");
            BubbleSort.PrintArray(arr);
        }

        private static void HeapSortArray()
        {
            HeapSort heapSort = new HeapSort(new int[] {5, 4, 3, 8, 9, 2, 1});
            heapSort.Sort();
        }

        private static void MergeSortArray()
        {
            MergeSort mergeSort = new MergeSort(new int[] {5, 4, 3, 8, 9, 2, 1});
            mergeSort.PerformMergeSort();
        }

        private static void DecisionTree()
        {
            DecisionTree dtree = new DecisionTree()
            {
                Id = 1,
                flag = true,
                IsValidated = "f"
            };

            Console.WriteLine(dtree.ValidateDecisionTree());
        }

        private static void BuildGraph()
        {
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };

            Dijkstra t = new Dijkstra();
            t.ShortestPath(graph,0);
        }
    }
}
