namespace AdventOfCode2023.Solutions
{
    internal class Day1
    {
        IList<string> inputList = InputReader.GetInputList("day1.txt");
        Dictionary<string, string> digitalDictionary;

        public Day1()
        {
            //Console.WriteLine("Result of Task1 from Day1: " + Task1(inputList));
            Console.WriteLine("Result of Task2 from Day1: " + Task2(inputList));
        }

        private static int Task1(IList<string> inputList)
        {
            int counter = 0;

            foreach (string line in inputList)
            {

                string startDigit = "", endDigit = "";
                int startEndNumber = 0;

                foreach (char c in line)
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
            digitalDictionary = GetDigitalDictionary();
            IList<string> updateInputString = new List<string>();

            foreach(string s in inputList)
            {
                updateInputString.Add(digitalDictionary.Aggregate(s, (current, value) => current.Replace(value.Key, value.Value)));
            }

            return Task1(updateInputString);
        }

        private static Dictionary<string, string> GetDigitalDictionary()
        {
            Dictionary<string, string> digitalDictionary = new Dictionary<string, string>();

            digitalDictionary.Add("twone", "2ne");
            digitalDictionary.Add("oneight", "1ight");
            digitalDictionary.Add("eightwo", "8wo");
            digitalDictionary.Add("nineight", "9ight");
            digitalDictionary.Add("threeight", "3ight");
            digitalDictionary.Add("fiveight", "5ight");
            digitalDictionary.Add("sevenine", "7ine");
            digitalDictionary.Add("nine", "9");
            digitalDictionary.Add("one", "1");
            digitalDictionary.Add("eight", "8");
            digitalDictionary.Add("two", "2");
            digitalDictionary.Add("three", "3");
            digitalDictionary.Add("four", "4");
            digitalDictionary.Add("five", "5");
            digitalDictionary.Add("six", "6");
            digitalDictionary.Add("seven", "7");

            return digitalDictionary;
        }

    }
}
