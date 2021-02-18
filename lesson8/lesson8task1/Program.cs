using System;
using System.Collections.Generic;

namespace lesson8task1
{
    class Program
    {
        static void Main(string[] args)
        {

            var arrayLength = 50;
            var range = 100;
            var bucketsCount = 5;
            var array = new int[arrayLength];
            var random = new Random();
            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = random.Next(0, range);
            }

            List<int>[] buckets = new List<int>[bucketsCount];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }

            foreach (var item in array)
            {
                var bucketIndex = (int)MathF.Floor(item / (range / bucketsCount));
                buckets[bucketIndex].Add(item);
            }

            foreach (var bucket in buckets)
            {
                bucket.Sort();
            }

            var result = new int[arrayLength];
            int idx = 0;
            for (int i = 0; i < bucketsCount; i++)
            {
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    Console.Write($"{buckets[i][j]} ");
                    result[idx++] = buckets[i][j];
                }
            }
            /*
            Console.WriteLine();
            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();*/
        }

    }
}
