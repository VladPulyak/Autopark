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

        public int CarId { get; set; }
        public List<Rent> OrdersList { get; set; } = new List<Rent>();
        public VehicleType Type { get; private set; }
        public string Model { get; private set; }
        public string RegistrationNumber { get; set; }
        public double Weight { get; private set; }
        public int ManufactureYear { get; private set; }
        public int Mileage { get; set; }
        public Color Color { get; set; }
        public double TankCapacity { get; private set; }
        public AbstractEngine Engine { get; set; }

        public double GetTotalIncome()
        {
            double totalIncome = 0;

            foreach (var rent in OrdersList)
            {
                totalIncome += rent.RentCost;
            }
            return totalIncome;
        }

        public double GetTotalProfit()
        {
            return GetTotalIncome() - GetCalcTaxPerMonth();
        }

        public double GetCalcTaxPerMonth()
        {
            return (Weight * 0.013) + (Type.TaxCoefficient * Engine.TaxCoefficient * 30) + 5;
        }

        public override string ToString() //Why is this method commented out?
        {
            string resultString = $"{Type}, {Model}, {RegistrationNumber}, {Weight}, {ManufactureYear}, {Mileage}, {Color}, {TankCapacity}, {GetCalcTaxPerMonth()}";
            Console.WriteLine(resultString); //It should not be in overrided ToString() method
            return resultString;
        }

        public override bool Equals(object obj) // Is it necessary to make it nullable?
        {
            var vehicle = obj as Vehicle;

            if (vehicle != null)
            {
                if ((Type == vehicle.Type) && (Model == vehicle.Model))
                {
                    return true;
                }
                return false;
                //else // No needs in else statement
                //{
                //    return false;
                //}
            }
            else // No needs in else statement
            {
                throw new NullReferenceException("This object is not vehicle"); //It's better to use NullReferenceException
            }
        }
        public int CompareTo(Vehicle secondVehicle) // Is it necessary to make it nullable?
        {
            double taxOfFirstVehicle = GetCalcTaxPerMonth();
            double taxOfSecondVehicle = secondVehicle.GetCalcTaxPerMonth();

            if (taxOfFirstVehicle > taxOfSecondVehicle)
            {
                return 1; // This condition should return 1
            }
            else if (taxOfFirstVehicle < taxOfSecondVehicle)
            {
                return -1; //And this condition should return -1
            }
            return 0;
            //else
            //{
            //    return 0;
            //}
        }


    }
}
