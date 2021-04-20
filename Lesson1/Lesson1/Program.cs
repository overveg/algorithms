using System;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Введите целое число:");
                string getNumber = Console.ReadLine();
                bool success = Int32.TryParse(getNumber, out int number);
                if (success)
                {
                    Console.WriteLine(isSimple(number));
                }
                Console.WriteLine();
            } while (true);

        }

        static string isSimple(int n)
        {
            int d = 0;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    d++;
                }
            }
            return d == 0 ? "простое" : "не простое";
        }
    }
}
