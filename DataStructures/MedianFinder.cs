namespace DataStructures
{
    
    using System.Collections.Generic;

    public class MedianFinder {
        private List<int> MinElements { get; set; } = [];
        private List<int> MaxElements { get; set; } = [];
        
        public MedianFinder() {
            
        }
        
        public void AddNum(int num) {
            if(this.MaxElements.Count == 0)
            {
                AddMax(num);
                return;
            }

            if(this.MaxElements[0] < num)
            {
                AddMin(num);
            }
            else
            {
                AddMax(num);
            }
            
            if(this.MaxElements.Count < this.MinElements.Count)
            {
                AddMax(DeleteMin());
            }

            if(this.MaxElements.Count > this.MinElements.Count + 1)
            {
                AddMin(DeleteMax());
            }
        }
        
        private void AddMin(int num){
            this.MinElements.Add(num);
            HeapifyUpMin(this.MinElements.Count-1);
        }

        private void AddMax(int num){
            this.MaxElements.Add(num);
            HeapifyUpMax(this.MaxElements.Count-1);
        }

        private int DeleteMin()
        {
            var item = this.MinElements[0];
            this.MinElements[0] = this.MinElements[this.MinElements.Count-1];
            this.MinElements.RemoveAt(this.MinElements.Count-1);
            HeapifyMinDown(0);

            return item;
        }

        private int DeleteMax()
        {
            var item = this.MaxElements[0];
            this.MaxElements[0] = this.MaxElements[this.MaxElements.Count-1];
            this.MaxElements.RemoveAt(this.MaxElements.Count-1);
            HeapifyMaxDown(0);

            return item;
        }

        public double FindMedian() {
            if((this.MinElements.Count + this.MaxElements.Count)%2==1)
            {
                return this.MaxElements[0];
            }
            else
            {
                return ((float)this.MaxElements[0] + (float)this.MinElements[0])/2;
            }
        }

        public void HeapifyUpMax(int index)
        {
            var parent = -1;
            while(index > 0)
            {
                parent = GetParentIndex(index);
                if(MaxElements[parent] > MaxElements[index])
                    break;
                SwapMax(parent, index);
                index = parent;
            }
        }

        public void HeapifyMaxDown(int index)
        {
            var max = index;
            var left = GetLeftIndex(index);
            var right = GetRightIndex(index);

            if(left < this.MaxElements.Count && this.MaxElements[left] > this.MaxElements[max])
                max = left;
            if(right < this.MaxElements.Count && this.MaxElements[right] > this.MaxElements[max])
                max = right;
            
            if(max != index)
            {
                SwapMax(max, index);
                HeapifyMaxDown(max);
            }
        }

        public void HeapifyUpMin(int index)
        {
            var parent = -1;
            while(index > 0)
            {
                parent = GetParentIndex(index);
                if(MinElements[parent] < MinElements[index])
                    break;
                SwapMin(parent, index);
                index = parent;
            }
        }

        public void HeapifyMinDown(int index)
        {
            var min = index;
            var left = GetLeftIndex(index);
            var right = GetRightIndex(index);

            if(left < this.MinElements.Count && this.MinElements[left] < this.MinElements[min])
                min = left;
            if(right < this.MinElements.Count && this.MinElements[right] < this.MinElements[min])
                min = right;
            
            if(min != index)
            {
                SwapMin(min, index);
                HeapifyMinDown(min);
            }
        }

        private void SwapMax(int index1, int index2)
        {
            var temp = this.MaxElements[index1];
            this.MaxElements[index1] = this.MaxElements[index2];
            this.MaxElements[index2] = temp;
        }

        private void SwapMin(int index1, int index2)
        {
            var temp = this.MinElements[index1];
            this.MinElements[index1] = this.MinElements[index2];
            this.MinElements[index2] = temp;
        }

        private int GetLeftIndex(int index) => 2*index+1;

        private int GetRightIndex(int index) => 2*index+2;

        private int GetParentIndex(int index) => (index-1)/2;
    }
}