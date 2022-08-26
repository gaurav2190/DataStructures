namespace DataStructures
{
    using System;
    
    public class QuickSort
    {
        public void DoQuickSort(int[] arr)
        {
            QuickSortArray(ref arr, 0, arr.Length-1);

            foreach (var item in arr)       
            {
                Console.WriteLine(item);
            }
        }

        public void QuickSortArray(ref int[] arr, int left, int right)
        {
            if(left < right)
            {
                var i = Partitiion(ref arr, left, right);
                QuickSortArray(ref arr, left, i-1);
                QuickSortArray(ref arr, i, right);
            }
        }

        public int Partitiion(ref int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left-1;
            for(int j = left; j < right; j++)
            {
                if(pivot >= arr[j])
                {
                    i++;
                    Swap(ref arr, i, j);
                }
            }

            Swap(ref arr, i+1, right);

            return i+1;
        }

        public void Swap(ref int[] arr, int l, int r)
        {
            var temp = arr[l];
            arr[l] = arr[r];
            arr[r] = temp;
        }
    }
}