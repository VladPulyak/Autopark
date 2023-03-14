using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal class VehicleType
    {
        public VehicleType()
        {

        }

        public VehicleType(string typeName, double taxCoefficient)
        {
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public double TaxCoefficient { get; set; }

        public void Display()
        {
            Console.WriteLine($"TypeName = {TypeName}");
            Console.WriteLine($"TaxCoefficient = {TaxCoefficient}");
        }

        public override string ToString()
        {
            string resultString = $"{TypeName}, {TaxCoefficient}";
            Console.WriteLine(resultString);
            return resultString;
        }
    }
}
