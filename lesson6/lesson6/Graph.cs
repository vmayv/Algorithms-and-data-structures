using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
    public class Graph
    {
        public List<Node<int>> Nodes { get; }

        public Graph()
        {
            Nodes = new List<Node<int>>();
        }
        public void AddNode(int value)
        {
            Nodes.Add(new Node<int> { Data = value });
        }

        public void AddEdge(int first, int second)
        {
            //foreach (var item in Nodes)
            //{
            //    var predicate = item.Data == first;
            //    if(predicate)
            //    {
            //        firstNode = item;
            //        break;
            //    }
            //}

            var firstNode = Nodes.FirstOrDefault(item => item.Data.Equals(first));
            var secondNode = Nodes.FirstOrDefault(item => item.Data.Equals(second));

            if (firstNode != null && secondNode != null)
            {
                firstNode.Edges.Add(new Edge(secondNode));
                secondNode.Edges.Add(new Edge(firstNode));
            }
        }

        public Node<int> BFS(int value)
        {
            var queue = new Queue<Node<int>>();
            var visitedNodes = new HashSet<Node<int>>();

            if (Nodes.Count == 0)
            {
                return null;
            }

            queue.Enqueue(Nodes[0]);

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                visitedNodes.Add(item);

                Console.Write($"Current item: {item}");

                if (item.Data == value)
                {
                    Console.WriteLine(" <=== Found!");
                    return item;
                }

                foreach (var edge in item.Edges)
                {
                    if (!visitedNodes.Contains(edge.ConnectedNode))
                    {
                        queue.Enqueue(edge.ConnectedNode);
                    }
                    else
                    {
                        Console.Write($"\nSkip {edge.ConnectedNode}");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine($"Item with value {value} not found");

            return null;
        }

        public Node<int> DFS(int value)
        {
            var visitedNodes = new HashSet<Node<int>>();
            var stack = new Stack<Node<int>>();

            if (Nodes.Count == 0)
            {
                return null;
            }

            stack.Push(Nodes[0]);

            while (stack.Count > 0)
            {
                var item = stack.Pop();

                Console.Write($"Current item: {item}");

                if (item.Data == value)
                {
                    Console.WriteLine(" <=== Found!");
                    return item;
                }
                visitedNodes.Add(item);

                foreach (var edge in item.Edges)
                {
                    if (!visitedNodes.Contains(edge.ConnectedNode))
                    {
                        stack.Push(item);
                        stack.Push(edge.ConnectedNode);
                        continue;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Item with value {value} not found");

            return null;
        }
    }
}