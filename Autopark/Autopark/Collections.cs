using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    internal class Collections
    {
        public Collections(string typesFileName, string rentsFileName, string vehiclesFileName)
        {
            TypesList = new List<VehicleType>();
            VehiclesList = new List<Vehicle>();
            TypesList = ParseVehicleTypes(typesFileName);
            VehiclesList = ParseVehicles(vehiclesFileName);
            LoadRents(rentsFileName);
        }
        public List<VehicleType> TypesList { get; set; }
        public List<Vehicle> VehiclesList { get; set; }

        private List<VehicleType> ParseVehicleTypes(string path)
        {
            var listWithVehicleTypes = new List<VehicleType>();
            using (StreamReader reader = new StreamReader(path))
            {
                var line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Replace("\"", "");
                    var vehicleType = CreateVehicleType(line);
                    listWithVehicleTypes.Add(vehicleType);
                }
            }
            return listWithVehicleTypes;
        }

        private List<Vehicle> ParseVehicles(string path)
        {
            var listWithVehicles = new List<Vehicle>();
            using (StreamReader reader = new StreamReader(path))
            {
                var line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Replace("\"", "");
                    var vehicle = CreateVehicle(line);
                    listWithVehicles.Add(vehicle);
                }
            }
            return listWithVehicles;
        }

        private void LoadRents(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                var line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Replace("\"", "");
                    var parameters = line.Split(", ");
                    var rent = new Rent(DateTime.Parse(parameters[1]), double.Parse(parameters[2]));
                    var variable = VehiclesList.FirstOrDefault(q => q.CarId == int.Parse(parameters[0]));
                    variable.OrdersList.Add(rent);
                }
            }
        }

        private VehicleType CreateVehicleType(string csvString)
        {
            var parameters = csvString.Split(", ");
            return new VehicleType()
            {
                TypeId = int.Parse(parameters[0]),
                TypeName = parameters[1],
                TaxCoefficient = double.Parse(parameters[2])
            };
        }

        private Vehicle CreateVehicle(string csvString)
        {
            var parameters = csvString.Split(", ");
            var typeIndex = int.Parse(parameters[1]);
            var color = (Color)Enum.Parse(typeof(Color), parameters[7]);
            AbstractEngine engine;

            if (parameters[8] == "Diesel")
            {
                engine = new DieselEngine(double.Parse(parameters[9]), double.Parse(parameters[10]));
                engine.TypeName = parameters[8];
                engine.TaxCoefficient = 1.2;
            }
            else if (parameters[8] == "Gasoline")
            {
                engine = new DieselEngine(double.Parse(parameters[9]), double.Parse(parameters[10]));
                engine.TypeName = parameters[8];
                engine.TaxCoefficient = 1;
            }
            else
            {
                engine = new ElectricalEngine(double.Parse(parameters[10]));
                engine.TypeName = parameters[8];
                engine.TaxCoefficient = 0.1;
            }
            return new Vehicle(TypesList[typeIndex - 1], parameters[2], parameters[3], double.Parse(parameters[4]), int.Parse(parameters[5]), int.Parse(parameters[6]), color, double.Parse(parameters[11]))
            {
                CarId = int.Parse(parameters[0]),
                Engine = engine
            };
        }

        public void InsertVehicle(int index, Vehicle vehicle)
        {
            if (index < VehiclesList.Count)
            {
                VehiclesList.Insert(index, vehicle);
            }
            else
            {
                VehiclesList.Add(vehicle);
            }
        }

        public bool DeleteVehicle(int index)
        {
            if (index >= VehiclesList.Count)
            {
                return false;
            }
            else
            {
                VehiclesList.RemoveAt(index);
                return true;
            }
        }

        public double SumTotalProfit()
        {
            double totalProfit = 0;

            foreach (var vehicle in VehiclesList)
            {
                totalProfit += vehicle.GetTotalProfit();
            }
            return totalProfit;
        }

        public void Print()
        {
            Console.WriteLine("{0,-5}{1,-10}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}",
                "Id", "Type", "ModelName", "Number", "Weight (kg)", "Year", "Mileage", "Color", "Income", "Tax", "Profit");
            foreach (var vehicle in VehiclesList)
            {
                Console.WriteLine("{0,-5}{1,-10}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}",
                                                                            vehicle.CarId,
                                                                            vehicle.Type.TypeName,
                                                                            vehicle.Model,
                                                                            vehicle.RegistrationNumber,
                                                                            vehicle.Weight,
                                                                            vehicle.ManufactureYear,
                                                                            vehicle.Mileage,
                                                                            vehicle.Color,
                                                                            vehicle.GetTotalIncome().ToString("0.00"),
                                                                            vehicle.GetCalcTaxPerMonth().ToString("0.00"),
                                                                            vehicle.GetTotalProfit().ToString("0.00"));

            }
            Console.WriteLine($"{"Total",-5}{"",-115}{SumTotalProfit(),-10:0.00}");
        }

        public void Sort(IComparer<Vehicle> comparator)
        {
            VehiclesList.Sort(comparator);
        }
    }
}
