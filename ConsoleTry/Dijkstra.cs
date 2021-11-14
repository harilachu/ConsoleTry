using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTry
{
    public class Dijkstra
    {
        private static int V = 9;

        private int MinDistance(int[] dist, bool[] visitedSet)
        {
            int min = int.MaxValue;
            int min_index = -1;
            for (int i = 0; i < V; i++)
            {
                if (!visitedSet[i] && dist[i] <min )
                {
                    min = dist[i];
                    min_index = i;
                }
            }

            return min_index;
        }

        public void ShortestPath(int[,] graph, int src)
        {
            int[] dist = new int[V];
            bool[] visitedSet = new bool[V];

            for (int v = 0; v < V; v++)
            {
                dist[v] = int.MaxValue;
                visitedSet[v] = false;
            }

            dist[src] = 0;

            for (int count = 0; count < V - 1; count++)
            {
                int u = MinDistance(dist, visitedSet);
                visitedSet[u] = true;
                for (int v = 0; v < V; v++)
                {
                    if (!visitedSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
                }
            }

            printDistance(dist);
        }

        public void printDistance(int[] dist)
        {
            foreach (var i in dist)
            {
                Console.Write(i+" ");
            }
        }
    }
}
