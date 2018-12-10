using AdventOfCode2018.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.Days
{
    class Day01
    {
        public void Part1()
        {
            IDictionary<int, int> numDic = new FileRead().GetNumDic("../../../Inputs/Day01.txt");

            int sum = 0;
            foreach (int key in numDic.Keys)
            {
                sum = sum + (numDic[key] * key);
            }

            Console.WriteLine("End result of day 1 (part 1) is " + sum);
        }

        public void Part2()
        {
            IList<int> numList = new FileRead().GetNumList("../../../Inputs/Day01.txt");

            int sum = 0;
            HashSet<int> frequency = new HashSet<int> { 0 };
            int iteration = 1;
            while (true)
            {
                foreach (int num in numList)
                {
                    sum = sum + num;
                    if (frequency.Contains(sum))
                    {
                        Console.WriteLine("End result of day 1 (part 2) is " + sum + " in " + iteration + " iterations.");
                        return;
                    }
                    frequency.Add(sum);
                }
                iteration++;
            }
        }
    }
}
