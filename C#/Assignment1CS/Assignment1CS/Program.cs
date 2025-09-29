using System;
using System.Text;

namespace Assignment1CS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Alternating Case Converter ---");

            Console.Write("Enter the word: ");
            string word = Console.ReadLine();

            if (string.IsNullOrEmpty(word))
            {
                Console.WriteLine("No word entered. Nothing to convert.");
                Console.ReadKey();
                return;
            }

            StringBuilder resultBuilder = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                char character = word[i];

                if (i % 2 == 0)
                {
                    resultBuilder.Append(char.ToUpper(character));
                }
                else
                {
                    resultBuilder.Append(char.ToLower(character));
                }
            }

            Console.WriteLine(resultBuilder.ToString());
            Console.WriteLine("--- Skydiving Eligibility Check ---");

            Console.Write("Enter your age: ");
            string ageInput = Console.ReadLine();

            int age;
            if (!int.TryParse(ageInput, out age))
            {
                Console.WriteLine("That's not a valid age. Please enter a whole number.");
                Console.WriteLine("You're not allowed to go skydiving due to bad input.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter your weight in kilograms: ");
            string weightInput = Console.ReadLine();

            int weight;
            if (!int.TryParse(weightInput, out weight))
            {
                Console.WriteLine("Not a valid weight. Please enter a whole number.");
                Console.ReadKey();
                return;
            }

            if (age >= 18 && weight < 90)
            {
                Console.WriteLine("You are allowed to go skydiving.");
            }
            else
            {
                Console.WriteLine("You are not allowed to go skydiving.");
            }
            Console.WriteLine("--- Loan Eligibility Check ---");

            Console.Write("Enter your income: ");
            string incomeInput = Console.ReadLine();

            int income;
            if (!int.TryParse(incomeInput, out income) || income < 0)
            {
                Console.WriteLine("That's not a valid income. Please enter a positive whole number.");
                Console.WriteLine("You are not eligible for a loan due to invalid input.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter your credit score: ");
            string creditScoreInput = Console.ReadLine();

            int creditScore;
            if (!int.TryParse(creditScoreInput, out creditScore) || creditScore < 0)
            {
                Console.WriteLine("Not a valid credit score. Please enter a positive whole number.");    
                Console.ReadKey();
                return;
            }

            if (income >= 50000 && creditScore >= 700)
            {
                Console.WriteLine("You are eligible for a loan.");
            }
            else if (income >= 25000 && creditScore >= 650)
            {
                Console.WriteLine("Eligible, but may face higher interest rates.");
            }
            else
            {
                Console.WriteLine("You are not eligible for a loan.");
            }
            Console.WriteLine("------------------------------------");
            
          
        
        Console.WriteLine("------------------------------------");
            Console.WriteLine("--- Number Conversion Playground ---");
            Console.WriteLine("Enter different values to see how C# conversion methods behave.");
            Console.WriteLine("------------------------------------");

            List<string> inputs = new List<string>();

            Console.Write("1. Enter a valid integer (e.g., 42): ");
            inputs.Add(Console.ReadLine());

            Console.Write("2. Enter a decimal number (e.g., 42.7): ");
            inputs.Add(Console.ReadLine());

            Console.Write("3. Press Enter for an empty value: ");
            inputs.Add(Console.ReadLine());

            Console.Write("4. Enter a non-numeric string (e.g., abc): ");
            inputs.Add(Console.ReadLine());

            Converter myConverter = new Converter();

            myConverter.RunConversionExperiments(inputs);


            Studentreport sr = new Studentreport();
            StudentData ldata = sr.CollectInput();
            sr.ProcessLearnerData(ldata);
            sr.Display(ldata);
        }
    }
}