namespace DataStructures
{
    public class Stack1
    {
        private int size = 10;
        private int[] Elements;
        private int Top = -1;

        public Stack1(int size)
        {
            this.Elements = new int[size];
        }
        public void push(int num) {
            if(isFull())
            {
                var temp = this.Elements;
                this.Elements = new int[this.Elements.Length*2];

                for(int i = 0; i < temp.Length; i++)
                {
                    this.Elements[i] = temp[i];
                }
            }
            this.Elements[++Top] = num;
        }
        public int pop() {
            var value = this.Elements[Top];
            Top--;
            return value;
        }
        public int top() {
            if(Top != -1)
                return this.Elements[Top];
            
            return -1;
        }
        public bool isEmpty() {
            return this.Top == -1;
        }
        public bool isFull() {
            return (Top+1)== this.Elements.Length;
        }
    }
}