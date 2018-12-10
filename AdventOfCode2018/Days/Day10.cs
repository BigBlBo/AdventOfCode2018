using AdventOfCode2018.Commons;
using AdventOfCode2018.Models;
using System;
using System.Collections.Generic;

namespace AdventOfCode2018.Days
{
    class Day10
    {
        public void Part1()
        {
            Console.WriteLine("End result of day 10 (part 1) is ");
            this.PrintStarMessageAndReturnSeconds(true);
        }

        public void Part2()
        {
            Console.WriteLine("End result of day 10 (part 2) is " + this.PrintStarMessageAndReturnSeconds(false));
        }


        private int PrintStarMessageAndReturnSeconds(bool printMessage)
        {
            List<CoordinateWithStep> coordinateWithSteps = new FileRead().GetCoordinateWithSteps("../../../Inputs/Day10.txt");

            IDictionary<int, IDictionary<int, bool>> pointsPrevStep = null;
            int maxxPrevStep = 0; int minxPrevStep = 0;
            int minyPrevStep = 0; int maxyPrevStep = 0;
            int countSeconds = 0;

            while (true)
            {
                IDictionary<int, IDictionary<int, bool>> points = new Dictionary<int, IDictionary<int, bool>>();
                int maxx = int.MinValue; int minx = int.MaxValue; int miny = int.MaxValue; int maxy = int.MinValue;
                foreach (CoordinateWithStep coordinateWithStep in coordinateWithSteps)
                {
                    coordinateWithStep.PosX = coordinateWithStep.PosX + coordinateWithStep.StepX;
                    coordinateWithStep.PosY = coordinateWithStep.PosY + coordinateWithStep.StepY;
                    if (maxx < coordinateWithStep.PosX) { maxx = coordinateWithStep.PosX; }
                    if (maxy < coordinateWithStep.PosY) { maxy = coordinateWithStep.PosY; }
                    if (minx > coordinateWithStep.PosX) { minx = coordinateWithStep.PosX; }
                    if (miny > coordinateWithStep.PosY) { miny = coordinateWithStep.PosY; }

                    if (!points.ContainsKey(coordinateWithStep.PosX)) { points[coordinateWithStep.PosX] = new Dictionary<int, bool>(); }
                    if (!points[coordinateWithStep.PosX].ContainsKey(coordinateWithStep.PosY)) { points[coordinateWithStep.PosX][coordinateWithStep.PosY] = true; }
                }

                if ((maxyPrevStep - minyPrevStep) < (maxy - miny) && countSeconds > 0)
                {
                    if (printMessage)
                    {
                        for (int indexY = minyPrevStep; indexY <= maxyPrevStep; indexY++)
                        {
                            int xAxisIncrement = 0;
                            for (int indexX = minxPrevStep; indexX <= maxxPrevStep; indexX++)
                            {
                                if (pointsPrevStep.ContainsKey(indexX))
                                {
                                    if (pointsPrevStep[indexX].ContainsKey(indexY))
                                    {
                                        Console.Write("#");
                                    }
                                    else
                                    {
                                        Console.Write(" ");
                                    }

                                    xAxisIncrement++;
                                    if (xAxisIncrement % 6 == 0)
                                    {
                                        Console.Write("   ");
                                    }
                                }
                            }
                            Console.WriteLine();
                        }
                    }

                    break;
                }

                countSeconds++;
                pointsPrevStep = points;
                maxxPrevStep = maxx; minxPrevStep = minx;
                maxyPrevStep = maxy; minyPrevStep = miny;
            }

            return countSeconds;
        }
    }
}