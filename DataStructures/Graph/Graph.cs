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
    }
}