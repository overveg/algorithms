using System;

namespace Lesson1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Реализуйте функцию вычисления числа Фибоначчи*/
            do
            {
                Console.WriteLine("Найти число Фибоначчи номер:");
                string getNumber = Console.ReadLine();
                bool success = Int32.TryParse(getNumber, out int number);
                if (success)
                {
                    Console.WriteLine(GetFibRecursive(number));
                    Console.WriteLine(GetFibIterative(number));
                }
                Console.WriteLine();
            }
            while (true);

        }
        static int GetFibRecursive(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            return n < 0 ? GetFibRecursive(n + 2) - GetFibRecursive(n + 1) : GetFibRecursive(n - 2) + GetFibRecursive(n - 1);
        }

        static int GetFibIterative(int n)
        {
            if (n < 0)
            {
                return 0;
            }
            int a = 0;
            int b = 1;
            int tmp;

            for (int i = 0; i < n; i++)
            {
                tmp = a;
                a = b;
                b += tmp;
            }

            return a;           

        }
    }
}
