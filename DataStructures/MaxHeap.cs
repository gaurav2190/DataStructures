using System.Collections.Generic;

namespace DataStructures
{
    public class MaxHeap
    {
        private List<int> elements;

        public MaxHeap()
        {
            elements = new List<int>();
        }

        public void Add(int val)
        {
            this.elements.Add(val);
            this.HeapifyUp(this.elements.Count-1);
            // Heapify up.
        }

        public int DeleteNode()
        {
            var val = this.elements[0];

            this.elements[0] = this.elements[this.elements.Count-1];
            this.elements.RemoveAt(this.elements.Count-1);

            // heapify down.
            HeapifyDown(0);
            return val;
        }

        public void HeapifyDown(int index)
        {
            var left = 2*index+1;
            var right = 2*index+2;

            var target = index;

            if(left < this.GetSize() && elements[left] > elements[target])
                target = left;

            if(right < this.GetSize() && elements[right] > elements[target])
                target = right;

            if(index != target)
            {
                Swap(index, target);
                HeapifyDown(target);
            }
        }

        public void HeapifyUp(int index)
        {
            while(index > 0)
            {
                var parent = GetParentIndex(index);

                if(this.elements[index] < this.elements[parent])
                    break;

                Swap(index, parent);
                index = parent;
            }
        }

        public int GetSize() => this.elements.Count;

        public int GetParentIndex(int i) => (i-1)/2;

        public int GetLeftIndex(int i) => 2*i+1;

        public int GetRightIndex(int i) => 2*i+2;

        public void Swap(int i, int j)
        {
            var temp = this.elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }   
    }    
}