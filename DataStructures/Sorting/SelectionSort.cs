namespace DataStructures
{
    public class SelectionSort
    {
        /// <summary>
        /// Sort Algo. O(n^2) worst case time complexity. O(1) space
        /// </summary>
        /// <param name="nums"></param>
        public void Sort(int[] nums)
        {
            int min_index;

            for(int i = 0; i < nums.Length; i++)
            {
                min_index = i;

                for (int j = i+1; j < nums.Length; j++)
                {
                    if(nums[j] < nums[min_index])
                    {
                        min_index = j;
                    }
                }

                var temp = nums[min_index];
                nums[min_index] = nums[i];
                nums[i] = temp;
            }
        }
    }
}