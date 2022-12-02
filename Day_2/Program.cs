namespace Day_2
{
    internal class Program
    {
        

        static Dictionary<string, int> Shape = new Dictionary<string, int>()
        {
            {"X", 1 },
            {"Y", 2},
            {"Z", 3},
        };


        static int GetResult(string shapes) => shapes switch
        {
            "AX" or "BY" or "CZ" => 3,
            "AY" or "BZ" or "CX" => 6,
            _ => 0

        };

        static string GetStepToDraw(string shape) => shape switch
        {
            "A" => "X",
            "B" => "Y",
            "C" => "Z",
        };

        static string GetStepWin(string shape) => shape switch
        {
            "A" => "Y",
            "B" => "Z",
            "C" => "X"
        };

        static string GetStepLose(string shape) => shape switch
        {
            "A" => "Z",
            "B" => "X",
            "C" => "Y"
        };

        static void Main(string[] args)
        {

            string[] data = File.ReadAllLines("input.txt");

            int sum = 0;

            foreach (var item in data)
            {
                string move = Convert.ToString(item[0])  + Convert.ToString(item[2]);

                sum += Shape[Convert.ToString(move[1])];

                sum += GetResult(move);
            }

            Console.ReadLine();

            int sum2 = 0;

            foreach (var item in data)
            {
                string move = Convert.ToString(item[0]) + Convert.ToString(item[2]);

                string shapeToShow = Convert.ToString(move[1]) switch
                {
                    "X" => GetStepLose(Convert.ToString(move[0])),
                    "Y" => GetStepToDraw(Convert.ToString(move[0])),
                    "Z" => GetStepWin(Convert.ToString(move[0])),
                    _ => ""
                };

                sum2 += Shape[shapeToShow];

                string actualRound = Convert.ToString(move[0]) + shapeToShow;

                sum2 += GetResult(actualRound);
            }


            Console.WriteLine(sum2);
            Console.ReadLine();
        }
    }
}