using AdventOfCode2018.Commons;
using AdventOfCode2018.Models;
using System;
using System.Collections.Generic;

namespace AdventOfCode2018.Days
{
    class Day12
    {
        public void Part1()
        {
            Console.WriteLine("End result of day  8 (part 1) is " + GrowPlants(20, false));
        }

        public void Part2()
        {
            Console.WriteLine("End result of day  8 (part 2) is " + GrowPlants(50000000000L, true));
        }

        private long GrowPlants(long generations, bool stopWhenRepeated)
        {
            string curentGeneration = "#.#..#..###.###.#..###.#####...########.#...#####...##.#....#.####.#.#..#..#.#..###...#..#.#....##.";
            List<PlantGrowPattern> plantGrowPatterns = new FileRead().GetPlantGrowPatterns("../../../Inputs/Day12.txt");
            string addToNewGeneration = ".....";
            long sumPrev = 0;
            long sum = CountPlantPots(curentGeneration.ToCharArray(), 0);
            long prevNowDiff = 0;

            for (long index = 1; index <= generations; index++)
            { 
                char[] charArrayNewGeneration = new String('.', curentGeneration.Length + 10).ToCharArray();
                char[] charArrayCurentGeneration = curentGeneration.
                        Insert(curentGeneration.Length-1, addToNewGeneration).
                            Insert(0, addToNewGeneration).ToCharArray();

                foreach (PlantGrowPattern plantGrowPattern in plantGrowPatterns)
                {
                    char[] charArrayPattern = plantGrowPattern.PatternToGrow.ToCharArray();
                    for (int curentGenerationIndex = 0; curentGenerationIndex < charArrayCurentGeneration.Length; curentGenerationIndex++)
                    {
                        bool match = true;
                        for (int patternIndex = 0; patternIndex < charArrayPattern.Length; patternIndex++)
                        {
                            if (curentGenerationIndex + patternIndex > charArrayCurentGeneration.Length - 1 || 
                                    charArrayCurentGeneration[curentGenerationIndex + patternIndex] != charArrayPattern[patternIndex])
                            {
                                match = false; break;
                            }
                        }

                        if (match)
                        {
                            charArrayNewGeneration[curentGenerationIndex + 2] = plantGrowPattern.GrowResult.ToCharArray()[0];
                        }
                    }
                }

                sum = CountPlantPots(charArrayNewGeneration, index);
                curentGeneration = new string(charArrayNewGeneration);
                if (stopWhenRepeated && prevNowDiff == (sum - sumPrev))
                {
                    return ((generations - index) * prevNowDiff) + sum;
                }

                prevNowDiff = sum - sumPrev;
                sumPrev = sum;
            }

            return sum;
        }

        private long CountPlantPots(char[] curentGeneration, long generationInProgress)
        {
            long sum = 0;
            long untilZeroPosition = generationInProgress * 5;
            for (int index = 0; index < curentGeneration.Length; index++)
            {
                if (curentGeneration[index] == '#')
                {
                    sum += index - untilZeroPosition;
                }
            }

            return sum;
        }
    }
}