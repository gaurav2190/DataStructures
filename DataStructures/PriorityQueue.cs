namespace DataStructures{

    using System;
    using System.Collections.Generic;

    public class Number: IComparable<Number>
    {
        public int NumberValue { get; set; }
        public int Priority { get; set; }
        public Number(int numberValue,
                            int priority)
        {
            this.NumberValue = numberValue;
            this.Priority = priority;
        }

        public int CompareTo(Number other)
        {
            if(this.Priority > other.Priority)
                return 1;
            
            if(this.Priority < other.Priority)
                return -1;

            return 0;
        }
    }

    public class NumberPair : IComparable<NumberPair>
    {
        public string Pair { get; set; }

        public int Value { get; set; }
        public NumberPair(string pair, int value)
        {
            this.Pair = pair;
            this.Value = value;
        }
        public int CompareTo(NumberPair other)
        {
            if(this.Value > other.Value)
                return 1;
            if(this.Value < other.Value)
                return -1;
            return 0;
        }
    }
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data;
        
        public PriorityQueue()
        {
            this.data = new List<T>();
        }

        public void Insert(T item)
        {
            data.Add(item);
            var cIndex = data.Count - 1;

            while(cIndex > 0)
            {
                var pIndex = (cIndex - 1) / 2;
                if(data[cIndex].CompareTo(data[pIndex]) <= 0)
                    break;
                Swap(cIndex, pIndex);
                cIndex = pIndex;
            }    
        }

        public T DeQueue()
        {
            var li = data.Count - 1;
            var firstItem = data[0];
            if(li > 0)
            {
                data[0] = data[li];
                data.RemoveAt(li);
                li--;

                var index = 0;
                
                ShiftDown(index);
            }
            else
            {
                data.RemoveAt(li);            
            }

            return firstItem;
        }

        public void ShiftDown(int i)
        {
            int maxIndex = i;
            var lc = 2*i + 1;

            if(lc < data.Count && data[i].CompareTo(data[lc]) < 0)
                maxIndex = lc;
        
            var rc = 2*i + 2;
            if(rc < data.Count && data[maxIndex].CompareTo(data[rc]) < 0)
                maxIndex = rc;
            
            if(i != maxIndex)
            {
                Swap(i, maxIndex);
                ShiftDown(maxIndex);
            }                        
        }

        public void Swap(int i, int j)
        {
            var temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }

    public class MinPriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data;
        
        public MinPriorityQueue()
        {
            this.data = new List<T>();
        }

        public void Insert(T item)
        {
            data.Add(item);
            var cIndex = data.Count - 1;

            while(cIndex > 0)
            {
                var pIndex = (cIndex - 1) / 2;
                if(data[cIndex].CompareTo(data[pIndex]) >= 0)
                    break;
                Swap(cIndex, pIndex);
                cIndex = pIndex;
            }    
        }

        public int GetCount()
        {
            return data.Count;
        }
        public T DeQueue()
        {
            var li = data.Count - 1;
            var firstItem = data[0];
            if(li > 0)
            {
                data[0] = data[li];
                data.RemoveAt(li);
                li--;

                var index = 0;
                
                ShiftDown(index);
            }
            else
            {
                data.RemoveAt(0);
            }            

            return firstItem;
        }

        public void ShiftDown(int i)
        {
            int minIndex = i;
            var lc = 2*i + 1;

            if(lc < data.Count && data[i].CompareTo(data[lc]) > 0)
                minIndex = lc;
        
            var rc = 2*i + 2;
            if(rc < data.Count && data[minIndex].CompareTo(data[rc]) > 0)
                minIndex = rc;
            
            if(i != minIndex)
            {
                Swap(i, minIndex);
                ShiftDown(minIndex);
            }                        
        }

        public void Swap(int i, int j)
        {
            var temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }
}