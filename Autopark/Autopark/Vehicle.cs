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

        public override string ToString()
        {
            string resultString = $"{Type}, {Model}, {RegistrationNumber}, {Weight}, {ManufactureYear}, {Mileage}, {Color}, {TankCapacity}, {GetCalcTaxPerMonth()}";
            return resultString;
        }

        public override bool Equals(object obj)
        {
            var vehicle = obj as Vehicle;

            if (vehicle != null)
            {
                if ((Type == vehicle.Type) && (Model == vehicle.Model))
                {
                    return true;
                }
                return false;
            }
            throw new NullReferenceException("This object is not vehicle");
        }
        public int CompareTo(Vehicle secondVehicle)
        {
            double taxOfFirstVehicle = GetCalcTaxPerMonth();
            double taxOfSecondVehicle = secondVehicle.GetCalcTaxPerMonth();

            if (taxOfFirstVehicle > taxOfSecondVehicle)
            {
                return 1;
            }
            else if (taxOfFirstVehicle < taxOfSecondVehicle)
            {
                return -1;
            }
            return 0;
        }
    }
}
