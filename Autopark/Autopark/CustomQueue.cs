using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal class CustomQueue<T> where T : class
    {
        public int Count { get; set; }
        private int Head { get; set; } = 0;
        private int Tail { get; set; } = 0;
        public CustomQueue(IEnumerable<T> enumerable)
        {
            QueueWithVehicles = enumerable.ToArray();
            Count = enumerable.Count();
        }
        public CustomQueue(int countOfVehicles)
        {
            Count = countOfVehicles;
            QueueWithVehicles = new T[countOfVehicles];
        }
        private T[] QueueWithVehicles { get; set; }

        public void Enqueue(T vehicle)
        {
            QueueWithVehicles[Tail] = vehicle;
            Tail++;
        }

        public T Dequeue()
        {
            T vehicle = QueueWithVehicles[Head];
            T temp;

            for (int i = Head; i < Count - 1; i++)
            {
                temp = QueueWithVehicles[i + 1];
                QueueWithVehicles[i + 1] = QueueWithVehicles[i];
                QueueWithVehicles[i] = temp;
            }
            Count--;

            return vehicle;
        }

        public void Clear()
        {
            Array.Clear(QueueWithVehicles);
        }
    }
}
