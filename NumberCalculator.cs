using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Calculator
{
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


            switch (ainput)
            {
                case "*":
                    makeintList(touse);
                    output2 = touse.Aggregate((result, item) => result * item);
                    break;
                case "-":
                    makeintList(touse);
                    output2 = touse.Aggregate((result, item) => result - item);
                    break;
                case "+":
                    makeintList(touse);
                    output2 = touse.Sum();
                    break;
                case "/":
                    makeintList(touse);
                    output2 = touse.Aggregate((result, item) => result / item);
                    break;
                default:
                    throw new Exception("Invalid operator");
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
            foreach (int i in touse)
            {
                if (output3 == "")
                {
                    output3 += i;
                }
                else
                {
                    output3 += " " + ainput + " " + i;
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
                if (answer == "")
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
   
}

