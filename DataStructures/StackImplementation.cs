namespace DataStructures
{
    public class StackImplementation
    {
        public class StackNode
        {
            public StackNode Next { get; set; }

            public int Data { get; set; }

            public StackNode(int data)
            {
                this.Data = data;
            }
        }

        public StackNode Top { get; set; }

        public void Push(int data)
        {
            var node = new StackNode(data);

            node.Next = Top;
            Top = node;            
        }

        public int Pop()
        {
            var data = Top.Data;
            Top = Top.Next;

            return data;
        }
    }
}