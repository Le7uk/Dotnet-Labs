using System.Collections;

var bond = new PersonName("James", "Bond");
foreach (var name in bond)
    Console.WriteLine(name);

var rock = new PersonName("Dwayne", "Johnson", "Rock");
Console.WriteLine(rock.Skip(1).First());

var bebeto = new PersonName("José", "de Oliveira", "Roberto", "Gama");
foreach (var name in bebeto)
    Console.WriteLine(name);

var a1 = new TextAnalyzer("Hello, World!");
foreach (var ch in a1)
    Console.Write(ch + " ");
Console.WriteLine();

var a2 = new TextAnalyzer("Hello, World! 123 \t test");
foreach (var ch in a2)
    Console.Write(ch + " ");
Console.WriteLine();

using var a3 = new TextAnalyzer("Hello World 42");
Console.WriteLine($"Count: {a3.Count()}");
Console.WriteLine($"First: {a3.First()}");
Console.WriteLine($"Has digits: {a3.Any(char.IsDigit)}");

using var a4 = new TextAnalyzer("C# is awesome 2026!");
Console.WriteLine("Chars: " + string.Join(", ", a4));

var schedule = new Schedule(new DateTime(2026, 5, 1), 7);
int total = 0, withHour = 0;
DateTime last = default;
foreach (var dt in schedule)
{
    Console.WriteLine($"  {dt:yyyy-MM-dd HH:mm}  ({dt.DayOfWeek})");
    total++;
    if (dt.Hour == 1) withHour++;
    last = dt;
}
Console.WriteLine($"Total: {total}, With Hour==1: {withHour}, Last: {last:yyyy-MM-dd}");


public class PersonName : IEnumerable<string>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string[] MiddleNames { get; }

    public PersonName(string firstName, string lastName, params string[] middleNames)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleNames = middleNames;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<string> GetEnumerator()
    {
        yield return FirstName;
        foreach (var middle in MiddleNames)
            yield return middle;
        yield return LastName;
    }
}


public class TextAnalyzer : IEnumerable<char>, IDisposable
{
    private readonly string _text;
    private readonly StringReader _reader;
    private bool _disposed = false;

    public TextAnalyzer(string text)
    {
        _text = text;
        _reader = new StringReader(text);
    }

    public IEnumerator<char> GetEnumerator()
    {
        using var reader = new StringReader(_text);
        int code;
        while ((code = reader.Read()) != -1)
        {
            char ch = (char)code;
            if (char.IsLetterOrDigit(ch))
                yield return ch;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Dispose()
    {
        if (!_disposed)
        {
            _reader?.Dispose();
            _disposed = true;
        }
    }
}


public class Schedule : IEnumerable<DateTime>
{
    private readonly DateTime _start;
    private readonly int _days;

    public Schedule(DateTime start, int days)
    {
        _start = start;
        _days = days;
    }

    public IEnumerator<DateTime> GetEnumerator()
    {
        var current = _start;
        for (var i = 0; i < _days; i++)
        {
            if (current.DayOfWeek != DayOfWeek.Saturday &&
                current.DayOfWeek != DayOfWeek.Sunday)
            {
                if (i % 2 == 0)
                    yield return current.AddHours(1);
                else
                    yield return current;
            }
            current = current.AddDays(1);
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}