var elevator = new Elevator(0, 10, 500);

elevator.FloorReached += (sender, e) =>
    Console.WriteLine($"Floor reached: {e.Floor}");

elevator.DestinationFloorReached += (sender, e) =>
    Console.WriteLine($"Destination floor reached: {e.Floor}");

Console.WriteLine("Moving to floor 4:");
elevator.Move(4);

Console.WriteLine("\nMoving to floor 1:");
elevator.Move(1);

Console.WriteLine($"\nCurrent floor: {elevator.CurrentFloor}");

Console.WriteLine("\nTrying invalid floor (15):");
try
{
    elevator.Move(15);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Exception: {ex.Message}");
}

Console.WriteLine("\nTrying to move while already moving:");
var slowElevator = new Elevator(0, 10, 1000);
slowElevator.FloorReached += (sender, e) =>
    Console.WriteLine($"Floor reached: {e.Floor}");

var moveTask = Task.Run(() => slowElevator.Move(5));
Thread.Sleep(500);
try
{
    slowElevator.Move(3);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Exception: {ex.Message}");
}
moveTask.Wait();

public class ElevatorFloorEventArgs : EventArgs
{
    public int Floor { get; init; }
}

public class Elevator
{
    public int CurrentFloor { get; private set; }
    public int MinFloor { get; }
    public int MaxFloor { get; }
    public int MillisecondsBetweenFloors { get; }
    public bool IsMoving { get; private set; }

    public event EventHandler<ElevatorFloorEventArgs>? FloorReached;
    public event EventHandler<ElevatorFloorEventArgs>? DestinationFloorReached;

    public Elevator(int minFloor, int maxFloor, int millisecondsBetweenFloors)
    {
        if (minFloor >= maxFloor)
            throw new ArgumentException("MinFloor must be less than MaxFloor.");

        if (millisecondsBetweenFloors <= 0)
            throw new ArgumentOutOfRangeException(nameof(millisecondsBetweenFloors), "Must be greater than 0.");

        MinFloor = minFloor;
        MaxFloor = maxFloor;
        MillisecondsBetweenFloors = millisecondsBetweenFloors;
        CurrentFloor = minFloor;
    }

    public void Move(int destinationFloor)
    {
        if (destinationFloor < MinFloor || destinationFloor > MaxFloor)
            throw new ArgumentOutOfRangeException(nameof(destinationFloor),
                $"Floor must be between {MinFloor} and {MaxFloor}.");

        if (IsMoving)
            throw new InvalidOperationException("Elevator is already moving.");

        if (destinationFloor == CurrentFloor)
            return;

        IsMoving = true;

        int direction = destinationFloor > CurrentFloor ? 1 : -1;

        while (CurrentFloor != destinationFloor)
        {
            Thread.Sleep(MillisecondsBetweenFloors);
            CurrentFloor += direction;
            FloorReached?.Invoke(this, new ElevatorFloorEventArgs { Floor = CurrentFloor });
        }

        DestinationFloorReached?.Invoke(this, new ElevatorFloorEventArgs { Floor = CurrentFloor });

        IsMoving = false;
    }
}