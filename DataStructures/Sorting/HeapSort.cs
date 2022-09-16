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
    
        public int FindKthLargest(int[] nums, int k) {
            for(int i = nums.Length/2 - 1; i>=0; i--)
            {
                Heapify(nums, i, nums.Length);
            }
            
            for(int i = nums.Length-1; i >0; i--)
            {
                var temp = nums[0];
                nums[0] = nums[i];
                nums[i] = temp;
                Heapify(nums, 0, i);
            }
            
            return nums[k-1];
        }
        
        public void Heapify(int[] nums, int index, int size)
        {
            var largest = index;
            
            var left = 2*index+1;
            var right = 2*index+2;
            
            if(left < size && nums[left] > nums[index])
            {
                largest = left;
            }
            
            if(right < size && nums[right] > nums[largest])
            {
                largest = right;
            }
            
            if(index != largest)
            {
                var temp = nums[index];
                nums[index] = nums[largest];
                nums[largest] = temp;
                Heapify(nums, largest, size);
            }        
        }
    }
}