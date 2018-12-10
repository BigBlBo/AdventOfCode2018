using AdventOfCode2018.Commons;
using AdventOfCode2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018.Days
{
    class Day07
    {
        public void Part1()
        {
            List<Step> steps = new FileRead().GetSteps("../../../Inputs/Day07.txt");

            IDictionary<string, HashSet<string>> points = new Dictionary<string, HashSet<string>>();
            IList<string> stepsSequence = new List<string>();

            foreach (Step step in steps)
            {
                if (!points.ContainsKey(step.BeforeStep))
                {
                    points[step.BeforeStep] = new HashSet<string> { };
                }

                if (!points.ContainsKey(step.AfterStep))
                {
                    points[step.AfterStep] = new HashSet<string>();
                }

                points[step.AfterStep].Add(step.BeforeStep);
            }

            HashSet<string> nextMap = new HashSet<string>();
            List<string> nextStep = new List<string>();
            while (true)
            {
                foreach (string key in points.Keys)
                {
                    if (points[key].Count == 0 && !nextMap.Contains(key))
                    {
                        nextStep.Add(key);
                        nextMap.Add(key);
                    }
                }

                if (nextStep.Count == 0)
                {
                    break;
                }

                nextStep.Sort();
                String step = nextStep[0];
                stepsSequence.Add(step);
                nextStep.RemoveAt(0);

                foreach (string key in points.Keys)
                {
                    if (points[key].Contains(step))
                    {
                        points[key].Remove(step);
                    }
                }
            }

            Console.Write("End result of day  7 (part 1) is ");
            foreach (string step in stepsSequence)
            {
                Console.Write(step); //LFMNJRTQVZCHIABKPXYEUGWDSO 
            }
            Console.WriteLine();
        }

        public void Part2()
        {
            List<Step> steps = new FileRead().GetSteps("../../../Inputs/Day07.txt");

            IDictionary<string, HashSet<string>> points = new Dictionary<string, HashSet<string>>();

            foreach (Step step in steps)
            {
                if (!points.ContainsKey(step.BeforeStep))
                {
                    points[step.BeforeStep] = new HashSet<string> { };
                }

                if (!points.ContainsKey(step.AfterStep))
                {
                    points[step.AfterStep] = new HashSet<string>();
                }

                points[step.AfterStep].Add(step.BeforeStep);
            }

            HashSet<string> nextMap = new HashSet<string>();
            List<string> nextStep = new List<string>();
            int[] timeSlots = new int[5];
            string[] stepsInProgress = new string[5];
            int currentTime = 0;

            while (true)
            {
                foreach (string key in points.Keys)
                {
                    if (points[key].Count == 0 && !nextMap.Contains(key))
                    {
                        nextStep.Add(key);
                        nextMap.Add(key);
                    }
                }

                if (nextStep.Count == 0 && stepsInProgress.All(step => step == null))
                {
                    break;
                }

                for (int index = 0; index < timeSlots.Length; index++)
                {
                    if (currentTime >= timeSlots[index] && nextStep.Count > 0)
                    {
                        nextStep.Sort();
                        stepsInProgress[index] = nextStep[0];
                        nextStep.RemoveAt(0);

                        int stepTime = 60 + stepsInProgress[index].ToCharArray()[0] - 64;
                        timeSlots[index] = currentTime + stepTime;
                    }
                }

                int nextFreeSlot = 0; int nextFreeSlotTime = int.MaxValue;
                for (int index = 0; index < timeSlots.Length; index++)
                {
                    if (timeSlots[index] > currentTime && timeSlots[index] < nextFreeSlotTime && stepsInProgress[index] != null)
                    {
                        nextFreeSlotTime = timeSlots[index]; nextFreeSlot = index;
                    }
                }

                currentTime = nextFreeSlotTime;
                if (!timeSlots.Any(time2 => time2 == currentTime))
                {
                    currentTime++;
                }

                foreach (string key in points.Keys)
                {
                    if (points[key].Contains(stepsInProgress[nextFreeSlot]))
                    {
                        points[key].Remove(stepsInProgress[nextFreeSlot]);
                    }
                }
                stepsInProgress[nextFreeSlot] = null;
            }

            Console.WriteLine("End result of day  7 (part 1) is " + timeSlots.Max());//1180 
        }
    }
}