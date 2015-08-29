using System;

namespace Generics_Task1
{
    class Program
    {
        static void Main()
        {
            MyList<int> myList = new MyList<int>();
            for (int i = 1; i < 7; i++)
            {
                myList.Add(i);
            }

            for (int i = 0; i < myList.ElementsCount; i++)
            {
                Console.Write(myList[i] + " ");
            }
            Console.WriteLine("number of elements: " + myList.ElementsCount);

            Console.ReadKey();
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
            if (lastIndex > array.Length-1)
            {
                T[] tmp = new T[array.Length];
                array.CopyTo(tmp, 0);
                array = new T[array.Length+5];
                tmp.CopyTo(array, 0);
            }
            array[lastIndex] = el;
            lastIndex++;
        }
    }
}
