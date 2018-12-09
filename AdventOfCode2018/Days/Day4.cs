using AdventOfCode2018.Commons;
using AdventOfCode2018.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.Days
{
    class Day4
    {
        public void Part1()
        {
            List<GuardEvent> GuardEvents = new FileRead().GetGuardEvents("../../../Inputs/Day4.txt");
            IDictionary<int, IDictionary<int, int>> guardsSleep = new Dictionary<int, IDictionary<int, int>>();
            int state = 0; int guardId = 0;

            IDictionary<int, int> guardSleepMinutes = null;
            for (int index = 0; index < GuardEvents.Count; index++)
            {
                GuardEvent guardEvent = GuardEvents[index];
                if (guardEvent.EventOnTime == 1)
                {
                    state = 1;
                    guardId = guardEvent.GuardId;
                    if (!guardsSleep.ContainsKey(guardId))
                    {
                        guardsSleep[guardId] = new Dictionary<int, int>();
                        for (int minIndex = 0; minIndex < 60; minIndex++)
                        {
                            guardsSleep[guardId][minIndex] = 0;
                        }
                    }
                    guardSleepMinutes = guardsSleep[guardId];
                }
                else if (guardEvent.EventOnTime == 2 && state == 1)
                {
                    state = 2;

                }
                else if (guardEvent.EventOnTime == 3 && state == 2)
                {
                    state = 1;
                    GuardEvent guardEventPrev = GuardEvents[index - 1];
                    for (int minIndex = guardEventPrev.Minute; minIndex < guardEvent.Minute; minIndex++)
                    {
                        guardsSleep[guardId][minIndex] = ++guardsSleep[guardId][minIndex];
                    }
                }
            }

            int max = 0; int max2 = 0; int maxId = 0; int maxMinId2 = 0;
            foreach (int guardKey in guardsSleep.Keys)
            {
                int minSum = 0; int maxMin = 0; int maxMinId = 0;
                foreach (int minKey in guardsSleep[guardKey].Keys)
                {
                    minSum += guardsSleep[guardKey][minKey];
                    if (maxMin < guardsSleep[guardKey][minKey]) { maxMin = guardsSleep[guardKey][minKey]; maxMinId = minKey; }
                }

                if (minSum > max) { maxId = guardKey; max = minSum; max2 = maxMin; maxMinId2 = maxMinId; }
            }

            guardSleepMinutes = guardsSleep[maxId];

            Console.WriteLine("End result of day 4 (part 1) is " + maxId * maxMinId2);
        }

        public void Part2()
        {
            List<GuardEvent> GuardEvents = new FileRead().GetGuardEvents("../../../Inputs/Day4.txt");
            IDictionary<int, IDictionary<int, int>> guardsSleep = new Dictionary<int, IDictionary<int, int>>();
            int state = 0; int guardId = 0;

            IDictionary<int, int> guardSleepMinutes = null;
            for (int index = 0; index < GuardEvents.Count; index++)
            {
                GuardEvent guardEvent = GuardEvents[index];
                if (guardEvent.EventOnTime == 1)
                {
                    state = 1;
                    guardId = guardEvent.GuardId;
                    if (!guardsSleep.ContainsKey(guardId))
                    {
                        guardsSleep[guardId] = new Dictionary<int, int>();
                        for (int minIndex = 0; minIndex < 60; minIndex++)
                        {
                            guardsSleep[guardId][minIndex] = 0;
                        }
                    }
                    guardSleepMinutes = guardsSleep[guardId];
                }
                else if (guardEvent.EventOnTime == 2 && state == 1)
                {
                    state = 2;

                }
                else if (guardEvent.EventOnTime == 3 && state == 2)
                {
                    state = 1;
                    GuardEvent guardEventPrev = GuardEvents[index - 1];
                    for (int minIndex = guardEventPrev.Minute; minIndex < guardEvent.Minute; minIndex++)
                    {
                        guardsSleep[guardId][minIndex] = ++guardsSleep[guardId][minIndex];
                    }
                }
            }

            int maxGuardKey = 0; int maxGuardMinKey = 0; int maxMin = 0;
            foreach (int guardKey in guardsSleep.Keys)
            {
                foreach (int minKey in guardsSleep[guardKey].Keys)
                {
                    if (maxMin < guardsSleep[guardKey][minKey]) { maxMin = guardsSleep[guardKey][minKey]; maxGuardKey = guardKey; maxGuardMinKey = minKey; }
                }
            }

            guardSleepMinutes = guardsSleep[maxGuardKey];
            Console.WriteLine("End result of day 4 (part 2) is " + maxGuardKey * maxGuardMinKey);
        }
    }
}
