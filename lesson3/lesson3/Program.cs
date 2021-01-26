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
        }
    }
}