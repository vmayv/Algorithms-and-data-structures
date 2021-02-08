using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
    public class Graph
    {
        private Node<int> firstNode;
        public List<Node<int>> Nodes { get; }

        public Graph()
        {
            Nodes = new List<Node<int>>();
        }

        public Node<int> BFS(int value)
        {
            var queue = new Queue<Node<int>>();

            if (firstNode == null)
            {
                return null;
            }

            queue.Enqueue(firstNode);

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();

                Console.Write($"Current item: {item}");

                if (item.Data == value)
                {
                    Console.WriteLine(" <=== Found!");
                    return item;
                }

                foreach (var node in item.Edges)
                {
                    queue.Enqueue(node.ConnectedNode);

                }

                Console.WriteLine();
            }
            Console.WriteLine($"Item with value {value} not found");

            return null;
        }
    }
}