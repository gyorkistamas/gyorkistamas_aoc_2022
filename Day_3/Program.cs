namespace Day_3
{
    internal class Program
    {
        static Dictionary<string, int> Weights = new Dictionary<string, int>();

        static void BuildWeights()
        {

            char[] lowercases = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            char[] uppercases = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            int i = 1;

            foreach (var item in lowercases)
            {
                Weights.Add(Convert.ToString(item), i);
                i++;
            }

            foreach (var item in uppercases)
            {
                Weights.Add(Convert.ToString(item), i);
                i++;
            }
        }

        static string FindDuplicate(string comp1, string comp2)
        {
            foreach (var item in comp1)
            {
                if (comp2.Contains(item))
                {
                    return Convert.ToString(item);
                }
            }

            return "";
        }

        static string FindTruplicate(string sack1, string sack2, string sack3)
        {
            foreach (var item in sack1) 
            {
                if (sack2.Contains(item) && sack3.Contains(item))
                {
                    return Convert.ToString(item);
                }
            }

            return "";
        }

        static string[] Divide(string sack)
        {
            int length = sack.Length / 2;

            string[] sub = new string[2];
            sub[0] = sack.Substring(0, length);
            sub[1] = sack.Substring(length, length);

            return sub;
        }

        static List<string> GetSacks()
        {
            return File.ReadAllLines("input.txt").ToList<string>();
        }

        static void Main(string[] args)
        {
            // Első rész
            BuildWeights();
            List<string> sacks = GetSacks();

            int sum = 0;

            foreach (var sack in sacks)
            {
                string[] splitted = Divide(sack);

                sum += Weights[FindDuplicate(splitted[0], splitted[1])];
            }

            Console.WriteLine(sum);
            Console.ReadLine();

            // Második rész

            int sum2 = 0;

            int i = 0;
            while(i < sacks.Count)
            {

                string dup = FindTruplicate(sacks[i], sacks[i + 1], sacks[i + 2]);

                sum2 += Weights[dup];

                i += 3;
            }

            Console.WriteLine(sum2);
            Console.ReadLine();
        }
    }
}