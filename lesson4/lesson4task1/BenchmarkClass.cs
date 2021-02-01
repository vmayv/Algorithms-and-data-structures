using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4task1
{
    public class BenchmarkClass
    {
        static string[] inputArray = GenerateArrayOfStrings(10000, 15);
        static HashSet<string> inputHashSet = GenerateHashSetOfStrings(10000, 15);
        IEnumerator<string> GetRandomStringFromArrayIterator = GetRandomStringFromArray(inputArray);
        IEnumerator<string> GetRandomStringFromHashSetIterator = GetRandomStringFromHashSet(inputHashSet);

        public static string GenerateRandomString(int length)
        {
            string data = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm0123456789";
            char[] dataArray = data.ToCharArray();
            char[] outputData = new char[length];
            Random rnd = new Random();
            for (int i = 0; i < outputData.Length; i++)
            {
                outputData[i] = dataArray[rnd.Next(0, 61)];
            }
            return new String(outputData);
        }
        public static string[] GenerateArrayOfStrings(int size, int stringLength)
        {
            string[] array = new string[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = GenerateRandomString(stringLength);
            }
            return array;
        }
        public static HashSet<string> GenerateHashSetOfStrings(int size, int stringLength)
        {
            HashSet<string> hashset = new HashSet<string>();
            for (int i = 0; i < size; i++)
            {
                hashset.Add(GenerateRandomString(stringLength));
            }
            return hashset;
        }

        public static IEnumerator<string> GetRandomStringFromArray(string[] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[rnd.Next(0, array.Length - 1)];
            }
        }
        public static IEnumerator<string> GetRandomStringFromHashSet(HashSet<string> hashset)
        {
            Random rnd = new Random();
            var array = new string[hashset.Count];
            hashset.CopyTo(array);
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[rnd.Next(0, array.Length - 1)];
            }
        }

        public static bool SpeedContainsArray(string[] inputArray, IEnumerator<string> iterator)
        {
            iterator.MoveNext();
            string random = iterator.Current;
            return inputArray.Contains(random);
        }
        public static bool SpeedContainsHashSet(HashSet<string> inputHashSet, IEnumerator<string> iterator)
        {
            iterator.MoveNext();
            string random = iterator.Current;
            return inputHashSet.Contains(random);
        }
        
        [Benchmark]
        public void SpeedContainsArrayTest()
        {
            SpeedContainsArray(inputArray, GetRandomStringFromArrayIterator);
        }
        [Benchmark]
        public void SpeedContainsHashSetTest()
        {
            SpeedContainsHashSet(inputHashSet, GetRandomStringFromHashSetIterator);
        }
    }
}
