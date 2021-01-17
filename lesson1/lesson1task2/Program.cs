using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1task2
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        // ИТОГО: O(1) + O(N) * (O(N) * (O(N) * (O(1) + O(1) + O(1) + O(1)))) + O(1)
        // ИТОГО: O(2) + O(N) * O(N) * O(N) * O(4)
        // ИТОГО: O(2) + O(N * N * N * 4)
        // ИТОГО: O(4N^3) + O(2)
        // ИТОГО: O(N^3) + O(2)
        // ИТОГО: O(N^3)
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; // O(1)
            for (int i = 0; i < inputArray.Length; i++) // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) // O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) // O(N)
                    {
                        int y = 0; // O(1)

                        if (j != 0) // O(1)
                        {
                            y = k / j; // O(1)
                        }

                        sum += inputArray[i] + i + k + j + y; // O(1)
                    }
                }
            }

            return sum; // O(1)
        }


    }
}
