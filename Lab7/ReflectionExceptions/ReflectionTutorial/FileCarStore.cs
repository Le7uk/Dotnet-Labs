using System.Reflection;

namespace ReflectionTutorial;

public class FileCarStore
{
    public void StoreCars(string path, IEnumerable<Car> cars)
    {
        File.Delete(path);
        foreach (var car in cars)
        {
            File.AppendAllLines(path,
            [$"{car.Brand};{car.Model};{car.TankCapacity};{car.FuelConsumption};{car.FuelLevel};{car.Odometer}"]);
        }
    }

    public IList<Car> RestoreCars(string path)
    {
        var result = new List<Car>();
        var fileLines = File.ReadAllLines(path);

        Car.CarsMade = 0;

        foreach (var line in fileLines)
        {
            var d = line.Split(';');

            var car = new Car(d[0], d[1], int.Parse(d[2]), double.Parse(d[3]));
`
            var carType = typeof(Car);

            var fuelField = carType.GetField("_fuelLevel", BindingFlags.NonPublic | BindingFlags.Instance);
            var odoField = carType.GetField("_odometer", BindingFlags.NonPublic | BindingFlags.Instance);

            fuelField!.SetValue(car, double.Parse(d[4]));
            odoField!.SetValue(car, double.Parse(d[5]));

            result.Add(car);
        }

        return result;
    }
}