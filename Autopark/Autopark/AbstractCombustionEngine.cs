using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal abstract class AbstractCombustionEngine : AbstractEngine
    {

        public AbstractCombustionEngine()
        {

        }
        public AbstractCombustionEngine(string typeName, double taxCoefficient) : base(typeName, taxCoefficient)
        {

        }
        public double EngineCapacity { get; set; }
        public double FuelConsumptionPer100 { get; set; }

        public override double GetMaxKilometers(double fuelTankCapacity)
        {
            return fuelTankCapacity * 100 / FuelConsumptionPer100;
        }
    }
}
