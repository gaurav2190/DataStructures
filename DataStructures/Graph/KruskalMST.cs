namespace DataStructures
{
    using System;
    using System.Collections.Generic;

    public class KruskalMST
    {
        public int FindMin(Subset[] subsets, int i)
        {
            if(subsets[i].parent != i)
            {
                subsets[i].parent = FindMin(subsets, subsets[i].parent);
            }

            return subsets[i].parent;
        }

        public void Union(Subset[] subsets, int x, int y)
        {
            int xRoot = FindMin(subsets, x);
            int yRoot = FindMin(subsets, y);

            if(subsets[xRoot].Rank < subsets[yRoot].Rank)
            {
                subsets[xRoot].parent = yRoot;
                subsets[yRoot].Rank++;
            }
            else
            {
                subsets[yRoot].parent = xRoot;
                subsets[xRoot].Rank++;
            }
        }

        public Edge[] FindMST(Edge[] edges, int v)
        {
            var result = new Edge[v-1];
            int j = 0, i = 0;

            Array.Sort(edges);

            var subSets = new Subset[v];

            for (i = 0; i < v; i++)
            {
                subSets[i] = new Subset();
                subSets[i].parent = i;
                subSets[i].Rank = 0;
            }

            i = 0;
            while(j < v-1)
            {
                var nextEdge = edges[i++];

                int x = FindMin(subSets, nextEdge.Src);
                int y = FindMin(subSets, nextEdge.Dest);

                if(x != y)
                {
                    result[j++] = nextEdge;
                    Union(subSets, x, y);
                }
            }

            return result;
        }
    }

    public class Edge : IComparable<Edge>
    {
        public int Weight { get; set; }
        public int Src { get; set; }
        public int Dest { get; set; }

        public Edge(int wt, int src, int dest)
        {
            this.Weight = wt;
            this.Src = src;
            this.Dest = dest;
        }

        public int CompareTo(Edge other)
        {
            return this.Weight - other.Weight;
        }
    }

    public class Subset
    {
        public int parent { get; set; }
        
        public int Rank { get; set; }
    }
}