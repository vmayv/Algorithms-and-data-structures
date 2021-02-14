using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();

            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddNode(3);
            graph.AddNode(4);
            graph.AddNode(5);
            graph.AddNode(6);


            graph.AddEdge(1, 2);
            graph.AddEdge(1, 5);

            graph.AddEdge(2, 3);
            graph.AddEdge(2, 6);

            graph.AddEdge(3, 6);
            graph.AddEdge(3, 4);

            graph.AddEdge(4, 5);

            graph.AddEdge(5, 6);

            graph.DFS(3);
        }
    }
}
