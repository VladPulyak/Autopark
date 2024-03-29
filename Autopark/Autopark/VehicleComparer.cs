﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal class VehicleComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle? firstVehicle, Vehicle? secondVehicle)
        {
            return firstVehicle.Model.CompareTo(secondVehicle.Model);
        }
    }
}
