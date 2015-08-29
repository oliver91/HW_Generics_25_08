using System;

namespace Generics_Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.Add(7);
            list.Add(3);
            list.Add(1);
            list.Add(6);
            Console.WriteLine("Before sorting: ");
            PrintCollection(list);
            list = Sorter.SortList<int>(list);
            Console.WriteLine("after sorting: ");
            PrintCollection(list);

            Console.WriteLine("\n");

            MyList<string> list2 = new MyList<string>();
            list2.Add("h");
            list2.Add("d");
            list2.Add("a");
            list2.Add("c");
            Console.WriteLine("Before sorting: ");
            PrintCollection(list2);
            list2 = Sorter.SortList<string>(list2);
            Console.WriteLine("after sorting: ");
            PrintCollection(list2);

            Console.ReadKey();
        }

        public static void PrintCollection<T>(MyList<T> collection)
        {
            if (collection.ElementsCount != 0)
            {
                for (int i = 0; i < collection.ElementsCount; i++)
                {
                    Console.Write(collection[i] + " ");
                }
                Console.WriteLine("\nNumber of elements: " + collection.ElementsCount);
            }
            else
                Console.WriteLine("the collection is empty!");
        }
    }

    static class Sorter
    {
        public static MyList<T> SortList<T>(MyList<T> collection) where T : IComparable
        {
            MyList<T> resultList = new MyList<T>();

            T[] list = collection.ToArray();
            for (int i = 0; i < list.Length-1; i++)
            {
                int min = i;
                for (int j = i+1; j < list.Length; j++)
                {
                    if (list[j].CompareTo(list[min]) == -1) min = j;
                }
                T tmp = list[i];
                list[i] = list[min];
                list[min] = tmp;
            }
            for (int i = 0; i < list.Length; i++)
            {
                resultList.Add(list[i]);
            }
            return resultList;
        }
    }

    class MyList<T>
    {
        private T[] array = new T[1];
        private int lastIndex = 0;

        public int ElementsCount
        {
            get { return lastIndex; }
        }

        public T this[int index]
        {
            get { return array[index]; }
        }

        public void Add(T el)
        {
            if (lastIndex > array.Length - 1)
            {
                T[] tmp = new T[array.Length];
                array.CopyTo(tmp, 0);
                array = new T[array.Length + 1];
                tmp.CopyTo(array, 0);
            }
            array[lastIndex] = el;
            lastIndex++;
        }

        public T[] ToArray()
        {
            return array;
        }
    }
}
