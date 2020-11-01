using P08.CollectionHierarchy.Models;
using System;

namespace P08.CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection<string> addCollection = new AddCollection<string>();

            AddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();

            MyList<string> myList = new MyList<string>();

            string[] elements = Console.ReadLine().Split();
            int removeOperationsCount = int.Parse(Console.ReadLine());

            int[,] indexes = new int[3, elements.Length];
            for (int col = 0; col < elements.Length; col++)
            {
                string element = elements[col];
                indexes[0, col] = addCollection.AddElement(element);
                indexes[1, col] = addRemoveCollection.AddElement(element);
                indexes[2, col] = myList.AddElement(element);
            }
            string[,] stringRemoveElements = new string[2, removeOperationsCount];
            for (int col = 0; col < removeOperationsCount; col++)
            {
                stringRemoveElements[0, col] = addRemoveCollection.Remove();
                stringRemoveElements[1, col] = myList.Remove();
            }

            PrintIndexes(indexes);
            PrintRemovedElements(stringRemoveElements);

            //foreach (var element in elements)
            //{
            //    Console.Write(addCollection.AddElement(element) + " ");
            //    addRemoveCollection.AddElement(element);
            //}
            //Console.WriteLine();
            //foreach (var element in elements)
            //{
            //    Console.Write(addRemoveCollection.AddElement(element) + " ");
            //}
            //Console.WriteLine();
            //foreach (var element in elements)
            //{
            //    Console.Write(myList.AddElement(element) + " ");
            //}
            //Console.WriteLine();
            //for (int i = 0; i < removeOperationsCount; i++)
            //{
            //    Console.Write(addRemoveCollection.Remove() + " ");
            //}
            //Console.WriteLine();
            //for (int i = 0; i < removeOperationsCount; i++)
            //{
            //    Console.Write(myList.Remove() + " ");
            //}
        }

        private static void PrintRemovedElements(string[,] stringRemoveElements)
        {
            for (int row = 0; row < stringRemoveElements.GetLength(0); row++)
            {
                for (int col = 0; col < stringRemoveElements.GetLength(1); col++)
                {
                    Console.Write(stringRemoveElements[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void PrintIndexes(int[,] indexes)
        {
            for (int row = 0; row < indexes.GetLength(0); row++)
            {
                for (int col = 0; col < indexes.GetLength(1); col++)
                {
                    Console.Write(indexes[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
