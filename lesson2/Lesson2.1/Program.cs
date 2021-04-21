using System;

namespace Lesson2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Node myNode = new Node();
            myNode.AddNode(1);
            myNode.AddNode(2);
            myNode.AddNode(3);
            myNode.AddNode(4);
            myNode.AddNodeAfter(myNode.Head, 5);

            myNode.PrintList();
            Console.WriteLine("");
            Console.WriteLine($"Всего элементов {myNode.GetCount()}");

            myNode.RemoveNode(myNode.FindNode(1));

            myNode.PrintList();
            Console.WriteLine("");
            Console.WriteLine($"Всего элементов {myNode.GetCount()}");

        }
    }
}
