using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberCalculator n = new NumberCalculator();
            DateCalculator d = new DateCalculator();
            bool exit = false;
            string answer = "";
            
            welcome();
            while (!exit)
            {
                int mode = askFormode();
                switch (mode) {
                    case 1:
                        n.run();
                        break;
                    case 2:
                        d.run();
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
                if(mode != 1 && mode != 2 && mode != 3)
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
        public  void run()
        {
            /*
            Console.WriteLine("Input radius of circle");
            string ainput = Console.ReadLine();
            double radius = Double.Parse(ainput);
            double area = Math.PI * (radius * radius);
            Console.WriteLine("The area of a circle with a radius of " + radius + " is " + area);
            */

            string ainput = AskForInput("Input operator");
            Console.WriteLine("how many times do you want to " + ainput);
            int ainput2 = takeint();

            int[] numbers = new int[ainput2];
            int output2 = 0;
            string output3 = "";
            for (int i = 0; i < ainput2; i++)
            {
                numbers[i] = takeint();
            }

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
            Console.WriteLine(output3 + " = " + output2);
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
    }
    class DateCalculator
    {
        public void run()
        {
            DateTime inputDate = getDate();
            Console.WriteLine("number of days to add");
            int days = takeint();
            DateTime output = inputDate.AddDays(days);
            Console.WriteLine("{0} days from {1} is {2}", days, inputDate, output);
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
    }
}
