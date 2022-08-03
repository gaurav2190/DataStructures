namespace DataStructures
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Min distance of every other vertex from the source vertex;
    /// </summary>
    public class DijkstraMST
    {

        
        public int FindMinDistance(bool[] mstSet, int[] dist)
        {
            /**
            Here we pass mstSet and dist. So we iterate over the dist array and check for min distance
            for the vertices not included in mst. Logic below is pretty simple. return the index.
            **/
            int min = int.MaxValue;
            int min_index = -1;

            for(int i = 0; i < dist.Length; i++)
            {
                if(!mstSet[i] && min > dist[i])
                {
                    min = dist[i];
                    min_index = i;
                }
            }

            return min_index;
        }

        public int[] FindMST(int vertex, int src, List<GraphNode>[] graph)
        {
            /**
            Here we first declare mstSet to store the info of the vertices already in MST
            Dist is array to store the min distance from the src vertex;
            **/
            var mstSet = new bool[vertex];
            var dist = new int[vertex];

            // As usual first initialize the dist array with int.MaxValue.
            for(int i = 0; i < vertex; i++)
            {
                dist[i] = int.MaxValue;
            }

            // because distance of vertex from itself is 0, hence setting it.
            dist[src] = 0;

            // The logic here is quite similar to that of Prims
            // First keep the MST set empty, then check for each vertex and start including it in MSTset one by one.
            // the difference here is that we calculate distance from the src vertex.
            // Not start iterating and do it for v-1 times only as we calculate all this for edges which in case of MST
            // is always v-1
            for(int i = 0; i < vertex-1; i++)
            {
                // First find the min distance vertex from the vertices not part of MST.
                var u = FindMinDistance(mstSet, dist);

                // include the vertex in MST.
                mstSet[u] = true;

                // Now start checking its neighbors, and check the distances.
                // dist[u]+ item.Weight < dist[item.Destination] is crucial as it is calculating distance of neighbor wrt u.
                // if it greater than the calculated one, we set the distance of neighbor with that.
                foreach (var item in graph[u])
                {
                    if(!mstSet[item.Destination] && (dist[u]+ item.Weight < dist[item.Destination]))
                        {
                            dist[item.Destination] = dist[u]+ item.Weight;
                        }
                }
            }

            return dist;
        }

    }
}