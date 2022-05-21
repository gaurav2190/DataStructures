public class MyLinkedList {
    public Node Head { get; set; }

        public Node Tail { get; set; }

        public int Size = 0;
    public MyLinkedList() {
        
    }
    
    /// <summary>
    /// Get element at index
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public int Get(int index) {
        if(index < 0 || index > Size-1)
            {
                return -1;
            }
            
            if(index == Size-1)
            {
                return this.Tail.Data;
            }

            int i = 0;
            var trav = this.Head;

            while(i < index)
            {
                trav = trav.Next;
                i++;
            }

            return trav.Data;
    }
    
    public void AddAtHead(int val) {
        var node = new Node(val, null);
            if(Size == 0)
            {
                this.Head = this.Tail = node;
            }
            else
            {
                node.Next = this.Head;
                this.Head = node;
            }
            Size++;
    }
    
    public void AddAtTail(int val) {
        var node = new Node(val, null);
            if(Size == 0)
            {
                this.Head = this.Tail = node;
            }
            else
            {
                this.Tail.Next = node;
                this.Tail = node;
            }
            Size++;
    }
    
    public void AddAtIndex(int index, int val) {
        if(index < 0 || index > Size)
            {
                return;
            }
            var node = new Node(val, null);
        
            if(index == 0 && Size == 0)
            {
                this.Tail = this.Head = node;
                this.Size++;
                return;
            }
        
            if(index == Size)
            {
                this.Tail.Next = node;
                this.Tail = node;
                this.Size++;
                return;
            }

            if(index == 0)
            {
                node.Next = this.Head;
                this.Head = node;
                this.Size++;
                return;
            }

            int i = 0;
            var trav = this.Head;

            var prev = trav;
            while(i < index)
            {
                prev = trav;
                trav = trav.Next;
                i++;
            }

            node.Next = prev.Next;
            prev.Next = node;
            this.Size++;
    }
    
    public void DeleteAtIndex(int index) {
        if(index < 0 || index > Size-1)
            {
                return;
            }

            if(index == 0)
            {
                this.Head = this.Head.Next;
                if(Size == 1)
                {
                    this.Tail = null;
                }
                this.Size--;
                return;
            }

            int i = 0;
            var trav = this.Head;

            var prev = trav;
            while(i < index)
            {
                prev = trav;
                trav = trav.Next;
                i++;
            }
            if(index == Size - 1)
            {
                prev.Next = null;
                this.Tail = prev;
                this.Size--;
                return;
            }

            prev.Next = trav.Next;
            trav = null;
            this.Size--;
    }
}

public class Node{
        public Node(int data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public int Data { get; set; }

        public Node Next { get; set; }
    }