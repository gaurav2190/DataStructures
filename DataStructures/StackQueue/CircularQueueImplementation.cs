namespace DataStructures
{
    using System;

    public class CircularQueueImplementation
    {
        private int QueueSize = 5;

        public CircularQueueImplementation()
        {
            Start = 0;
            End = -1;
            Elements = new int[QueueSize];
            for (int i = 0; i < QueueSize; i++)
            {
                Elements[i] = int.MinValue;
            }
        }

        public int[] Elements;

        public int Start { get; set; }
        
        public int End { get; set; }

        public void Enqueue(int data)
        {
            var index = (End+1) % QueueSize;

            if(Elements[index] == int.MinValue)
            {
                Elements[index] = data;
                End = index;
            }    
            else
            {
                Console.WriteLine("Queue full");
            }
        }

        public int DeQueue()
        {
            var index = Start % QueueSize;
            var value = Elements[index];
            Elements[index] = int.MinValue;
            Start++;
            return value;
        }
    }
}