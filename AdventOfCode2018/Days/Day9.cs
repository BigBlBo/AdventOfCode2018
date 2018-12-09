using System;
using System.Collections.Generic;

namespace AdventOfCode2018.Days
{
    class Day9
    {
        public void Part1()
        {
            int numberOfElfs = 465; int lastMarble = 71498;

            long max = this.GetMaxScore(this.SlowArrayImplementation(numberOfElfs, lastMarble));

            Console.WriteLine("End result of day 9 (part 1) is " + max);
        }

        public void Part2()
        {
            int numberOfElfs = 465; int lastMarble = 7149800;

            long max = this.GetMaxScore(this.FastLinkedListImplementation(numberOfElfs, lastMarble));

            Console.WriteLine("End result of day 9 (part 2) is " + max);
        }

        private IDictionary<int, long> SlowArrayImplementation(int numberOfElfs, int lastMarble)
        {
            IDictionary<int, long> scores = this.GetInitScores(numberOfElfs);
            IList<int> marbleList = new List<int>();
            int elfIndex = 0; int curentMarbleIndex = 0;

            for (int marbleIndex = 0; marbleIndex < lastMarble; marbleIndex++)
            {
                elfIndex = elfIndex % numberOfElfs == 0 ? 1 : ++elfIndex;
                if (marbleIndex % 23 == 0 && marbleIndex != 0)
                {
                    long newScore = scores[elfIndex] + marbleIndex;

                    for (int index = 0; index < 7; index++)
                    {
                        curentMarbleIndex = curentMarbleIndex == 0 ? marbleList.Count - 1 : curentMarbleIndex - 1;
                    }

                    scores[elfIndex] = newScore + marbleList[curentMarbleIndex];
                    marbleList.RemoveAt(curentMarbleIndex);
                    continue;
                }

                if (marbleIndex <= 1) { marbleList.Add(marbleIndex); curentMarbleIndex = marbleList.Count - 1; }

                else if (curentMarbleIndex == marbleList.Count - 1) { curentMarbleIndex = 1; marbleList.Insert(curentMarbleIndex, marbleIndex); }
                else if (curentMarbleIndex == marbleList.Count - 2) { marbleList.Add(marbleIndex); curentMarbleIndex = marbleList.Count - 1; }
                else { curentMarbleIndex = curentMarbleIndex + 2; marbleList.Insert(curentMarbleIndex, marbleIndex); }
            }

            return scores;
        }

        private IDictionary<int, long> FastLinkedListImplementation(int numberOfElfs, int lastMarble)
        {
            IDictionary<int, long> scores = this.GetInitScores(numberOfElfs);
            LinkedList<int> LL = new LinkedList<int>();
            LinkedListNode<int> curentNode = null;
            int elfIndex = 0;

            for (int marbleIndex = 0; marbleIndex < lastMarble; marbleIndex++)
            {
                elfIndex = elfIndex % numberOfElfs == 0 ? 1 : ++elfIndex;
                if (marbleIndex % 23 == 0 && marbleIndex != 0)
                {
                    long newScore = scores[elfIndex] + marbleIndex;

                    for (int index = 0; index < 6; index++)
                    {
                        curentNode = curentNode == LL.First ? LL.Last : curentNode.Previous;
                    }

                    LinkedListNode<int> toRemove = curentNode != LL.First ? curentNode.Previous : LL.Last;
                    scores[elfIndex] = newScore + toRemove.Value;
                    LL.Remove(toRemove);
                    continue;
                }

                if (marbleIndex <= 1) { curentNode = LL.AddLast(marbleIndex); }

                else if (curentNode == LL.Last) {  curentNode = LL.First; curentNode = LL.AddAfter(curentNode, marbleIndex); }
                else if (curentNode == LL.Last.Previous) { curentNode = LL.AddLast(marbleIndex); }
                else { curentNode = curentNode.Next; curentNode = LL.AddAfter(curentNode, marbleIndex); }
            }

            return scores;
        }

        private long GetMaxScore(IDictionary<int, long> scores)
        {
            long max = 0;
            foreach (int key in scores.Keys)
            {
                if (max < scores[key]) { max = scores[key]; }
            }

            return max;
        }

        private IDictionary<int, long> GetInitScores(int numberOfElfs)
        {
            IDictionary<int, long> scores = new Dictionary<int, long>();
            for (int index = 1; index <= numberOfElfs; index++)
            {
                scores[index] = 0;
            }

            return scores;
        }
    }
}