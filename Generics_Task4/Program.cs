using System;
using System.Runtime.InteropServices;

namespace Generics_Task4
{
    class Program
    {
        static void Main()
        {
            CarCollection<Car> VehicleFleet = new CarCollection<Car>();
            VehicleFleet.Add(new Car("Audi A4", 1997));
            VehicleFleet.Add(new Car("Ford Mustang", 1993));
            VehicleFleet.Add(new Car("Seat Leon", 2010));
            PrintCollection(VehicleFleet);

            Console.WriteLine("\nRemoving all elements from the collection");
            VehicleFleet.RemoveAll();
            PrintCollection(VehicleFleet);
            Console.ReadKey();
        }

        public static void PrintCollection(CarCollection<Car> vehicleFleet)
        {
            if (vehicleFleet.ElementsCount != 0)
            {
                for (int i = 0; i < vehicleFleet.ElementsCount; i++)
                {
                    Console.WriteLine("car: {0}, production year: {1}", vehicleFleet[i].CarName,
                        vehicleFleet[i].ProductionYear);
                }
                Console.WriteLine("Number of cars: " + vehicleFleet.ElementsCount);
            }
            else
                Console.WriteLine("the collection is empty!");
        }
    }

    class CarCollection<T>
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

        public void RemoveAll()
        {
            for (int i = 0; i < lastIndex; i++)
            {
                array = new T[5];
            }
            lastIndex = 0;
        }
    }

    interface ICar
    {
        string CarName { get; }
        int ProductionYear { get; }
    }

    class Car : ICar
    {
        private string carName;
        private int productionYear;        

        public string CarName {
            get
            {
                return carName;
            }
        }
        public int ProductionYear {
            get
            {
                return productionYear;
            }
        }

        public Car(string name, int year)
        {
            carName = name;
            productionYear = year;
        }
    }
}
