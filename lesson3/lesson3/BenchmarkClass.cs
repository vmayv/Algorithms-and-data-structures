using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace lesson3
{
    public class BenchmarkClass
    {

        /*PointClass[] x = GenerateArrayOfPoints(10000);
        PointStruct<float>[] y = GenerateArrayOfFloatPointsStruct(10000);
        PointStruct<double>[] a = GenerateArrayOfDoublePointsStruct(10000);*/

        IEnumerator<(PointClass, PointClass)> GetPairOfPointsIterator = GetPairOfPoints(GenerateArrayOfPoints(10000));
        IEnumerator<(PointStruct<float>, PointStruct<float>)> GetPairOfFloatPointsStructIterator = GetPairOfFloatPointsStruct(GenerateArrayOfFloatPointsStruct(10000));
        IEnumerator<(PointStruct<double>, PointStruct<double>)> GetPairOfDoublePointsStructIterator = GetPairOfDoublePointsStruct(GenerateArrayOfDoublePointsStruct(10000));

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
        public static PointStruct<float>[] GenerateArrayOfFloatPointsStruct(int size)
        {
            PointStruct<float>[] array = new PointStruct<float>[size];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new PointStruct<float> { X = (float)rnd.NextDouble() * 100, Y = (float)rnd.NextDouble() * 100 };
            }

            return array;
        }
        public static PointStruct<double>[] GenerateArrayOfDoublePointsStruct(int size)
        {
            PointStruct<double>[] array = new PointStruct<double>[size];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new PointStruct<double> { X = rnd.NextDouble() * 100, Y = rnd.NextDouble() * 100 };
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
        public static IEnumerator<(PointStruct<float>, PointStruct<float>)> GetPairOfFloatPointsStruct(PointStruct<float>[] pointStruct)
        {
            for (int i = 0; i < pointStruct.Length; i++)
            {
                if (i == pointStruct.Length - 1)
                {
                    yield break;
                }
                else
                {
                    PointStruct<float> x = pointStruct[i];
                    PointStruct<float> y = pointStruct[i + 1];
                    yield return (x, y);
                }
            }
        }
        public static IEnumerator<(PointStruct<double>, PointStruct<double>)> GetPairOfDoublePointsStruct(PointStruct<double>[] pointStruct)
        {
            for (int i = 0; i < pointStruct.Length; i++)
            {
                if (i == pointStruct.Length - 1)
                {
                    yield break;
                }
                else
                {
                    PointStruct<double> x = pointStruct[i];
                    PointStruct<double> y = pointStruct[i + 1];
                    yield return (x, y);
                }
            }
        }

        public static float PointClassDistance(IEnumerator<(PointClass, PointClass)> iterator)
        {
            iterator.MoveNext();
            (PointClass pointOne, PointClass pointTwo) = iterator.Current;
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static float PointFloatStructDistance(IEnumerator<(PointStruct<float>, PointStruct<float>)> iterator)
        {
            iterator.MoveNext();
            (PointStruct<float> pointOne, PointStruct<float> pointTwo) = iterator.Current;
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static double PointDoubleStructDistance(IEnumerator<(PointStruct<double>, PointStruct<double>)> iterator)
        {
            iterator.MoveNext();
            (PointStruct<double> pointOne, PointStruct<double> pointTwo) = iterator.Current;
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public static float PointFloatStructDistanceNoSqrt(IEnumerator<(PointStruct<float>, PointStruct<float>)> iterator)
        {
            iterator.MoveNext();
            (PointStruct<float> pointOne, PointStruct<float> pointTwo) = iterator.Current;
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        [Benchmark]
        public void PointClassDistanceTest()
        {
            PointClassDistance(GetPairOfPointsIterator);
        }
        [Benchmark]
        public void PointFloatStructDistanceTest()
        {
            PointFloatStructDistance(GetPairOfFloatPointsStructIterator);
        }
        [Benchmark]
        public void PointDoubleStructDistanceTest()
        {
            PointDoubleStructDistance(GetPairOfDoublePointsStructIterator);
        }
        [Benchmark]
        public void PointFloatStructDistanceNoSqrtTest()
        {
            PointFloatStructDistanceNoSqrt(GetPairOfFloatPointsStructIterator);
        }
    }
}
