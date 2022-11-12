namespace DataStructures
{
    public class MergeSort
    {
        public void Sort(int[] arr, int start, int end)
        {
            if( start < end )
            {
                int mid = start + (end-start)/2;

                Sort(arr, start, mid);
                Sort(arr, mid+1, end);

                Merge(start, mid, end, arr);
            }
        }

        public void Merge(int start, int mid, int end, int[] arr)
        {
            int n1 = (mid-start)+1;
            int n2 = (end-mid);

            var a1= new int[n1];
            var a2 = new int[n2];
            int i = 0;
            int k = 0;
            for(i= start; i<=mid; i++)
            {
                a1[k++] = arr[i];
            }
            k = 0;
            for(i= mid+1; i<=end; i++)
            {
                a2[k++] = arr[i];
            }

            i = 0;
            int j = 0;
            k = start;
            while(i < n1 && j < n2)
            {
                if(a1[i] > a2[j])
                {
                    arr[k] = a2[j++];
                }
                else
                {
                    arr[k] = a1[i++];
                }
                k++;
            }
            
            while(i < n1)
            {
                arr[k++] = a1[i++];
            }
            
            while(j < n2)
            {
                arr[k++] = a2[j++];            
            }
        }
    }
}