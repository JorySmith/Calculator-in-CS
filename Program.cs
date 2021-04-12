using System;

namespace Calculator
{
    class Calculator
        // Do the calculations
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // default value is NaN

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d": 
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }
    class Program
        // Do the UI, input requests, input validations, and error capturing
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // App title
            Console.WriteLine("Jory's Magical C# Calculator App\r");
            Console.WriteLine("--------------------------------\r");

            while (!endApp)
            {
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Get input 1 from user
                Console.Write("Type a number, then press Enter: ");
                numInput1 = Console.ReadLine();

                // Verify input 1 was a number
                // while loop testing numInput with double.TryParse, out result assigned to cleanNum var
                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Invalid input. Please enter a whole number: ");
                    numInput1 = Console.ReadLine();
                }

                // Get input 2 from user
                Console.Write("Type a second number, then press Enter: ");
                numInput2 = Console.ReadLine();

                // Verify input 2 was a number
                // while loop testing numInput with double.TryParse, out result assigned to cleanNum var
                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Invalid input. Please enter a whole number: ");
                    numInput2 = Console.ReadLine();
                }

                // Get operator type from user
                Console.WriteLine("Choose an operator from below:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option: ");
                string op = Console.ReadLine();

                // Try calculation, catch any errors
                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in an error.\n");
                    }
                    else Console.WriteLine($"Your result is: {result}\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR--Details: " + e.Message);
                }
                Console.WriteLine("-------------------------\n");

                // Ask the user if they want to keep using the app
                Console.WriteLine("Would you like to continue using the app?\n");
                Console.WriteLine("Type 'n' then Enter to close the app, or press any other button then Enter to continue\n");
                if (Console.ReadLine() == "n") endApp = true;
                Console.WriteLine("\n");               

            }
        }
    }
}
