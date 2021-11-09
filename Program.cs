using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Calculator
{
    class Program
    {
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
                int mode = askFormode();
                switch (mode)
                {
                    case 1:
                        n.run(path);
                        break;
                    case 2:
                        d.run(path);
                        break;
                    case 3:
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

        private static int askFormode()
        {

            while (true)
            {
                Console.WriteLine("what mode you want");
                Console.WriteLine("----------------------");
                Console.WriteLine("1. Calc");
                Console.WriteLine("2. Date");
                Console.WriteLine("3. Exit");
                int mode = takeint();
                if (mode != 1 && mode != 2 && mode != 3)
                {
                    Console.WriteLine("Not a mode");
                }
                else
                {
                    return mode;
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
    class NumberCalculator
    {
        public void run(string path)
        {
            /*
            Console.WriteLine("Input radius of circle");
            string ainput = Console.ReadLine();
            double radius = Double.Parse(ainput);
            double area = Math.PI * (radius * radius);
            Console.WriteLine("The area of a circle with a radius of " + radius + " is " + area);
            */

            string ainput = AskForInput("Input operator");
            //Console.WriteLine("how many times do you want to " + ainput);
            //int ainput2 = takeint();

            //int[] numbers = new int[ainput2];
            List<int> touse = new List<int>();
            int output2 = 0;
            string output3 = "";
            makeintList(touse);

            switch (ainput) {
                case "*":
                    output2 = touse.Aggregate((result,item) => result * item);
                    break;
                case "-":
                    output2 = touse.Aggregate((result, item) => result - item);
                    break;
                case "+":
                    output2 = touse.Sum();
                    break;
                case "/":
                    output2 = touse.Aggregate((result, item) => result / item);
                    break;
                default:
                    Console.WriteLine("operator invalid");
                    break;
            }
            /*
            foreach (int a in numbers)
            {
                if (ainput == "*")
                {
                    if (output2 == 0)
                    {
                        output2 = a;
                        output3 += a;
                    }
                    else
                    {
                        output2 = output2 * a;
                        output3 += " * " + a;
                    }

                }
                else if (ainput == "+")
                {

                    if (output2 == 0)
                    {
                        output2 += a;
                        output3 += a;
                    }
                    else
                    {
                        output2 += a;
                        output3 += " + " + a;
                    }
                }
                else if (ainput == "-")
                {
                    if (output2 == 0)
                    {
                        output2 = a;
                        output3 += a;
                    }
                    else
                    {
                        output2 = output2 - a;
                        output3 += " - " + a;
                    }
                }
                else if (ainput == "/")
                {
                    if (output2 == 0)
                    {
                        output2 = a;
                        output3 += a;
                    }
                    else
                    {
                        output2 = output2 / a;
                        output3 += " / " + a;
                    }
                }
                else
                {
                    Console.WriteLine("operator invalid");
                    break;
                }
            }
            */
            foreach(int i in touse)
            {
                if(output3 == "")
                {
                    output3 += i;
                }
                else
                {
                    output3 += " "+ainput+" "+ i;
                }
            }
            string text = output3 + " = " + output2;
            Console.WriteLine(text);
            Log(path, text);
        }
        public static void makeintList(List<int> l)
        {
            bool notblank = true;
            while (notblank)
            {
                string answer = AskForInput("Please enter a number: ");
                if(answer == "")
                {
                    notblank = false;
                }
                else
                {
                    if (int.TryParse(answer, out int number))
                    {
                        l.Add(number);
                    }
                    else
                    {
                        Console.WriteLine("not a number");
                    }
                }
            }

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
        public static string AskForInput(string output)
        {
            Console.WriteLine(output);

            return Console.ReadLine();

        }
        public void Log(string path, string text)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(text);
            }
        }
    }
    class DateCalculator
    {
        public void run(string path)
        {
            DateTime inputDate = getDate();
            Console.WriteLine("number of days to add");
            int days = takeint();
            DateTime output = inputDate.AddDays(days);
            string text = days + " days from " + inputDate + " is " + output;
            Console.WriteLine(text);
            Log(path, text);
        }

        private static DateTime getDate()
        {
            while (true)
            {

                string idate = AskForInput("Enter Date");

                if (DateTime.TryParse(idate, out DateTime date))
                {
                    return date;
                }
                Console.WriteLine("{0} is not a valid date", idate);
            }

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
        public static string AskForInput(string output)
        {
            Console.WriteLine(output);

            return Console.ReadLine();

        }
        public void Log(string path, string text)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(text);
            }
        }
    }
}
