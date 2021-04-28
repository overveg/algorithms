using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace lesson3._1
{
    class Program
    {

        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }

    }

    public class BechmarkClass
    {
        public class PointClass
        {
            public float X;
            public float Y;
        }
        public struct PointStruct
        {
            public float X;
            public float Y;
        }
        public struct PointStructDouble
        {
            public double X;
            public double Y;
        }
        public static float PointDistanceClass(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static float PointDistanceStruct(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static double PointDistanceStructDouble(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public struct FloatIntUnion
        {
            public int i;
            public float f;
        }
        public static float fsrt(float z)
        {
            if (z == 0) return 0;
            FloatIntUnion u;
            u.i = 0;
            u.f = z;
            u.i -= 1 << 23; /* Subtract 2^m. */
            u.i >>= 1; /* Divide by 2. */
            u.i += 1 << 29; /* Add ((b + 1) / 2) * 2^m. */
            return u.f;
        }

        public static float PointDistanceStructNoSqrt(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return fsrt((x * x) + (y * y));
        }

        static Random random = new Random();

        public PointStruct[] GetPointStructArray() {
            PointStruct[] PointStructArray = new PointStruct[10];
            for (int i = 0; i < PointStructArray.Length; i++)
            {
                PointStructArray[i] = new PointStruct { X = random.Next(), Y = random.Next() };

            }
            return PointStructArray;
        }

        public PointClass[] GetPointClassArray()
        {
            PointClass[] PointClassArray = new PointClass[10];
            for (int i = 0; i < PointClassArray.Length; i++)
            {
                PointClassArray[i] = new PointClass { X = random.Next(), Y = random.Next() };

            }
            return PointClassArray;
        }

        public PointStructDouble[] GetPointStructDoubleArray()
        {
            PointStructDouble[] PointStructDoubleArray = new PointStructDouble[10];
            for (int i = 0; i < PointStructDoubleArray.Length; i++)
            {
                PointStructDoubleArray[i] = new PointStructDouble { X = random.NextDouble(), Y = random.NextDouble() };

            }
            return PointStructDoubleArray;
        }

        

        [Benchmark]
        public void TestPointDistanceClassFloat() {
            PointClass[] PointClassArrayA = GetPointClassArray();
            PointClass[] PointClassArrayB = GetPointClassArray();
            for (int i = 0; i < PointClassArrayA.Length; i++)
            {
                PointDistanceClass(PointClassArrayA[i], PointClassArrayB[i]);
            }
        }

        [Benchmark]
        public void TestPointDistanceStructFloat()
        {
            PointStruct[] PointStructArrayA = GetPointStructArray();
            PointStruct[] PointStructArrayB = GetPointStructArray();
            for (int i = 0; i < PointStructArrayA.Length; i++)
            {
                PointDistanceStruct(PointStructArrayA[i], PointStructArrayB[i]);
            }
        }

        [Benchmark]
        public void TestPointDistanceStructDouble()
        {
            PointStructDouble[] PointStructDoubleArrayA = GetPointStructDoubleArray();
            PointStructDouble[] PointStructDoubleArrayB = GetPointStructDoubleArray();
            for (int i = 0; i < PointStructDoubleArrayA.Length; i++)
            {
                PointDistanceStructDouble(PointStructDoubleArrayA[i], PointStructDoubleArrayB[i]);
            }
        }

        [Benchmark]
        public void TestPointDistanceStructNoSqrt()
        {
            PointStruct[] PointStructArrayA = GetPointStructArray();
            PointStruct[] PointStructArrayB = GetPointStructArray();
            for (int i = 0; i < PointStructArrayA.Length; i++)
            {
                PointDistanceStructNoSqrt(PointStructArrayA[i], PointStructArrayB[i]);
            }
        }
    }

}
