namespace DataStructures
{
    public class MyCircularQueue
    {
        private int[] Elements;
        private int Start;
        private int End;
        private int QueueSize;
        
        public MyCircularQueue(int k) {
            QueueSize = k;
            Elements = new int[k];
            for(int i =0; i< QueueSize; i++)
            {
                Elements[i] = int.MinValue;
            }
            Start = 0;
            End = 0;
        }
        
        public bool EnQueue(int value) {
            if(IsFull())
                return false;

            var index = (End+1) % QueueSize;
            
            if(Start == End && Elements[End] == int.MinValue)
            {
                Elements[End] = value;
                return true;
            }

            if(Elements[index] == int.MinValue)
            {
                Elements[index] = value;
                End = index;
                return true;
            }
            
            return false;
        }
        
        public bool DeQueue() {
            if(IsEmpty())
                return false;
            if(Elements[Start] != int.MinValue)
            {
                Elements[Start] = int.MinValue;
                if(Start == End)
                {
                    End = (Start+1) % QueueSize;
                }
                Start = (Start+1) % QueueSize;
                return true;
            }
            
            return false;
        }
        
        public int Front() {
            if(IsEmpty())
                return -1;
            return Elements[Start];
        }
        
        public int Rear() {
            if(IsEmpty())
                return -1;
            return Elements[End];
        }
        
        public bool IsEmpty() {
            if(Start == End && Elements[Start] == int.MinValue)
                return true;
            return false;
        }
        
        public bool IsFull() {
            var index = (End+1) % QueueSize;
            
            if(index == Start && Elements[index]!=int.MinValue)
                return true;
            else
                return false;
        }
    }
}