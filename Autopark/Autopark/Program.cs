using Autopark;
using System.Runtime;

int operation = 0;
Collections autopark = new Collections("types.csv", "rents.csv", "vehicles.csv");

while (operation != -1)
{
    PrintMenu();
    Console.WriteLine("Enter your choise: ");
    operation = int.Parse(Console.ReadLine());

    switch (operation)
    {
        case 1:
            {
                autopark.Print();
                Console.WriteLine();
                break;
            }
        case 2:
            {
                Console.WriteLine("Vehicle to be added: \n");
                var vehicle = new Vehicle(autopark.TypesList[1], "Renault Duster", "9999 AA-0", 2000, 2016, 1000000, Color.Green, 45)
                {
                    Engine = new DieselEngine(2.0, 9),
                    CarId = 10
                };
                //autopark.Print(vehicle);
                autopark.InsertVehicle(9999, vehicle);
                Console.WriteLine();
                break;
            }
        case 3:
            {
                Console.WriteLine($"Enter index of deleted vehicle: ");
                int index = int.Parse(Console.ReadLine());
                Console.WriteLine("\nWe deleted this vehicle: ");
                //autopark.Print(autopark.VehiclesList[index - 1]);
                autopark.DeleteVehicle(index - 1);
                Console.WriteLine();
                break;
            }
        case 4:
            {
                Console.WriteLine($"\n============= Unsorted List =============\n");
                autopark.Print();
                autopark.Sort(new VehicleComparer());
                Console.WriteLine($"\n============= Sorted List =============\n");
                autopark.Print();
                Console.WriteLine();
                break;
            }
        case 5:
            {
                var countOfElementsInQueue = autopark.VehiclesList.Count;
                var queue = new CustomQueue<Vehicle>(countOfElementsInQueue);

                for (int i = 0; i < countOfElementsInQueue; i++)
                {
                    Console.WriteLine($"{autopark.VehiclesList[i].Model} standing in queue");
                    Thread.Sleep(1000);
                    queue.Enqueue(autopark.VehiclesList[i]);
                }

                for (int i = 0; i < countOfElementsInQueue; i++)
                {
                    var dequeuedVehicle = queue.Dequeue();
                    Console.WriteLine($"{dequeuedVehicle.Model} is washing..");
                    Thread.Sleep(1000);
                    Console.WriteLine($"{dequeuedVehicle.Model} is washing....");
                    Thread.Sleep(1000);
                    Console.WriteLine($"{dequeuedVehicle.Model} is washed");
                }

                queue.Clear();
                Console.WriteLine();
                break;
            }
        case 6:
            {
                Console.WriteLine("Enter capacity of garage");
                int capacity = int.Parse(Console.ReadLine());
                var stack = new CustomStack<Vehicle>(capacity);
                for (int i = 0; i < autopark.VehiclesList.Count; i++)
                {
                    var message = stack.Push(autopark.VehiclesList[i]);
                    if (message == "Garage is full")
                    {
                        break;
                    }
                    Console.WriteLine(autopark.VehiclesList[i].Model);
                    Console.WriteLine(message);
                    Thread.Sleep(1000);
                }
                int countOfFreePlaces = stack.Capacity - stack.CountOfCars;
                int countOfCars = stack.CountOfCars;
                if (countOfFreePlaces == 0)
                {
                    Console.WriteLine("========= Garage is full =========");
                }
                else
                {
                    Console.WriteLine($"There are {countOfFreePlaces} free places in garage");
                }
                for (int i = 0; i < countOfCars; i++)
                {
                    var element = stack.Pop();
                    Console.WriteLine($"{element.Model} left from garage");
                    Thread.Sleep(1000);
                }
                Console.WriteLine();
                break;
            }
        case 7:
            {
                var orders = autopark.LoadOrders("orders.csv");
                Console.WriteLine($"Order from automechanics: ");
                foreach (var order in orders)
                {
                    Console.WriteLine($"{order.Key} - {order.Value}");
                }
                Console.WriteLine();
                break;
            }
        case -1:
            {
                operation = -1;
                Console.WriteLine("Have a nice day! :)");
                break;
            }
        default:
            {
                Console.WriteLine("Operation was not found");
                break;
            }
    }
}

void PrintMenu()
{
    Console.WriteLine(@$"1. Print information about autopark" + Environment.NewLine +
                        "2. Add new car to autopark" + Environment.NewLine +
                        "3. Delete car from autopark" + Environment.NewLine +
                        "4. Sort list with vehicles" + Environment.NewLine +
                        "5. Washed vehicles" + Environment.NewLine +
                        "6. Put vehicles in the garage" + Environment.NewLine +
                        "7. Check orders from mechanics" + Environment.NewLine +
                        "-1. Exit program" + Environment.NewLine);
}