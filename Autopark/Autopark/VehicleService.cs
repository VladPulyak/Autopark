using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal static class VehicleService
    {
        public static void PrintInfoAboutVehicle(Vehicle[] arrayWithCars)
        {
            foreach (var car in arrayWithCars)
            {
                car.ToString();
            }
        }

        public static int GetPositionOfCarWithMinMileage(Vehicle[] arrayWithCars)
        {
            int minMileage = arrayWithCars[0].Mileage;
            int position = 0;

            for (int i = 0; i < arrayWithCars.Length; i++)
            {
                if (arrayWithCars[i].Mileage < minMileage)
                {
                    minMileage = arrayWithCars[i].Mileage;
                    position = i;
                }
            }
            return position;
        }

        public static int GetPositionOfCarWithMaxMileage(Vehicle[] arrayWithCars)
        {
            int maxMileage = arrayWithCars[0].Mileage;
            int position = 0;

            for (int i = 0; i < arrayWithCars.Length; i++)
            {
                if (arrayWithCars[i].Mileage > maxMileage)
                {
                    maxMileage = arrayWithCars[i].Mileage;
                    position = i;
                }
            }
            return position;
        }
    }
}
