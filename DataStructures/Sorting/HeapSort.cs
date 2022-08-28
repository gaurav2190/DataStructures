namespace DataStructures
{
    public class HeapSort
    {
        public int[] SortArray(int[] nums) {
            for(int i = nums.Length/2-1; i>=0; i--)
            {
                MaxHeapify(nums, nums.Length, i);
            }
            
            for(int i = nums.Length-1; i > 0; i--)
            {
                var temp = nums[i];
                nums[i] = nums[0];
                nums[0] = temp;
                
                MaxHeapify(nums, i, 0);
            }
            
            return nums;
        }
        
        public void MaxHeapify(int[] nums, int heapSize, int index)
        {
            int left = 2*index+1;
            int right = 2*index+2;
            int largest = index;
            
            if(left < heapSize && nums[left] > nums[index])
                largest = left;
            if(right < heapSize && nums[right] > nums[largest])
                largest = right;
            
            if(largest != index)
            {
                var temp = nums[largest];
                nums[largest] = nums[index];
                nums[index] = temp;
                MaxHeapify(nums, heapSize, largest);
            }        
        }
    }
}