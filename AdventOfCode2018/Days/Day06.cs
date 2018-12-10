using AdventOfCode2018.Commons;
using AdventOfCode2018.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.Days
{
    class Day06
    {
        public void Part1()
        {
            List<Coordinate> coordinates = new FileRead().GetCoordinates("../../../Inputs/Day06.txt");

            int maxX = 0; int maxY = 0;
            IDictionary<int, int> dic = new Dictionary<int, int>();
            for (int cordIndex = 0; cordIndex < coordinates.Count; cordIndex++)
            {
                if (coordinates[cordIndex].PosX > maxX) { maxX = coordinates[cordIndex].PosX; }
                if (coordinates[cordIndex].PosY > maxY) { maxY = coordinates[cordIndex].PosY; }
                dic[cordIndex] = 0;
            }

            IList<IList<IDictionary<int, int>>> grid = new List<IList<IDictionary<int, int>>>();

            for (int indexZun = 0; indexZun <= maxX; indexZun++)
            {
                List<IDictionary<int, int>> row = new List<IDictionary<int, int>>(); grid.Add(row);
                for (int indexNot = 0; indexNot <= maxY; indexNot++)
                {
                    row.Add(new Dictionary<int, int>());
                }
            }

            for (int cordIndex = 0; cordIndex < coordinates.Count; cordIndex++)
            {
                for (int indexZun = 0; indexZun <= maxX; indexZun++)
                {
                    for (int indexNot = 0; indexNot <= maxY; indexNot++)
                    {
                        int distX = Math.Abs(coordinates[cordIndex].PosX - indexZun);
                        int distY = Math.Abs(coordinates[cordIndex].PosY - indexNot);

                        grid[indexZun][indexNot][cordIndex] = distX + distY;
                    }
                }
            }

            HashSet<int> edges = new HashSet<int>();
            for (int indexZun = 0; indexZun <= maxX; indexZun++)
            {
                for (int indexNot = 0; indexNot <= maxY; indexNot++)
                {
                    List<int> minKeys = new List<int>(); int minValue = maxX * maxY;
                    foreach (int key in grid[indexZun][indexNot].Keys)
                    {
                        if (grid[indexZun][indexNot][key] < minValue)
                        {
                            minKeys.Clear(); minKeys.Add(key); minValue = grid[indexZun][indexNot][key];
                        }
                        else if (grid[indexZun][indexNot][key] == minValue)
                        {
                            minKeys.Add(key);
                        }

                    }
                    if (minKeys.Count == 1)
                    {
                        dic[minKeys[0]] = ++dic[minKeys[0]];
                        if (indexNot == 0 || indexZun == 0)
                        {
                            edges.Add(minKeys[0]);
                        }
                    }
                }
            }

            int maxArea = 0;
            for (int cordIndex = 0; cordIndex < coordinates.Count; cordIndex++)
            {
                if (!edges.Contains(cordIndex))
                {
                    if (maxArea <= dic[cordIndex]) { maxArea = dic[cordIndex]; }
                }
            }

            Console.WriteLine("End result of day 6 (part 1) is " + maxArea); //3969
        }

        public void Part2()
        {
            List<Coordinate> coordinates = new FileRead().GetCoordinates("../../../Inputs/Day06.txt");

            int maxX = 0; int maxY = 0;
            IDictionary<int, int> dic = new Dictionary<int, int>();
            for (int cordIndex = 0; cordIndex < coordinates.Count; cordIndex++)
            {
                if (coordinates[cordIndex].PosX > maxX) { maxX = coordinates[cordIndex].PosX; }
                if (coordinates[cordIndex].PosY > maxY) { maxY = coordinates[cordIndex].PosY; }
                dic[cordIndex] = 0;
            }

            IList<IList<IDictionary<int, int>>> grid = new List<IList<IDictionary<int, int>>>();

            for (int indexZun = 0; indexZun <= maxX; indexZun++)
            {
                List<IDictionary<int, int>> row = new List<IDictionary<int, int>>();
                grid.Add(row);
                for (int indexNot = 0; indexNot <= maxY; indexNot++)
                {
                    row.Add(new Dictionary<int, int>());
                }
            }

            for (int cordIndex = 0; cordIndex < coordinates.Count; cordIndex++)
            {
                for (int indexZun = 0; indexZun <= maxX; indexZun++)
                {
                    for (int indexNot = 0; indexNot <= maxY; indexNot++)
                    {
                        int distX = Math.Abs(coordinates[cordIndex].PosX - indexZun);
                        int distY = Math.Abs(coordinates[cordIndex].PosY - indexNot);

                        grid[indexZun][indexNot][cordIndex] = distX + distY;
                    }
                }
            }

            HashSet<int> edges = new HashSet<int>(); int count = 0;
            for (int indexZun = 0; indexZun <= maxX; indexZun++)
            {
                for (int indexNot = 0; indexNot <= maxY; indexNot++)
                {
                    int sum = 0;
                    foreach (int key in grid[indexZun][indexNot].Keys)
                    {
                        sum = sum + grid[indexZun][indexNot][key];

                    }

                    if (sum < 10000)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine("End result of day 6 (part 2) is " + count); //42123
        }
    }
}
