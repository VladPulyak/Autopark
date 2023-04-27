﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal class DieselEngine : AbstractCombustionEngine
    {
        public DieselEngine()
        {
            
        }
        public DieselEngine(double engineCapacity, double fuelConsumptionPer100) : base("Diesel", 1.2)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }
    }
}
