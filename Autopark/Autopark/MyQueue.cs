using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal class MyQueue<T> where T : Vehicle
    {
        public int Count { get; set; }
        public MyQueue(int countOfVehicles)
        {
            Count = countOfVehicles;
            QueueWithVehicles = new T[countOfVehicles];
        }
        public T[] QueueWithVehicles { get; set; }

        public void Enqueue(T vehicle)
        {
            var countOfVehicles = QueueWithVehicles.Count();
            QueueWithVehicles[countOfVehicles] = vehicle;
        }

        public T Dequeue()
        {
            for (int i = 0; i < length; i++)
            {

            }
            return
        }
    }
}
