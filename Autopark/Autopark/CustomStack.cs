using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal class CustomStack<T> where T : class
    {
        public CustomStack()
        {
            
        }
        public CustomStack(int countOfElements)
        {
            Capacity = countOfElements;
            Stack = new T[countOfElements];
        }

        public CustomStack(T[] stack)
        {
            Stack = stack;
            Capacity = stack.Count();
        }

        private T[] Stack { get; set; }
        public int Capacity { get; set; }
        public int CountOfCars { get; set; }

        public string Push(T element)
        {
            if ((Capacity - CountOfCars) > 0)
            {
                Stack[CountOfCars] = element;
                CountOfCars++;
                return "Vehicle is comming to garage";
            }
            return "Garage is full";
        }

        public T Pop()
        {
            T item = Stack[CountOfCars - 1];
            Stack[CountOfCars - 1] = null;
            CountOfCars--;
            return item;
        }
    }
}
