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
        public CustomQueue()
        {
            
        }
        public CustomQueue(T[] queue)
        {
            QueueWithVehicles = queue;
            Length = queue.Length;
            CountOfCars = queue.Length;
        }
        public CustomQueue(int countOfVehicles)
        {
            Length = countOfVehicles;
            QueueWithVehicles = new T[countOfVehicles];
        }
        public int Length { get; set; }
        public int CountOfCars { get; set; }
        private T[] QueueWithVehicles { get; set; }

        public void Enqueue(T vehicle)
        {
            QueueWithVehicles[CountOfCars] = vehicle;
            CountOfCars++;
        }

        public T Dequeue()
        {
            T vehicle = QueueWithVehicles[0];
            T temp;

            for (int i = 0; i < CountOfCars - 1; i++)
            {
                temp = QueueWithVehicles[i + 1];
                QueueWithVehicles[i + 1] = QueueWithVehicles[i];
                QueueWithVehicles[i] = temp;
            }
            CountOfCars--;
            return vehicle;
        }

        public void Clear()
        {
            Array.Clear(QueueWithVehicles);
        }
    }
}
