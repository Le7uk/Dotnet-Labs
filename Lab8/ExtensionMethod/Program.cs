var someShittyString = "hello from the OTHer sIDe"; 
var fixedString = someShittyString.ToSentence();
Console.WriteLine(fixedString);
Console.WriteLine(7.IsEven());
Console.WriteLine(7.IsOdd());
Console.WriteLine(2.IsPrime());
List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
Console.WriteLine(numbers.First());
Console.WriteLine(numbers.Second());

// --- Task 6: Perfect numbers ---
Console.WriteLine("\n--- Task 6: Perfect Numbers ---");
Console.WriteLine($"6 is perfect: {6.IsPerfect()}");    
Console.WriteLine($"28 is perfect: {28.IsPerfect()}");  
Console.WriteLine($"12 is perfect: {12.IsPerfect()}");  

// --- Task 7: Mutually prime (coprime) ---
Console.WriteLine("\n--- Task 7: Mutually Prime ---");
Console.WriteLine($"8 and 15 are coprime: {8.IsCoprime(15)}"); 
Console.WriteLine($"6 and 9 are coprime: {6.IsCoprime(9)}");    

// --- Task 8: Weekend check ---
Console.WriteLine("\n--- Task 8: Weekend Check ---");
var saturday = new DateTime(2025, 4, 19);
var monday   = new DateTime(2025, 4, 21);
Console.WriteLine($"{saturday:dddd} is weekend: {saturday.IsWeekend()}");
Console.WriteLine($"{monday:dddd} is weekend: {monday.IsWeekend()}");     

// --- Task 9: Palindrome ---
Console.WriteLine("\n--- Task 9: Palindrome ---");
Console.WriteLine($"\"racecar\" is palindrome: {"racecar".IsPalindrome()}"); 
Console.WriteLine($"\"hello\" is palindrome: {"hello".IsPalindrome()}");     
Console.WriteLine($"\"A man a plan a canal Panama\" is palindrome: {"A man a plan a canal Panama".IsPalindrome()}"); // true

public static class Extensions
{
    // --- Existing methods ---
    public static T Second<T>(this IEnumerable<T> input) => input.Skip(1).First();

    public static string ToSentence(this string input)
    {
        return input[0].ToString().ToUpper() + input.Substring(1).ToLower();
    }

    public static bool IsEven(this int number) => number % 2 == 0;
    public static bool IsOdd(this int number) => !number.IsEven();

    public static bool IsPrime(this int number)
    {
        if (number == 1)
            return false;
        if (number == 2)
            return true;
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    // --- Task 6: Perfect number ---
    // A number is perfect if it equals the sum of its proper divisors (excluding itself)
    public static bool IsPerfect(this int number)
    {
        if (number <= 1) return false;

        int sum = 1; 
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                sum += i;
                if (i != number / i) 
                    sum += number / i;
            }
        }
        return sum == number;
    }

    // --- Task 7: Mutually prime (coprime) ---
    // Two numbers are coprime if their GCD equals 1
    public static bool IsCoprime(this int number, int other)
    {
        return Gcd(Math.Abs(number), Math.Abs(other)) == 1;
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // --- Task 8: Weekend check ---
    public static bool IsWeekend(this DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
    }

    // --- Task 9: Palindrome ---
    // Ignores spaces and casing
    public static bool IsPalindrome(this string text)
    {
        if (string.IsNullOrEmpty(text)) return true;

        var cleaned = new string(text.Where(char.IsLetterOrDigit).ToArray()).ToLower();
        var reversed = new string(cleaned.Reverse().ToArray());
        return cleaned == reversed;
    }
}