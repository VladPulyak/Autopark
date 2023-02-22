using Autopark;

var arrayWithCarTypes = new VehicleType[4];

arrayWithCarTypes[0] = new VehicleType("Bus", 1.2);
arrayWithCarTypes[1] = new VehicleType("Car", 1.0);
arrayWithCarTypes[2] = new VehicleType("Rink", 1.5);
arrayWithCarTypes[3] = new VehicleType("Tractor", 1.2);

//double maxTaxCoefficient = 0.0;
//double averageTaxCoefficient = 0.0;

//for (int i = 0; i < arrayWithCarTypes.Length; i++)
//{
//    arrayWithCarTypes[i].Display();

//    if (i == arrayWithCarTypes.Length - 1)
//    {
//        arrayWithCarTypes[i].TaxCoefficient = 1.3;
//    }

//    if (arrayWithCarTypes[i].TaxCoefficient > maxTaxCoefficient)
//    {
//        maxTaxCoefficient = arrayWithCarTypes[i].TaxCoefficient;
//    }

//    averageTaxCoefficient += arrayWithCarTypes[i].TaxCoefficient;
//}

//Console.WriteLine($"Max TaxCoefficient = {maxTaxCoefficient}");
//averageTaxCoefficient /= arrayWithCarTypes.Length;
//Console.WriteLine($"Average TaxCoefficient = {averageTaxCoefficient}");

//foreach (var carType in arrayWithCarTypes)
//{
//    carType.ToString();
//}

//Level 2

var arrayWithCars = new Vehicle[]
{
    new Vehicle(arrayWithCarTypes[0],"Volkswagen Crafter","5427 AX-7",2022,2015,376000,Color.Blue,140),
    new Vehicle(arrayWithCarTypes[0],"Volkswagen Crafter","6427 AA-7",2500,2014,227010,Color.White,135),
    new Vehicle(arrayWithCarTypes[0],"Electric Bus E321","6785 BA-7",12080,2019,20451,Color.Green,80),
    new Vehicle(arrayWithCarTypes[1],"Golf 5","8682 AX-7",1200,2006,230451,Color.Green,50),
    new Vehicle(arrayWithCarTypes[1],"Tesla Model S 70D","E001 AA-7",2200,2019,10454,Color.White,100),
    new Vehicle(arrayWithCarTypes[2],"Hamm HD 12 VV",null,3000,2016,122,Color.Yellow,42),
    new Vehicle(arrayWithCarTypes[3],"МТЗ Беларус-1025.4","1145 AB-7",1200,2020,109,Color.Red,135)
};

VehicleService.PrintInfoAboutVehicle(arrayWithCars);
Console.WriteLine("=====================================");
Array.Sort(arrayWithCars);
VehicleService.PrintInfoAboutVehicle(arrayWithCars);
Console.WriteLine("=====================================");
var carWithMaxMileage = new Vehicle();
var carWithMinMileage = new Vehicle();

int positionOfMaxMileage = VehicleService.GetPositionOfCarWithMaxMileage(arrayWithCars);
int positionOfMinMileage = VehicleService.GetPositionOfCarWithMinMileage(arrayWithCars);

arrayWithCars[positionOfMinMileage].ToString();
arrayWithCars[positionOfMaxMileage].ToString();