using ReflectionTutorial;

var car1 = new Car("Ford", "Mondeo", 60, 6.5);
var car2 = new Car("Toyota", "Corolla", 50, 6.0);

car1.AddFuel(40);
car1.Drive(200);

car2.AddFuel(30);
car2.Drive(100);

Console.WriteLine($"Before save:");
Console.WriteLine($"{car1.Brand} {car1.Model} | Fuel: {car1.FuelLevel} | Odometer: {car1.Odometer}");
Console.WriteLine($"{car2.Brand} {car2.Model} | Fuel: {car2.FuelLevel} | Odometer: {car2.Odometer}");
Console.WriteLine($"Cars made: {Car.CarsMade}");

var store = new FileCarStore();
store.StoreCars("cars.txt", [car1, car2]);
Console.WriteLine("\nSaved to cars.txt");

var restored = store.RestoreCars("cars.txt");
Console.WriteLine($"\nAfter restore:");
Console.WriteLine($"Cars made after restore: {Car.CarsMade}"); 

foreach (var car in restored)
    Console.WriteLine($"{car.Brand} {car.Model} | Fuel: {car.FuelLevel} | Odometer: {car.Odometer}");

Console.WriteLine("\nTesting InsufficientFuelException:");
try
{
    var testCar = new Car("BMW", "M3", 60, 10.0);
    testCar.AddFuel(5); 
    testCar.Drive(200); 
}
catch (InsufficientFuelException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
    Console.WriteLine($"Distance requested: {ex.DistanceRequested}km");
    Console.WriteLine($"Fuel available: {ex.FuelAvailable}L");
    Console.WriteLine($"Fuel needed: {ex.FuelNeeded}L");
}