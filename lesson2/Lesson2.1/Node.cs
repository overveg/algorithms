using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2._1
{
    public class Node : ILinkedList
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        public int Count { get; set; }
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public Node()
        {
        }
        public Node(int value)
        {
            Value = value;
        }

        public void AddNode(int value)
        {
            Node node = new Node(value);

            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.NextNode = node;
                node.PrevNode = Tail;
            }
            Tail = node;
            Count++;
        }


        public void AddNodeAfter(Node node, int value)
        {
            if (node == null)
            {
                Console.WriteLine("node не может быть null");
                return;
            }
            if (node == Tail)
            {
                AddNode(value);
            }
            else
            {
                Node new_node = new Node()
                {
                    Value = value,
                    NextNode = node.NextNode,
                    PrevNode = node.NextNode.PrevNode
                };
                node.NextNode = new_node;
                if (new_node.NextNode != null)
                {
                    node.NextNode.PrevNode = new_node;
                }
            }
            Count++;
        }

        public Node FindNode(int searchValue)
        {
            Node node = Head;
            while (node != null)
            {
                if (node.Value == searchValue)
                {
                    return node;
                }
                node = node.NextNode;
            }
            return null;
        }

        public int GetCount()
        {
            return Count;
        }

        public void RemoveNode(int index)
        {
            int i = 1;
            Node node = Head;
            while (node != null)
            {
                if (i == index)
                {
                    RemoveNode(node);
                    return;
                }
                node = node.NextNode;
                i++;
            }
        }

        public void RemoveNode(Node node)
        {
            if (Head == null || node == null)
            {
                return;
            }

            if (Head == node)
            {
                Head = node.NextNode;
            }

            if (node.NextNode != null)
            {
                node.NextNode.PrevNode = node.PrevNode;
            }

            if (node.PrevNode != null)
            {
                node.PrevNode.NextNode = node.NextNode;
            }
            Count--;

            return;
        }
        public void PrintList()
        {
            Node n = Head;
            while (n != null)
            {
                Console.Write(n.Value + " ");
                n = n.NextNode;
            }
        }
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
        void PrintList(); // выводит все элементы на консоль
    }


}
