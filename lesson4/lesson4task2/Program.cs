using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();
            var array = new int[] { 50, 82, 85, 60, 45, 20, 48 };
            //var array = new int[] { 5, 10, 15, 20, 25 };
            //var array = new int[] { 5, 33, 35, 1, 20, 99, 17, 18, 19, 31, 4 };
            foreach (var item in array)
            {
                tree.Insert(item);
            }

            var dfs = tree.DFS(60);
            Console.WriteLine();
            var bfs = tree.BFS(60);
            Console.ReadKey();
        }
    }
}
