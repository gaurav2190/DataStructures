using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            var heap = new MedianFinder();
            heap.AddNum(1);
            heap.AddNum(2);
            Console.WriteLine(heap.FindMedian());
            Console.ReadLine();
        }
    }
}
