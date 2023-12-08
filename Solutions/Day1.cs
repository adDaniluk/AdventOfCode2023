using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Solutions
{
    internal class Day1
    {
        IList<string> inputList = InputReader.GetInputList("day1.txt");

        public Day1()
        {
            Console.WriteLine("Result of Task1 from Day1: " + Task1(inputList));
            Console.WriteLine("Result of Task2 from Day1: " + Task2(inputList));
        }

        private int Task1(IList<string> inputList)
        {
            string startDigit = "", endDigit = "";
            int startEndNumber, counter = 0;

            foreach (string line in inputList)
            {
                foreach(char c in line)
                {
                    if (int.TryParse(c.ToString() , out int result))
                    {
                        startDigit = c.ToString();
                        break;
                    }
                }

                foreach(char c in line.Reverse())
                {
                    if (int.TryParse(c.ToString(), out int result))
                    {
                        endDigit = c.ToString();
                        break;
                    }
                }

                var stringDigits = startDigit + endDigit;
                startEndNumber = int.Parse(stringDigits);
                counter += startEndNumber;
            }
            
            return counter;
        }

        private int Task2(IList<string> inputString)
        {
            //regex -> zamiana słow na cyfry + task1
            return 0;
        }

    }
}
