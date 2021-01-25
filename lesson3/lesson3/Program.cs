using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            /*var a = GenerateArrayOfPoints(100);
            PointClassDistance(a);*/
        }
        /*
        public static PointClass[] GenerateArrayOfPoints(int size)
        {
            PointClass[] array = new PointClass[size];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new PointClass { X = (float)rnd.NextDouble() * 100, Y = (float)rnd.NextDouble() * 100 };
            }

            return array;
        }

        public static IEnumerator<(PointClass, PointClass)> GetPairOfPoints(PointClass[] pointClass)
        {
            for (int i = 0; i < pointClass.Length; i++)
            {
                if (i == pointClass.Length - 1)
                {
                    yield break;
                }
                else
                {
                    PointClass x = pointClass[i];
                    PointClass y = pointClass[i + 1];
                    yield return (x, y);
                }
            }
        }

        public static float PointClassDistance(PointClass[] PointClass)
        {
            var iterator = GetPairOfPoints(PointClass);
            iterator.MoveNext();
            (PointClass pointOne, PointClass pointTwo) = iterator.Current;
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }*/
    }
}