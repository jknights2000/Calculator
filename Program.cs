using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            string answer = "";
            
            welcome();
            while (!exit)
            {
                string mode = askFormode();
                Console.WriteLine(mode);
                switch (mode) {
                    case "1": 
                        calc();
                        break;
                    case "2":
                        date();
                        break;

                }

                exit = askForexit(exit,answer);
        
            }
           
           




        }

        private static void date()
        {
            DateTime inputDate = getDate();
            Console.WriteLine("number of days to add");
            int days = takeint();
            DateTime output = inputDate.AddDays(days);
            Console.WriteLine("{0} days from {1} is {2}",days,inputDate,output);
        }

        private static DateTime getDate()
        {
            bool isvaliddate = false;
            DateTime date = new DateTime();
            while (!isvaliddate)
            {
                Console.WriteLine("Enter Date");
                string idate = Console.ReadLine();
                isvaliddate = DateTime.TryParse(idate, out date);
                if (!isvaliddate)
                {
                    Console.WriteLine("{0} is not a valid date", idate);
                }
            }
            return date;
        }

        private static string askFormode()
        {
            string mode = " ";
            while (mode != "1" && mode != "2")
            {
                Console.WriteLine("what mode you want");
                Console.WriteLine("----------------------");
                Console.WriteLine("1. Calc");
                Console.WriteLine("2. Date");
                mode = Console.ReadLine();
            }
            return mode;
        }

        private static void welcome()
        {
            Console.WriteLine("Welcome to Calculator!");
            Console.WriteLine("----------------------");
        }

        private static bool askForexit(bool exit, string answer)
        {
            while (answer != "y" && answer != "n")
            {
                Console.WriteLine("Want to exit y/n");
                answer = Console.ReadLine();
            }
            if (answer == "y")
            {
                exit = true;
            }
            answer = "";
            return exit;
        }

        public static int takeint ()
        {
            bool valid = false;
            int number = 0;
            while (!valid)
            {
                Console.WriteLine("Please enter a number: ");
                string answer = Console.ReadLine();
                if (int.TryParse(answer, out number))
                {
                    number = int.Parse(answer);
                    valid = true;
                }
                else
                {
                    Console.WriteLine("not a number");
                }
            }
            return number;
        }
        public static void calc()
        {
            /*
            Console.WriteLine("Input radius of circle");
            string ainput = Console.ReadLine();
            double radius = Double.Parse(ainput);
            double area = Math.PI * (radius * radius);
            Console.WriteLine("The area of a circle with a radius of " + radius + " is " + area);
            */

            Console.WriteLine("Input operator");
            string ainput = Console.ReadLine();
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
    }
}
