using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 10, 2, 4, 8, 22, 11, 6, 1 };
            int searchResult = BinarySearch(array, 1);
            if (searchResult == -1)
            {
                Console.WriteLine("Такого элемента нет в массиве");
            }
            else
            {
                Console.WriteLine("Элемент найден");
            }
            Console.ReadKey();
        }

        static int BinarySearch(int[] inputArray, int searchValue) // O(n*logn) + O(logn) = O(n+1) * O(logn) = O (n log n по основанию 2)
        {
            Array.Sort(inputArray); // O(n * log n)
            int minIndex = 0; // O(1)
            int maxIndex = inputArray.Length - 1; // O(1)
            int x = 0;
            while (minIndex <= maxIndex) // O (log n)
            {
                int midIndex = (minIndex + maxIndex) / 2; // O(1)
                if (searchValue == inputArray[midIndex]) // O(1)
                {
                    return midIndex; // O(1)
                }
                else if (searchValue < inputArray[midIndex]) // O(1)
                {
                    maxIndex = midIndex - 1; // O(1)
                }
                else
                {
                    minIndex = midIndex + 1; // O(1)
                }
                x++;
            }
            return -1; // O(1)

        }

    }
}
