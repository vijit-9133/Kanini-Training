using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class Practice
    {
        public void StringPract() {
        string originalString = "   Hello World, C# is great!   ";

        Console.WriteLine("--- String Manipulation Methods in Action ---");
        Console.WriteLine($"Original String: '{originalString}'\n");

        // Trim() - Removes leading and trailing white space
        string trimmedString = originalString.Trim();
        Console.WriteLine($"1. Trimmed: '{trimmedString}'");

        // ToUpper() - Converts all characters to uppercase
        string upperString = trimmedString.ToUpper();
        Console.WriteLine($"2. Uppercase: '{upperString}'");

        //ToLower() - Converts all characters to lowercase
        string lowerString = trimmedString.ToLower();
        Console.WriteLine($"3. Lowercase: '{lowerString}'");

        // Contains() - Checks if the string contains a substring
        bool containsCSharp = trimmedString.Contains("C#");
        Console.WriteLine($"4. Contains 'C#': {containsCSharp}");

        // IndexOf() - Finds the first occurrence of a character or string
        int index = trimmedString.IndexOf("World");
        Console.WriteLine($"5. Index of 'World': {index}");

        //Substring() - Extracts a part of the string
        string subString = trimmedString.Substring(index, 5);
        Console.WriteLine($"6. Substring from index {index} (5 chars): '{subString}'");

        //Replace() - Replaces all occurrences of a string
        string replacedString = trimmedString.Replace("C#", "Java");
        Console.WriteLine($"7. Replaced 'C#' with 'Java': '{replacedString}'");

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }

        public void StringBuildPract()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("The quick brown fox ");
            sb.Append("jumps over the lazy dog.");
            Console.WriteLine(sb.ToString()); 
        }
        public void MathPract()
        {
            double a = 12.7;
            double b = -12.7;
            double c = 27.25;
            double d = 2.0;

            int num1 = 15;
            int num2 = 10;

            // Math.Abs(x) 
            Console.WriteLine($"Absolute value of {b} is: {Math.Abs(b)}");

            // Math.Ceiling(x) 
            Console.WriteLine($"Ceiling of {a} is: {Math.Ceiling(a)}");

            // Math.Floor(x) 
            Console.WriteLine($"Floor of {a} is: {Math.Floor(a)}");

            // Math.Round(x) 
            Console.WriteLine($"Round of {c} is: {Math.Round(c)}");

            // Math.Pow(x, y) 
            Console.WriteLine($"{d} raised to the power of 3 is: {Math.Pow(d, 3)}");

            // Math.Sqrt(x) 
            Console.WriteLine($"Square root of {c} is: {Math.Sqrt(c)}");

            // Math.Max(x, y) 
            Console.WriteLine($"The larger of {num1} and {num2} is: {Math.Max(num1, num2)}");

            // Math.Min(x, y) 
            Console.WriteLine($"The smaller of {num1} and {num2} is: {Math.Min(num1, num2)}");

            // Trigonometric functions
            double angle = 60 * Math.PI / 180; 
            Console.WriteLine($"Sine of 60 degrees is: {Math.Sin(angle):F2}");
            Console.WriteLine($"Cosine of 60 degrees is: {Math.Cos(angle):F2}");
        }
    }
}