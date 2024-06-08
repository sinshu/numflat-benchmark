using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using NumFlat;

namespace NumFlatBenchmark
{
    static class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Test>();
        }
    }

    [MemoryDiagnoser]
    public class Test
    {
        static int[] array = Enumerable.Range(0, 10000).Select(i => i).ToArray();
        static Vec<int> vec = Enumerable.Range(0, 10000).Select(i => i).ToVector();

        [Benchmark]
        public int ArrayForLoopSum()
        {
            var sum = 0;
            for (var i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        [Benchmark]
        public int ArrayIEnumerableForeachSum()
        {
            var sum = 0;
            foreach (var value in (IEnumerable<int>)array)
            {
                sum += value;
            }
            return sum;
        }

        [Benchmark]
        public int ArrayLinqSum()
        {
            return array.Sum();
        }

        [Benchmark]
        public int VectorForLoopSum()
        {
            var sum = 0;
            for (var i = 0; i < vec.Count; i++)
            {
                sum += vec[i];
            }
            return sum;
        }

        [Benchmark]
        public int VectorForeachSum()
        {
            var sum = 0;
            foreach (var value in vec)
            {
                sum += value;
            }
            return sum;
        }

        [Benchmark]
        public int VectorUnsafeForLoopSum()
        {
            var sum = 0;
            var ufi = vec.GetUnsafeFastIndexer();
            for (var i = 0; i < vec.Count; i++)
            {
                sum += ufi[i];
            }
            return sum;
        }

        [Benchmark]
        public int VectorLinqSum()
        {
            return vec.Sum();
        }
    }
}
