namespace DataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    public class MSTPrim
    {
        private int Vertex;

        public MSTPrim(int v)
        {
            this.Vertex = v;
        }

        public int FindMinKey(int[] key, bool[] mstSet)
        {
            var min = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < this.Vertex; i++)
            {
                if(!mstSet[i] && key[i] < min)
                {
                    min = key[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public int[] FindMST(List<GraphNode>[] graph)
        {
            // the output or parent relationship between the nodes.
            var result = new int[this.Vertex];

            // the array to track which vertices are included and which are not.
            var mstSet = new bool[this.Vertex];

            // to store keys. Keys here mainly refers to weight. But we cannot store wt directly as we don't know
            // corresponding to which node we should store the wt. Hence we initialize with max. As we move forward in
            // the code flow it will start setting the values.
            // Here we take a combination of mstSet and keys to refer to any node.
            var keys = new int[this.Vertex];

            for (int i = 0; i < this.Vertex; i++)
            {
                keys[i] = int.MaxValue;
            }

            // We consider first as root/starting node.
            keys[0] = 0;
            result[0] = -1;

            // first loop is for the number of vertices we have
            int count = 0;
            while(count < this.Vertex)
            {
                // first element of the edge. This is the min key value for not visited nodes.
                int u = this.FindMinKey(keys, mstSet);

                // set it as visited.
                mstSet[u] = true;

                // now iterate over the neighbors of u
                foreach (var item in graph[u])
                {
                    // for neighbors which are not in mst & their weight is less than the keys stored at their index.
                    // Here we are including lowest weight possible in the neighbors of the node u.
                    if(!mstSet[item.Destination] && item.Weight < keys[item.Destination])
                    {
                        result[item.Destination] = u;
                        keys[item.Destination] = item.Weight;
                    }
                }

                count++;
            }

            return result;
        }
    }

    public class GraphNode {
        public GraphNode(int wt, int dest)
        {
            this.Weight = wt;
            this.Destination = dest;
        }
        public int Weight { get; set; }
        public int Destination { get; set; }
    }
}