using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal class CustomStack<T> where T : class // Discuss realisation
    {
        public CustomStack(int countOfElements) //Naming +
        {
            Capacity = countOfElements;
            Stack = new T[countOfElements];
        }

        public CustomStack(T[] enumerable) //передавать количество места в гараже
        {
            Stack = enumerable;
            Capacity = enumerable.Count(); //?
        }

        private T[] Stack { get; set; }
        public int Capacity { get; set; } // No need to initialize here Вместимость гаража
        public int CountOfCars { get; set; } // текущее кол-во машин

        public void Push(T element) // сделать проверку остались ли места в гараже (Capacity - CountOfCars) <= 0 или Capacity == CountOfCars Можно сделать тут Console.WriteLine("Гараж заполнен") или return 
        {
            Stack[CountOfCars] = element;
            CountOfCars++;
        }

        public T Pop()
        {
            T item = Stack[CountOfCars - 1]; // Should be count - 1
            //Capacity++;
            Stack[CountOfCars] = null;
            CountOfCars--;
            return item;
        }
    }
}
