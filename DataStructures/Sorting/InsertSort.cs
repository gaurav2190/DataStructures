namespace DataStructures
{
    public class InsertSort
    {
        public void Sort(int[] nums)
        {
            int current = -1;
            
            for (int i = 1; i < nums.Length; i++)
            {
                current = i;

                while(current > 0 && nums[current-1] > nums[current])
                {
                    var temp = nums[current];
                    nums[current] = nums[current-1];
                    nums[current-1] = temp;
                    current--;
                }
            }
        }
    }
}