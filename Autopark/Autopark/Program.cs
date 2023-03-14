using Autopark;
using System.Reflection;

Collections autopark = new Collections("types.csv", "rents.csv", "vehicles.csv");

autopark.Print();

var vehicle = new Vehicle(autopark.TypesList[1], "Clown", "9999 AA-0", 999, 2023, 1000000, Color.Green, 1000)
{
    Engine = new DieselEngine(99, 20),
    CarId = 99
};

autopark.InsertVehicle(9999, vehicle);

autopark.Print();

autopark.DeleteVehicle(1);
autopark.DeleteVehicle(2);
autopark.DeleteVehicle(3);
autopark.DeleteVehicle(4);

autopark.Print();

autopark.Sort(new VehicleComparer());

autopark.Print();

var queue = new Queue<Vehicle>(autopark.VehiclesList);
var length = queue.Count;

for (int i = 0; i < length; i++)
{
    var deletedVehicle = queue.Dequeue();
    Console.WriteLine($"{deletedVehicle.Model} вымыто");
}

var stack = new Stack<Vehicle>();

for (int i = 0; i < autopark.VehiclesList.Count; i++)
{
    stack.Push(autopark.VehiclesList[i]);
    Console.WriteLine($"{autopark.VehiclesList[i].Model} pushed to garage");
}

for (int i = 0; i < autopark.VehiclesList.Count; i++)
{
    Console.WriteLine($"{stack.Pop().Model} pop from garage");
}

