using System;

namespace SortingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomIntList l = new RandomIntList(4, 2, 7);
            /*Console.WriteLine("InsertSort");
            l.Next(20, 0, 20);
            l.Print();
            l.InsertionSort();
            l.Print();
            Console.WriteLine("BubbleSort");
            l.Next();
            l.Print();
            l.BubbleSort();
            l.Print();
            Console.WriteLine("QuickSort");
            l.Next(20, 0, 20);
            l.Print();
            l.QuickSort();
            l.Print();
            Console.WriteLine("MergeSort");
            l.Next(20, 0, 20);
            l.Print();
            l.MergeSort();
            l.Print();*/
            l.Next(20, 0, 20);
            l.Print();
            l.MergeSortRec();
            l.Print();
            Console.ReadLine();
        }
    }
}
