using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов: ");
            int m = Convert.ToInt32(Console.ReadLine());
            int[,] W = new int [n,m];
            int i, j;
            for (j = 0; j < m; j++)
            {
                W[0, j] = 1;
            }     
            for (i = 1; i < n; i++)      
            {                     
                W[i, 0] = 1;        
                for (j = 1; j < m; j++)
                {
                    W[i, j] = W[i, j - 1] + W[i - 1, j];
                } 
            }
            Console.WriteLine($"Количество маршрутов равно {W[i-1,j-1]}");
            Console.ReadKey();
        }
    }
}
