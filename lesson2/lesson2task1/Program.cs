using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2task1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.AddNode(1);
            Console.WriteLine(list.GetCount());
            list.AddNodeAfter(list.firstNode, 3);
            Console.WriteLine(list.GetCount());
            list.AddNode(4);
            list.AddNodeAfter(list.firstNode, 2);
            Console.WriteLine(list.GetCount());
            list.RemoveNode(list.FindNode(2));
            Console.WriteLine(list.GetCount());
            list.RemoveNode(0);
            var Node = list.FindNode(4);//list.RemoveNode(1);
            Console.WriteLine(list.GetCount());
            Console.ReadKey();
        }
    }
}