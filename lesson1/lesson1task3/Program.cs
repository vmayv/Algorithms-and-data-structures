using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите индекс числа Фибоначчи: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Число Фибоначчи с индексом {x} равно {FibonacciRecursion(x)}");
            Console.WriteLine($"Число Фибоначчи с индексом {x} равно {FibonacciNoRecursion(x)}");
            Console.ReadKey();
        }

        static int FibonacciRecursion(int i) // рекурсия
        {
            if (i == 0)
            {
                return 0;
            }
            else if (i == 1)
            {
                return 1;
            }
            else
            {
                return FibonacciRecursion(i - 1) + FibonacciRecursion(i - 2);
            }
        }

        static int FibonacciNoRecursion(int i) // без рекурсии
        {
            int x0 = 0;
            int x1 = 1;

            if (i == 0)
            {
                return x0;
            }

            if (i == 1)
            {
                return x1;
            }

            int x = 0;
            while (x <= i - 2)
            {
                int temp = x0 + x1;
                x0 = x1;
                x1 = temp;
                x++;
            }

            return x1;
        }

    }
}
