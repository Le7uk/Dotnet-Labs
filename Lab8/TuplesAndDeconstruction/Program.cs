// Tuples and Deconstruction - existing code
var (gcd, lcm) = GcdLcm(48, 36);
Console.WriteLine(gcd);
Console.WriteLine(lcm);

var s1 = new Student("James", "Bond", 45);
var (name, age) = s1;
Console.WriteLine(name);
Console.WriteLine(age);

// --- Task 3 & 4: CollectionAnalyzer ---
Console.WriteLine("\n--- Task 3: CollectionAnalyzer.FindRange (throws on empty) ---");
var analyzer = new CollectionAnalyzer([3, 1, 7, 2, 9, 4]);
var range = analyzer.FindRange();
Console.WriteLine($"Min: {range.Min}, Max: {range.Max}, Range: {range.Range}");

// Task 4: Deconstruct
Console.WriteLine("\n--- Task 4: Deconstruction ---");
var (min, max, rangeVal) = analyzer;
Console.WriteLine($"Deconstructed — Min: {min}, Max: {max}, Range: {rangeVal}");

// Task 4: Null tuple on empty collection (instead of exception)
var emptyAnalyzer = new CollectionAnalyzer([]);
var nullResult = emptyAnalyzer.FindRange();
Console.WriteLine($"Empty collection result — Min: {nullResult.Min}, Max: {nullResult.Max}, Range: {nullResult.Range}");

// --- Task 5: FindRange with position range ---
Console.WriteLine("\n--- Task 5: FindRange with start/end position ---");
var sliceResult = analyzer.FindRange((1, 4)); 
Console.WriteLine($"Slice [1..4] — Min: {sliceResult.Min}, Max: {sliceResult.Max}, Range: {sliceResult.Range}");

(int Gcd, int Lcm) GcdLcm(int a, int b)
{
    var originalA = a;
    var originalB = b;
    while (a != b)
    {
        if (a > b)
            a -= b;
        else
            b -= a;
    }
    return (a, originalA * originalB / a);
}

public class Student
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Student(string name, string lastName, int age)
    {
        Name = name;
        LastName = lastName;
        Age = age;
    }

    public void Deconstruct(out string fullName, out int age)
    {
        fullName = $"{Name} {LastName}";
        age = Age;
    }
}

// ─────────────────────────────────────────────────────────────────
// Task 3: CollectionAnalyzer — FindRange throws on empty/null
// Task 4: Deconstruct support + return nulls instead of throwing
// Task 5: FindRange overload with (start, end) position tuple
// ─────────────────────────────────────────────────────────────────
public class CollectionAnalyzer
{
    private readonly IEnumerable<int>? _collection;

    public CollectionAnalyzer(IEnumerable<int>? collection)
    {
        _collection = collection;
    }

    // Task 3 → modified in Task 4: returns tuple with nulls instead of throwing
    public (int? Min, int? Max, int? Range) FindRange()
    {
        // Task 4: return nulls instead of InvalidOperationException
        if (_collection == null || !_collection.Any())
            return (null, null, null);

        var list = _collection.ToList();
        int min = list.Min();
        int max = list.Max();
        return (min, max, max - min);
    }

    // Task 5: overload accepting a (start, end) position tuple (inclusive, 0-based index)
    public (int? Min, int? Max, int? Range) FindRange((int Start, int End) positionRange)
    {
        // Guard: invalid range
        if (positionRange.Start < 0)
            throw new ArgumentOutOfRangeException(nameof(positionRange), "Start position cannot be negative.");
        if (positionRange.End < positionRange.Start)
            throw new ArgumentOutOfRangeException(nameof(positionRange), "End position cannot be lower than start position.");

        if (_collection == null)
            return (null, null, null);

        var slice = _collection
            .Skip(positionRange.Start)
            .Take(positionRange.End - positionRange.Start + 1)
            .ToList();

        if (!slice.Any())
            return (null, null, null);

        int min = slice.Min();
        int max = slice.Max();
        return (min, max, max - min);
    }

    // Task 4: Deconstruct — same shape as FindRange tuple
    public void Deconstruct(out int? min, out int? max, out int? range)
    {
        var result = FindRange();
        min   = result.Min;
        max   = result.Max;
        range = result.Range;
    }
}