using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1CS
{
    public class Converter
    {
        public void RunConversionExperiments(List<string> inputs)
        {
            Console.WriteLine("\n--- Conversion Results ---");
            Console.WriteLine("Input Value | Convert.ToInt32 | int.Parse | int.TryParse");
            Console.WriteLine("--------------------------------------------------------------------");

            foreach (string input in inputs)
            {
                string displayInput = input;
                if (string.IsNullOrEmpty(input))
                {
                    displayInput = "\"\" (empty)";
                }

                string convertToInt32Result;
                try
                {
                    int convertedValue = Convert.ToInt32(input);
                    convertToInt32Result = convertedValue.ToString();
                }
                catch (Exception)
                {
                    convertToInt32Result = "Error";
                }

                string parseIntResult;
                try
                {
                    int parsedValue = int.Parse(input);
                    parseIntResult = parsedValue.ToString();
                }
                catch (Exception)
                {
                    parseIntResult = "Error";
                }
                bool tryParseSuccess = int.TryParse(input, out int tryParsedValue);
                string tryParseResult = $"{tryParseSuccess}, {tryParsedValue}";

                Console.WriteLine($"{displayInput,-12} | {convertToInt32Result,-15} | {parseIntResult,-9} | {tryParseResult,-15}");
            }
        }
    }
}

