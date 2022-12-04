namespace Day_4
{
    internal class Program
    {

        static List<int> BuildList(string range)
        {
            List<int> list = new List<int>();

            int begin = Convert.ToInt32(range.Split('-')[0]);
            int end = Convert.ToInt32(range.Split('-')[1]);

            for (int i = begin; i <= end; i++)
            {
                list.Add(i);
            }

            return list;

        }

        static bool Contains(string elfOne, string elfTwo)
        {
            List<int> firstGroup = BuildList(elfOne);

            List<int> secondGroup = BuildList(elfTwo);

            return firstGroup.All(x => secondGroup.Contains(x));

        }

        static bool ContainsEachOther(string elfOne, string elfTwo)
        {
            if (!Contains(elfOne, elfTwo))
            {
                return Contains(elfTwo, elfOne);
            }

            return true;
        }


        static int CountOfContains(string[] data)
        {
            int count = 0;

            foreach (var item in data)
            {
                string[] temp = item.Split(',');

                if (ContainsEachOther(temp[0], temp[1]))
                    count++;
            }

            return count;
        }




        // Második rész

        static bool Overlaps(string elfOne, string elfTwo)
        {
            List<int> firstGroup = BuildList(elfOne);

            List<int> secondGroup = BuildList(elfTwo);

            return firstGroup.Any(x => secondGroup.Contains(x));

        }

        static bool OverlapsEachOther(string elfOne, string elfTwo)
        {
            if (!Overlaps(elfOne, elfTwo))
            {
                return Overlaps(elfTwo, elfOne);
            }

            return true;
        }


        static int CountOfOverlaps(string[] data)
        {
            int count = 0;

            foreach (var item in data)
            {
                string[] temp = item.Split(',');

                if (OverlapsEachOther(temp[0], temp[1]))
                    count++;
            }

            return count;
        }

        static void Main(string[] args)
        {
            string[] data = File.ReadAllLines("input.txt");

            int containtsCount = CountOfContains(data);

            Console.WriteLine($"Contains each other: {containtsCount}");

            int overlapCount = CountOfOverlaps(data);
            Console.WriteLine($"Overlaps: {overlapCount}");
            Console.ReadLine();
        }
    }
}