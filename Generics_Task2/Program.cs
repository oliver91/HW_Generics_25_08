using System;

namespace Generics_Task2
{
    class Program
    {
        static void Main()
        {
            MyDictionary<string, int> myDictionary = new MyDictionary<string, int>();
            myDictionary.Add("one", 1);
            myDictionary.Add("two", 2);
            myDictionary.Add("three", 3);

            Console.WriteLine("myDictionary[\"one\"]: " + myDictionary["one"]);
            Console.WriteLine("myDictionary[\"two\"]: " + myDictionary["two"]);
            Console.WriteLine("myDictionary[\"three\"]: " + myDictionary["three"]);

            Console.ReadKey();
        }
    }

    class MyDictionary<TKey, TValue>
    {
        private TKey[] keysArray = null;
        private TValue[] valsArray = null;
        private int counter = 0;

        public int ElementsCount
        {
            get { return counter; }
        }

        public TValue this[TKey key]
        {
            get
            {
                int index = 0;
                for (int i = 0; i < keysArray.Length; i++)
                {
                    if (key.Equals(keysArray[i])) index = i;
                }
                return valsArray[index];
            }
        }

        public void Add(TKey key, TValue val)
        {
            counter++;
            Array.Resize(ref keysArray, counter);
            keysArray[counter - 1] = key;
            Array.Resize(ref valsArray, counter);
            valsArray[counter - 1] = val;
        }
    }
}
