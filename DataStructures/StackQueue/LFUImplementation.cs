using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DataStructures
{
    public class LFUImplementation
    {
        class LFUNode 
        {
            public int Key;
            public int Value;
            public int Frequency;

            public LFUNode(int key, int value)
            {
                Key = key;
                Value = value;
                Frequency = 1;
            }
        }

        Dictionary<int,LFUNode> Cache = new Dictionary<int,LFUNode>();
        Dictionary<int, LinkedList<LFUNode>> frequencyMap = new Dictionary<int, LinkedList<LFUNode>>();

        public int Capacity;

        public int minFrequency = 0;

         public LFUImplementation(int capacity) {
            Capacity = capacity;
        }

        public void Put(int key, int value) 
        {
            if(this.Cache.ContainsKey(key))
            {
                this.Cache[key].Value = value;
                this.Promote(Cache[key]);
            }
            else
            {
                if(this.Cache.Count == this.Capacity)
                {
                    this.Evict();                    
                }
                
                var nodeNew = new LFUNode(key, value);
                Cache.Add(key, nodeNew);
                AddToFrequencyMap(nodeNew);
                minFrequency = 1;
            }            
        }

        public int Get(int key)
        {
            if(!Cache.ContainsKey(key))
                return -1;
            
            var node = Cache[key];
            this.Promote(node);
            return node.Value;
        }
        
        void Promote(LFUNode node)
        {
            var list = this.frequencyMap[node.Frequency];

            list.Remove(node);

            if(list.Count == 0 && node.Frequency == minFrequency)
                minFrequency++;
            
            node.Frequency++;
            AddToFrequencyMap(node);
        }

        void AddToFrequencyMap(LFUNode node)
        {
            if(!this.frequencyMap.ContainsKey(node.Frequency))
            {
                this.frequencyMap.Add(node.Frequency, new LinkedList<LFUNode>());
            }

            this.frequencyMap[node.Frequency].AddLast(node);
        }

        void Evict()
        {
            var list = this.frequencyMap[minFrequency];
            var node = list.First.Value;
            list.RemoveFirst();
            Cache.Remove(node.Key);
        }
    }
}