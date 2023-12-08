using System.Text;

namespace AdventOfCode2023
{
    internal class InputReader
    {
        public InputReader()
        {
        }



        public static IList<string> GetInputList (string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Input/", fileName);
            List<string> list = new List<string>();

            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                while (!streamReader.EndOfStream)
                {
                    list.Add(streamReader.ReadLine());
                }
            }

            return list;
        }
    }
}
