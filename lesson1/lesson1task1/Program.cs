using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Проверка простое число или нет");
            Console.WriteLine("Введите число: ");
            Console.WriteLine(IsNumberPrime());
            Console.ReadKey();
        }

        static bool IsNumberPrime()
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int d = 0;
            int i = 2;

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                    i++;
                }

                i++;
            }

            if (d == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
