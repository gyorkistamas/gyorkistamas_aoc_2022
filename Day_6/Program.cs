namespace Day_6
{
    internal class Program
    {

        static bool IsDifferent(string chars)
        {
            HashSet<char> temp = new HashSet<char>();
            foreach (var item in chars)
            {
                temp.Add(item);
            }

            return temp.Count == chars.Length;
        }

        static int GetFirstDifferent(string chars)
        {
            int diff = 0;

            for (int i = 0; i < chars.Length - 4; i++)
            {
                if (IsDifferent(chars.Substring(i, 4)))
                {
                    Console.WriteLine(chars.Substring(i, 4));
                    diff = (i + 4);
                    break;
                }
            }

            return diff;
        }

        static int GetFirstMessage(string chars)
        {
            int diff = 0;

            for (int i = 0; i < chars.Length - 4; i++)
            {
                if (IsDifferent(chars.Substring(i, 14)))
                {
                    Console.WriteLine(chars.Substring(i, 14));
                    diff = (i + 14);
                    break;
                }
            }

            return diff;
        }

        static string ReadCode()
        {
            StreamReader sr = new StreamReader("input.txt");

            string line = sr.ReadLine();

            sr.Close();

            return line;
        }

        static void Main(string[] args)
        {
            string code = ReadCode();
            Console.WriteLine(GetFirstDifferent(code));
            Console.WriteLine(GetFirstMessage(code));
            Console.ReadLine();
        }
    }
}