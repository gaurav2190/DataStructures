namespace DataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    public class Graph
    {
        public bool IsCyclic(List<int>[] graph, bool[] visited, Stack<int> stack, int vertex)
        {
            if(stack.Contains(vertex))
                return true;

            if(visited[vertex])
                return false;
            
            stack.Push(vertex);

            foreach (var item in graph[vertex])
            {
                if(IsCyclic(graph, visited, stack, item))
                    return true;
            }

            stack.Pop();
            return false;
        }

        public bool IsCycleBFS(List<int>[] graph, int vertex)
        {
            var visited = new bool[vertex];

            for(int i = 0; i< vertex; i++)
            {
                if(!visited[i] && IsCycleConnection(graph, i, visited, vertex))
                    return true;
            }

            return false;
        }

        private bool IsCycleConnection(List<int>[] graph, int vertex, bool[] visited, int v)
        {
            var queue = new Queue<int>();
            int w = -1;
            queue.Enqueue(vertex);
            var parent = new int[v];

            Array.Fill(parent, -1);

            while(queue.Count > 0)
            {
                var u = queue.Dequeue();
                for (int i = 0; i < graph[u].Count; i++)
                {
                    w = graph[u][i];
                    if(!visited[w])
                    {
                        visited[w] = true;
                        queue.Enqueue(w);
                        parent[w] = u;
                    }
                    else if (parent[u] != w)
                        return true;
                }
            }

            return false;
        }

        public int GetConnectedComponents(List<int>[] graph, int numbeVertex)
        {
            var visited = new bool[numbeVertex];
            var stack = new Stack<int>();

            for (int i = 0; i < numbeVertex; i++)
            {
                if(!visited[i])
                    DFSstack(graph, i, stack, visited);
            }

            var graphRev = new List<int>[numbeVertex];
            
            for (int i = 0; i < numbeVertex; i++)
            {
                graphRev[i] = new List<int>();
            }

            for (int i = 0; i < graphRev.Length; i++)
            {                
                foreach (var item in graph[i])
                {
                    graphRev[item].Add(i);
                }
            }

            int count = 0;
            Array.Fill<bool>(visited, false);

            while(stack.Count > 0)
            {
                var i = stack.Pop();

                if(!visited[i])
                {
                    DFSBasic(graphRev, i, visited);
                    count++;
                }
            }

            return count;
        }

        public void DFSstack(List<int>[] graph, int node, Stack<int> stack, bool[] visited)
        {
            visited[node] = true;

            foreach (var item in graph[node])
            {
                if(!visited[item])
                {
                    DFSstack(graph, item, stack, visited);
                }
            }

            stack.Push(node);
        }

        public void DFSBasic(List<int>[] graph, int node, bool[] visited)
        {
            visited[node] = true;

            foreach (var item in graph[node])
            {
                if(!visited[item])
                {
                    DFSBasic(graph, item, visited);
                }
            }
        }


    }
}