namespace ReflectionTutorial;

public class InsufficientFuelException : Exception
{
    public double DistanceRequested { get; }
    public double FuelAvailable { get; }
    public double FuelNeeded { get; }

    public InsufficientFuelException(double distanceRequested, double fuelAvailable, double fuelNeeded)
        : base($"Cannot drive {distanceRequested}km. " +
               $"Available fuel: {fuelAvailable}L, " +
               $"needed: {fuelNeeded}L, " +
               $"missing: {fuelNeeded - fuelAvailable:F2}L.")
    {
        DistanceRequested = distanceRequested;
        FuelAvailable = fuelAvailable;
        FuelNeeded = fuelNeeded;
    }
}