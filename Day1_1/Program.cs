namespace Day1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Első rész
            List<int> list = new List<int>();

            string[] data = File.ReadAllLines("input.txt");

            int i = 0;
            while(i < data.Length)
            {
                int sum = 0;

                while (i < data.Length && data[i] != "")
                {
                    sum += Convert.ToInt32(data[i]);
                    i++;
                }
                i++;
                list.Add(sum);
            }


            Console.WriteLine(list.Max());
            Console.ReadLine();

            // Második rész

            list.Sort();
            list.Reverse();
            int sumOfThree = list.Take(3).Sum();
            Console.WriteLine(sumOfThree);
            Console.ReadLine();
        }
    }
}