namespace DataStructures
{
    using System.Collections.Generic;

    public class QueueImplementation
    {
        public List<int> Elements { get; set; }

        public int Start { get; set; }

        public QueueImplementation()
        {
            this.Start = 0;
            Elements = new List<int>();
        }

        public void Enqueue(int data)
        {
            this.Elements.Add(data);
        }

        public int DeQueue()
        {
            if(this.IsEmpty())
                return int.MinValue;
            
            return this.Elements[this.Start++];
        }

        public bool IsEmpty()
        {
            return this.Start > this.Elements.Count;
        }
    }
}