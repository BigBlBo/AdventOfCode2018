using AdventOfCode2018.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.Days
{
    class Day02
    {
        public void Part1()
        {
            int two = 0; int three = 0; int twoInternal = 0; int threeInternal = 0;
            IDictionary<int, int> numDic = new Dictionary<int, int>();

            List<string> fileLines = new FileRead().GetLines("../../../Inputs/Day02.txt");

            foreach (string line in fileLines)
            {
                char[] chars = line.ToCharArray();
                for (int index = 0; index < chars.Length; index++)
                {
                    int val = (int)(chars[index] - 0);

                    if (!numDic.ContainsKey(val))
                    {
                        numDic[val] = 1;
                    }
                    else
                    {
                        int valDic = numDic[val];
                        if (valDic == 1) { twoInternal++; numDic[val] = ++valDic; }
                        else if (valDic == 2) { threeInternal++; twoInternal--; numDic[val] = ++valDic; }
                        else if (valDic == 3) { threeInternal--; numDic[val] = ++valDic; }
                    }

                }

                if (twoInternal > 0)
                {
                    two++;
                }
                if (threeInternal > 0)
                {
                    three++;
                }

                twoInternal = 0; threeInternal = 0; numDic.Clear();
            }

            Console.WriteLine("End result of day  2 (part 1) is " + two * three); //6642
        }

        public void Part2()
        {
            List<string> results = new List<string>();
            IDictionary<int, HashSet<String>> subStringDic = new Dictionary<int, HashSet<String>>();
            List<string> fileLines = new FileRead().GetLines("../../../Inputs/Day02.txt");

            foreach (string line in fileLines)
            {
                for (int index = 0; index < line.Length; index++)
                {
                    string subString = line.Remove(index, 1);

                    if (!subStringDic.ContainsKey(index))
                    {
                        subStringDic[index] = new HashSet<string> { subString };
                    }
                    else
                    {
                        if (subStringDic[index].Contains(subString))
                        {
                            results.Add(subString);
                        }
                        else
                        {
                            subStringDic[index].Add(subString);
                        }
                    }
                }
            }

            Console.WriteLine("End result of day  2 (part 2) is " + results[0]); //cvqlbidheyujgtrswxmckqnap
        }
    }
}
