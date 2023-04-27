﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal class GasolineEngine : AbstractCombustionEngine
    {
        public GasolineEngine()
        {
            
        }
        public GasolineEngine(double engineCapacity, double fuelConsumptionPer100) : base("Gasoline", 1)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }
    }
}
