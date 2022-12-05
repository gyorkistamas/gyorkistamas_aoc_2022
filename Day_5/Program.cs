using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day_5
{
    internal class Program
    {

        static List<Stack<char>> stacks = new List<Stack<char>>();

        static void Move(int num, int from, int to)
        {
            for (int i = 0; i < num; i++)
            {
                stacks[to].Push(stacks[from].Pop());
            }
        }

        static void MoveWithoutRearrange(int num, int from, int to)
        {
            Stack<char> temp = new Stack<char>();

            for (int i = 0; i < num; i++)
            {
                temp.Push(stacks[from].Pop());
            }

            for (int i = 0; i < num; i++)
            {
                stacks[to].Push(temp.Pop());
            }
        }

        static void MoveStacks(int[,] moves)
        {
            for (int i = 0; i < moves.GetLength(0); i++)
            {
                Move(moves[i, 0], moves[i, 1] - 1, moves[i, 2] - 1);
            }
        }

        static void MoveStacksWithoutRearrange(int[,] moves)
        {
            for (int i = 0; i < moves.GetLength(0); i++)
            {
                MoveWithoutRearrange(moves[i, 0], moves[i, 1] - 1, moves[i, 2] - 1);
            }
        }

        static string GetTops()
        {
            string tops = "";

            foreach (var item in stacks)
            {
                tops += Convert.ToString(item.Peek());
            }

            return tops;
        }


        static void InitalizeStacks(int num)
        {
            for (int i = 0; i < num; i++)
            {
                stacks.Add(new Stack<char>());
            }
        }

        static void BuildStack(int num, Stack<char> chars)
        {
            while(chars.Count > 0)
            {
                stacks[num].Push(chars.Pop());
            }
        }

        static void BuildStacks(List<Stack<char>> lines)
        {
            InitalizeStacks(lines.Count);

            for (int i = 0; i < lines.Count; i++)
            {
                BuildStack(i, lines[i]);
            }
        }


        static int[,] GetMoves(string[] data)
        {

            int count = 0;
            int startindex = -1;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Length > 0 && data[i][0] == 'm')
                {
                    count++;
                    if (startindex == -1)
                    {
                        startindex = i;
                    }
                }
            }

            int[,] moves = new int[count, 3];

            int j = 0;
            for (int i = startindex; i < data.Length; i++)
            {
                string[] split = data[i].Split(' ');

                moves[j, 0] = Convert.ToInt32(split[1]);
                moves[j, 1] = Convert.ToInt32(split[3]);
                moves[j, 2] = Convert.ToInt32(split[5]);

                j++;
            }

            return moves;
        }

        static string[] Work()
        {
            string[] data = File.ReadAllLines("input.txt");

            List<string> crateLines = new List<string>();

            int i = 0;

            while (data[i][1] != '1')
            {
                crateLines.Add(data[i]);
                i++;
            }

            int numOfStacks = crateLines.Last().Where(x => char.IsLetter(x)).Count();

            List<Stack<char>> lines = new List<Stack<char>>();
            for (i = 0; i < numOfStacks; i++)
            {
                lines.Add(new Stack<char>());
            }

            for (i = 0; i < crateLines.Count; i++)
            {
                int stackIndex = 0;

                int charIndex = 1;

                while (charIndex < crateLines[i].Length)
                {
                    if (char.IsLetter(crateLines[i][charIndex]))
                    {
                        lines[stackIndex].Push(crateLines[i][charIndex]);
                    }

                    charIndex += 4;
                    stackIndex++;
                }
            }

            BuildStacks(lines);

            return data;

        }

        static void FirstPart()
        {
            string[] data = Work();
            MoveStacks(GetMoves(data));
        }

        static void SecondPart()
        {
            string[] data = Work();
            MoveStacksWithoutRearrange(GetMoves(data));
        }

        static void Main(string[] args)
        {
            // FirstPart();

            SecondPart();

            Console.WriteLine(GetTops());
            Console.ReadLine();
        }
    }
}