using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Calculator
{
    class Program
    {
        enum CalculatorMode
        {
            Number = 1,
            Date = 2,
            Exit = 3
        }
        static void Main(string[] args)
        {
            string path = @"C:\Users\Joshua.knights\Work\Calc\Calculator\Log.txt";
            NumberCalculator n = new NumberCalculator();
            DateCalculator d = new DateCalculator();
            checkfile(path);
            bool exit = false;
            string answer = "";

            welcome();
            while (!exit)
            {
                CalculatorMode mode = askFormode();
                switch (mode)
                {
                    case CalculatorMode.Number:
                        try
                        {
                            new NumberCalculator().run(path);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Something went wrong");
                            Console.WriteLine("error = " + ex.Message);
                            exit = true;
                        }
                        break;
                    case CalculatorMode.Date:
                        new DateCalculator().run(path);
                        break;
                    case CalculatorMode.Exit:
                        exit = true;
                        break;
                }
                if (!exit)
                {
                    exit = askForexit(exit, answer);
                }

            }






        }

        private static void checkfile(string path)
        {

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Log Start");

                }
            }
            else
            {
                File.WriteAllText(path, String.Empty);
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Log Start");
                }
            }
        }

        private static CalculatorMode askFormode()
        {

            while (true)
            {
                Console.WriteLine("what mode you want");
                Console.WriteLine("----------------------");
                Console.WriteLine("1. Calc");
                Console.WriteLine("2. Date");
                Console.WriteLine("3. Exit");
                int mode = takeint();
                if (mode != (int)CalculatorMode.Number && mode != (int)CalculatorMode.Date && mode != (int)CalculatorMode.Exit)
                {
                    Console.WriteLine("Not a mode");
                }
                else
                {
                    return (CalculatorMode)mode;
                }
            }
        }

        private static void welcome()
        {
            Console.WriteLine("Welcome to Calculator!");
            Console.WriteLine("----------------------");
        }
        public static string AskForInput(string output)
        {
            Console.WriteLine(output);

            return Console.ReadLine();

        }
        public static int takeint()
        {

            while (true)
            {
                string answer = AskForInput("Please enter a number: ");
                if (int.TryParse(answer, out int number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("not a number");
                }
            }

        }
        private static bool askForexit(bool exit, string answer)
        {
            while (answer != "y" && answer != "n")
            {
                answer = AskForInput("Want to exit y/n").ToLower();
            }
            return (answer == "y");

        }



    }
}
    
