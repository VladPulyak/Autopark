using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal abstract class AbstractEngine
    {
        public string TypeName { get; set; }
        public double TaxCoefficient { get; set; }

        public abstract double GetMaxKilometers(double fuelTank);
    }
}
