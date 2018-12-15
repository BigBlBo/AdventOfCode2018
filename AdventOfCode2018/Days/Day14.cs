using System;
using System.Collections.Generic;

namespace AdventOfCode2018.Days
{
    class Day14
    {
        public void Part1()
        {
            int input = 360781;
            List<int> recipes = GenerateRecipes(input, 1);
            Console.Write("End result of day 14 (part 1) is ");
            for(int index = recipes.Count - 10; index < recipes.Count; index++)
            {
                Console.Write(recipes[index]);
            }
            Console.WriteLine(); //6521571010
        }

        public void Part2()
        {
            int input = 360781;
            List<int> recipes = GenerateRecipes(input, 2);
            Console.WriteLine("End result of day 14 (part 2) is " + (recipes.Count - input.ToString().Length));  //20262967
        }

        public List<int> GenerateRecipes(int input, int part)
        {
            int inputLength = input.ToString().Length;
            int firstElfPos = 0; int secondElfPos = 1;
            List<int> recipes = new List<int> { 3, 7, 1, 0 };
            if (part != 1 && part != 2) { throw new Exception("Wrong mode"); }
            while (true)
            {
                int nextRecipeScore = recipes[firstElfPos] + recipes[secondElfPos];
                char[] nums = nextRecipeScore.ToString().ToCharArray();
                for (int index = 0; index < nextRecipeScore.ToString().Length; index++)
                {
                    recipes.Add(int.Parse(nums[index].ToString()));
                    if (part == 2 && recipes.Count >= inputLength)
                    {
                        int recipeSequence = 0;
                        for (int indexSequence = 0; indexSequence < inputLength; indexSequence++)
                        {
                            recipeSequence += recipes[recipes.Count - 1 - indexSequence] * (int)Math.Pow(10, indexSequence);
                        }
                        if (recipeSequence == input)
                        {
                            return recipes;
                        }
                    }
                    else if (part == 1 && recipes.Count == input + 10)
                    {
                        return recipes;
                    }
                }
                firstElfPos = GetNextElfPosition(firstElfPos, recipes);
                secondElfPos = GetNextElfPosition(secondElfPos, recipes);
            }
        }

        private int GetNextElfPosition(int elfPos, List<int> recipes)
        {
            int recipeLength = recipes.Count;
            int movesFoward = recipes[elfPos] + 1;
            int movesAfterLoops = movesFoward % recipeLength;

            if(elfPos + movesAfterLoops <= recipeLength - 1)
            {
                return elfPos + movesAfterLoops;
            }
            else
            {
                return movesAfterLoops - (recipeLength - 1 - elfPos) - 1;
            }
        }
    }
}