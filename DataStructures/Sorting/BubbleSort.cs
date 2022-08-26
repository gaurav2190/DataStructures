namespace DataStructures
{
    public class BubbleSort
    {
        public void Sort(int[] nums)
        {
            bool hasSwapped = true;

            while(hasSwapped)
            {
                hasSwapped = false;

                for (int i = 0; i < nums.Length-1; i++)
                {
                    if(nums[i] > nums[i+1])
                    {
                        var temp = nums[i];
                        nums[i] = nums[i+1];
                        nums[i+1] = temp;

                        hasSwapped = true;
                    }
                }
            }
        }
    }
}