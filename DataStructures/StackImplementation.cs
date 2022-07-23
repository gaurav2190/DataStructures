namespace DataStructures
{
    using System.Collections.Generic;
    
    public class StackImplementation
    {
        public List<int> Elements { get; set; }

        public StackImplementation()
        {
            Elements = new List<int>();
        }

        public bool IsEmpty()
        {
            return Elements.Count == 0;
        }

        public void Push(int data)
        {
            Elements.Add(data);
        }

        public int Pop()
        {
            if(IsEmpty())
                return int.MinValue;

            var item = Elements[Elements.Count - 1];
            Elements.RemoveAt(Elements.Count - 1);

            return item;
        }
    }
}