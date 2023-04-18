using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal class CustomStack<T> where T : class // Discuss realisation
    {
        public CustomStack(int countOsElements) //Naming
        {
            Count = countOsElements;
            Stack = new T[countOsElements];
        }

        public CustomStack(IEnumerable<T> enumerable)
        {
            Stack = enumerable.Reverse().ToArray(); // No need to reverse it
            Count = enumerable.Count(); //?
        }

        private T[] Stack { get; set; }
        public int Count { get; set; } = 0; // No need to initialize here

        public void Push(T element)
        {
            Stack[Count - 1] = element;
            Count--;
        }

        public T Pop()
        {
            T item = Stack[Count]; // Should be count - 1
            Count++;
            Stack[Count - 1] = null;
            return item;
        }
    }
}
