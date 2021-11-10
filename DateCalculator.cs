using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Calculator
{
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
