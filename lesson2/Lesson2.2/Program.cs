using System;

namespace Lesson2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = { 1, 2, 3, 4, 5, 6};
            Console.WriteLine( BinarySearch(testArray, 1));
        }

        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }



    }
}
