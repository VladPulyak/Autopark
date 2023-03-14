using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal class DieselEngine : AbstractCombustionEngine
    {
        public DieselEngine(double engineCapacity, double fuelConsumptionPer100)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }


    }
}
