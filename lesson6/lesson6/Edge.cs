using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
    public class Edge
    {
        public Node<int> ConnectedNode { get; }

        public Edge(Node<int> connectedNode)
        {
            ConnectedNode = connectedNode;
        }
    }
}
