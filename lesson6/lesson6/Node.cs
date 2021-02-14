using System.Collections.Generic;

namespace lesson6
{
    public class Node<T>
    {
        public T Data { get; set; }
        public List<Edge> Edges { get; }

        public Node()
        {
            Edges = new List<Edge>();
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }
}
