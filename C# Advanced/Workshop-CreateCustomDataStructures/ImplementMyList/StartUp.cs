using System;

namespace ImplementMyList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            Console.WriteLine(list.Count); //3

            list[0] = 100;
            Console.WriteLine(list[0]); //100

            list.Clear();

            Console.WriteLine(list.Count); //0

            for (int i = 0; i < 400; i++)
            {
                list.Add(i);
            }
            Console.WriteLine(list[300]); //300
            list.Clear();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            Console.WriteLine(list.RemoveAt(2)); //3
            bool one = list.Contains(1); //true
            bool twoOneTwo = list.Contains(212); //false

            list.Swap(0, 2);

            list.Clear();
            for (int i = 1; i <= 5; i++)
            {
                list.Add(i);
            }
            list.Insert(2, 100);

            var newList = new MyList<string>();
            newList.Add("A");
            newList.Add("B");
            newList.Add("C");
            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }
            var removeAllList = new MyList<int>
            {
                1,2,3,4
            };
            var res=removeAllList.RemoveAll(x => x % 2 == 0);
            Console.WriteLine(res);
            foreach (var num in removeAllList)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine( removeAllList.Count);

            var text = "Some Text";
            text = text.ApplyWhiteSpace(5);
            Console.WriteLine(text);
        }
    }
}
