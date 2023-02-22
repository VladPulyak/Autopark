using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal class Vehicle : IComparable<Vehicle>
    {
        public Vehicle()
        {

        }

        public Vehicle(VehicleType type, string model, string registrationModel, double weight, int manufactureYear, int mileage, Color color, double tankCapacity)
        {
            Type = type;
            Model = model;
            RegistrationNumber = registrationModel;
            Weight = weight;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            Color = color;
            TankCapacity = tankCapacity;
        }

        public VehicleType Type { get; private set; }
        public string Model { get; private set; }
        public string RegistrationNumber { get; set; }
        public double Weight { get; private set; }
        public int ManufactureYear { get; private set; }
        public int Mileage { get; set; }
        public Color Color { get; set; }
        public double TankCapacity { get; private set; }

        public double GetCalcTaxPerMonth()
        {
            return (Weight * 0.0013) + (Type.TaxCoefficient * 30) + 5;
        }

        public override string ToString()
        {
            string resultString = $"{Type}, {Model}, {RegistrationNumber}, {Weight}, {ManufactureYear}, {Mileage}, {Color}, {TankCapacity}, {GetCalcTaxPerMonth()}";
            Console.WriteLine(resultString);
            return resultString;
        }

        public int CompareTo(object? secondTax)
        {
            double taxOfFirstCar = GetCalcTaxPerMonth();

            if (taxOfFirstCar > (double)secondTax)
            {
                return -1;
            }
            else if (taxOfFirstCar < (double)secondTax)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int CompareTo(Vehicle? secondVehicle)
        {
            double taxOfFirstVehicle = GetCalcTaxPerMonth();
            double taxOfSecondVehicle = secondVehicle.GetCalcTaxPerMonth();

            if (taxOfFirstVehicle > taxOfSecondVehicle)
            {
                return -1;
            }
            else if (taxOfFirstVehicle < taxOfSecondVehicle)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
