namespace DataStructures
{
    public class Queue1
    {
        private int[] Elements;
        private int Front = -1;
        private int Back = -1;

        public Queue1(int size)
        {
            this.Elements = new int[size];
        }
        public void Enqueue(int num) {
            if(isFull())
            {
                var temp = this.Elements;
                this.Elements = new int[this.Elements.Length*2];

                for(int i = 0; i < temp.Length; i++)
                {
                    this.Elements[i] = temp[i];
                }
            }
            
            if(Front == -1)
                Front = 0;
            this.Elements[++Back] = num;
        }
        public int Dequeue() {
            var value = this.Elements[Front];
            Front++;
            return value;
        }
        public int Peek() {
            if(Front != -1)
                return this.Elements[Front];
            
            return -1;
        }
        public bool isEmpty() {
            return Back == -1 || Front > Back;
        }
        public bool isFull() {
            return (Back+1)== this.Elements.Length;
        }
    }
}