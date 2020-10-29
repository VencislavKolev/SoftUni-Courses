using System;

namespace Custom_Doubly_Linked_List
{
    class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>();

            for (int i = 1; i <= 10; i++)
            {
                doublyLinkedList.AddFirst("Pesho" + i);
            }
            for (int i = 1; i <= 10; i++)
            {
                doublyLinkedList.AddLast("Gosho" + i);
            }

            doublyLinkedList.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();

            for (int i = 1; i <= 10; i++)
            {
                doublyLinkedList.RemoveFirst();
            }
            doublyLinkedList.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();
            string[] arr = doublyLinkedList.ToArray();
        }
    }
}
