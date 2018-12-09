using AdventOfCode2018.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.Days
{
    class Day5
    {
        public void Part1()
        {
            List<string> lines = new FileRead().GetLines("../../../Inputs/Day5.txt");

            for (int index = 0; index < lines[0].Length - 1; index++)
            {
                int value = lines[0][index] - 0;
                int valueNext = lines[0][index + 1] - 0;

                if ((value - valueNext) == 32 || (valueNext - value) == 32)
                {
                    lines[0] = lines[0].Remove(index, 2);
                    if (index >= 1) { index = index - 2; }
                }
            }

            Console.WriteLine("End result of day 5 (part 1) is " + lines[0].Length); // 9462
        }

        public void Part2()
        {
            List<string> lines = new FileRead().GetLines("../../../Inputs/Day5.txt");

            int minLength = lines[0].Length;

            for (int indexChar = 65; indexChar < 97; indexChar++)
            {
                string line = lines[0];
                string bigLetter = ((char)indexChar).ToString();
                string smallLetter = ((char)(indexChar + 32)).ToString();
                line = line.Replace(bigLetter, "");
                line = line.Replace(smallLetter, "");


                for (int index = 0; index < line.Length - 1; index++)
                {
                    int value = line[index] - 0;
                    int valueNext = line[index + 1] - 0;

                    if ((value - valueNext) == 32 || (valueNext - value) == 32)
                    {
                        line = line.Remove(index, 2);
                        if (index >= 1) { index = index - 2; }
                    }
                }

                if (line.Length < minLength) { minLength = line.Length; }
            }

            Console.WriteLine("End result of day 5 (part 1) is " + minLength); // 4952
        }
    }
}
