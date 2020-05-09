using System;

namespace DijkstraShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = {
                    { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                    { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                    { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                    { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                    { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                    { 0, 0, 4, 0, 10, 0, 2, 0, 0 },
                    { 0, 0, 0, 14, 0, 2, 0, 1, 6 },
                    { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                    { 0, 0, 2, 0, 0, 0, 6, 7, 0 }};

            Dijkstra(graph, 0, 9);
        }

        private static void Print(int[] distance, int verticesCount)
        {
            Console.WriteLine("Vertex    Distance from source");
            Console.WriteLine("======    ====================\n");
            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }

        private static int MinDistance(int[] distance, bool[] visited, int verticesCount)
        {
            int min = Int32.MaxValue, minIndex = 0;

            // For the current vertex, examine its unvisited neighbors and calculate distance of each neighbor.
            for (int i = 0; i < verticesCount; i++)
            {
                if (visited[i] == false && distance[i] <= min)
                {
                    min = distance[i];  // Update the minDistance.
                    minIndex = i;
                }
            }
            return minIndex;
        }

        public static void Dijkstra(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] visited = new bool[verticesCount];

            // Let distance of all other vertices from start = infinity.
            for (int i = 0; i < verticesCount; i++)
            {
                distance[i] = Int32.MaxValue;
                visited[i] = false;
            }
            // Let distance of start vertex from start vertex = 0.
            distance[source] = 0;

            // Repeat:
            for (int count = 0; count < verticesCount; ++count)
            {
                // Visit the unvisited vertex with smallest known distance from the start vertex.
                int currentVertex = MinDistance(distance, visited, verticesCount);

                visited[currentVertex] = true;

                for (int i = 0; i < verticesCount; ++i)
                {
                    if (!visited[i] && Convert.ToBoolean(graph[currentVertex, i]) &&
                         distance[currentVertex] != Int32.MaxValue && distance[currentVertex] + graph[currentVertex, i] < distance[i])
                        distance[i] = distance[currentVertex] + graph[currentVertex, i];
                }
            }

            Print(distance, verticesCount);
        }

        /* --------- OUTPUT ----------
        Vertex    Distance from source
        ======    ====================

        0         0
        1         4
        2         12
        3         19
        4         21
        5         11
        6         9
        7         8
        8         14
        Press any key to continue . . .
        */
    }
}