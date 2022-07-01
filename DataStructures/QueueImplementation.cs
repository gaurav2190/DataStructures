namespace DataStructures
{
    public class QueueImplementation
    {
        public class QueueNode {
            public int Data { get; set;}
            public QueueNode Next {get;set;}

            public QueueNode(int data)
            {
                this.Data = data;
            }
        }

        public QueueNode Head { get; set; }

        public QueueNode Tail { get; set; }

        public void Enqueue(int data)
        {
            var node = new QueueNode(data);

            if(Tail != null)
                Tail.Next = node;
            Tail = node;

            if(Head == null)
                Head = node;
        }

        public int DeQueue()
        {
            if(Head == null)
                return int.MaxValue;
            
            var data = Head.Data;
            Head = Head.Next;

            return data;
        }

        public int Peek()
        {
            if(Head == null)
                return int.MaxValue;
            
            return Head.Data;
        }
    }
}