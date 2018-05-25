using System;
using System.Collections.Generic;
using System.Text;

namespace SortingApp
{
    class RandomIntList
    {
        Random Rnd = new Random();
        private int Count;
        private int Upper;
        private int Lower;
        public List<int> Elements { get; set; }
        public RandomIntList(int size, int lowerLimit, int upperLimit)
        {
            Count = size;
            Upper = upperLimit;
            Lower = lowerLimit;
            Elements = GenerateRndList();
        }
        private List<int> GenerateRndList()
        {
            List<int> newLst = new List<int>(Count);
            for (int i = 0; i < Count; i++)
            {
                newLst.Add(Rnd.Next(Lower, Upper + 1));
            }
            return newLst;
        }
        public void Next()
        {
            Elements = GenerateRndList();
        }
        //overload
        public void Next(int size, int lowerLimit, int upperLimit)
        {
            Count = size;
            Lower = lowerLimit;
            Upper = upperLimit;
            Elements = GenerateRndList();
        }
        public void Print()
        {
            int i = 0;
            Console.Write("[");
            while (i < Count - 1)
            {
                Console.Write(Elements[i] + ",");
                i++;
            }
            if(Count > 0)
            {
                Console.Write(Elements[Count-1]);
            }
            Console.WriteLine("]");
        }

        public List<int> BubbleSort()
        {
            int j = Count;
            bool swapped = true;//für linearen Aufwand wenn sortiert
            while(swapped)
            {
                swapped = false;
                for (int i = 0; i < j-1; i++)
                {
                    if (Elements[i] > Elements[i + 1])
                    {
                        int temp = Elements[i + 1];
                        Elements[i + 1] = Elements[i];
                        Elements[i] = temp;
                        swapped = true;
                    }
                }
                j--;
            }
            return Elements;
        }

        public List<int> InsertionSort()
        {
            for (int j = 1; j < Count; j++)
            {
                int curr = Elements[j];
                int i = j - 1;
                while(i >= 0 && Elements[i] > curr)
                {
                    Elements[i + 1] = Elements[i];
                    i--;
                }
                Elements[i+1] = curr;
                
            }
            return Elements;
        }
        
        public List<int> QuickSort()
        {
            int m = Partition(0, Count-1);
            QuickSort(0, m - 1);
            QuickSort(m + 1, Count-1);
            
            return Elements;
        }

        public List<int> QuickSort(int low, int high)
        {
            if (low < high)
            {
                int m = Partition(low, high);
                QuickSort(low, m - 1);
                QuickSort(m + 1, high);
            }
            return Elements;
        }

        private int Partition(int lowerLimit, int higherLimit)
        {
            Console.Write("***Partition with ");
            int pivot = Elements[lowerLimit];
            Console.WriteLine(pivot);
            int j = lowerLimit;
            for (int i = lowerLimit + 1; i <= higherLimit; i++)
            {
                if(Elements[i] < pivot)
                {
                    Console.WriteLine(Elements[i] + " < pivot");
                    j++;
                    int temp1 = Elements[j];
                    Elements[j] = Elements[i];
                    Elements[i] = temp1;
                }
            }
            int temp2 = Elements[j];
            Elements[j]= pivot;
            Elements[lowerLimit] = temp2;
            Print();
            return j;
        }

        public List<int> MergeSort()
        {
            int batchSize = 2;
            List<int> mergedList = new List<int>();
            while (batchSize < Count)
            {
                Console.WriteLine("Batchsize " + batchSize);
                int i = 0;
                while(i < Count)
                {
                    int end = Math.Min(i + batchSize - 1, Count - 1);
                    mergedList.AddRange(Merge(Elements, i, (i + end+1) / 2, end));
                    i += batchSize;
                }
                batchSize *= 2;
                Elements = mergedList;
                mergedList = new List<int>();
            }
            mergedList.AddRange(Merge(Elements, 0, batchSize/2, Count-1));
            Elements = mergedList;
            return Elements;
        }

        private List<int> Merge(List<int> Lst, int start1, int start2, int end2)
        {
            Console.Write("from " + start1 + " to " + end2 + ": ");
            int end1 = start2 - 1;
            List<int> merged = new List<int>();
            int i = start1;
            int j = start2;
            while (i <= end1 && j <= end2)
            {
                if (Lst[i] > Lst[j])
                {
                    merged.Add(Lst[j]);
                    j++;
                }
                else
                {
                    merged.Add(Lst[i]);
                    i++;
                }
            }
            if (end1 >= i) { merged.AddRange(Lst.GetRange(i, end1-i+1)); }
            if(end2 >= j){merged.AddRange(Lst.GetRange(j, end2-j+1)); }
            Print(merged);
            return merged;
        }

        public void Print(List<int> lst)
        {
            foreach (int num in lst)
            {
                Console.Write(num + ", ");
            }
            Console.WriteLine();
        }

        public List<int> MergeSortRec()
        {
            int m = Count / 2;
            int secondHalf = m;
            if (Count % 2 != 0) { secondHalf++; }
            Elements = MergeRec(MergeSortRec(Elements.GetRange(0, m)), MergeSortRec(Elements.GetRange(m, secondHalf)));
            return Elements;
        }

        public List<int> MergeSortRec(List<int> lst)
        {
            if (lst.Count < 2)
            {
                return lst;
            }
            else
            {
                int m = lst.Count / 2;
                int secondHalf = m;
                if(lst.Count % 2 != 0) { secondHalf++; }
                return MergeRec(MergeSortRec(lst.GetRange(0, m)), MergeSortRec(lst.GetRange(m, secondHalf)));
            }
        }

        private List<int> MergeRec(List<int> low, List<int> high)
        {
            List<int> retLst = new List<int>();
            int j = 0;
            int i = 0;
            while (i < low.Count && j < high.Count)
            {
                if(low[i]> high[j])
                {
                    retLst.Add(high[j]);
                    j++;
                }
                else
                {
                    retLst.Add(low[i]);
                    i++;
                }
            }
            if(j < high.Count) { retLst.AddRange(high.GetRange(j, high.Count - j)); }
            else if (i < low.Count) { retLst.AddRange(low.GetRange(i, low.Count - i)); }
            return retLst;
        }


        public List<int> ShellSort()
        {
            List<int> magic = new List<int>{1391376, 463792, 198768, 86961, 33936, 13776, 4592, 1968, 861, 336, 112, 48, 21, 7, 3, 1};
            for (int i = 0; i < magic.Count; i++)
            {
                int part = magic[i];
                for (int j = part; j < Count; j++)
                {
                    int temp = Elements[j];
                    while (j >= part && Elements[j] < Elements[j - part])
                    {
                        Elements[j] = Elements[j - part];
                        Elements[j - part] = temp;
                        j -= part;
                    }
                }
            }

            return Elements;
        }
    }
}
