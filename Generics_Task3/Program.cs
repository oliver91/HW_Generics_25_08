using System;

namespace Generics_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> myList = new MyList<int>();
            for (int i = 1; i < 7; i++)
            {
                myList.Add(i);
            }

            int[] array = ExtentionMethods.GetArray(myList);
            foreach (int el in array)
                Console.Write(el + " ");

            Console.ReadKey();
        }
    }

    internal static class ExtentionMethods
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            T[] arr = new T[list.ElementsCount];
            for (int i = 0; i < list.ElementsCount; i++)
            {
                arr[i] = list[i];
            }
            return arr;
        }
    }

    class MyList<T>
    {
        private T[] array = new T[5];
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
                array = new T[array.Length + 5];
                tmp.CopyTo(array, 0);
            }
            array[lastIndex] = el;
            lastIndex++;
        }
    }
}
