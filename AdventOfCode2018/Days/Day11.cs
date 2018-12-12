using AdventOfCode2018.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.Days
{
    class Day11
    {
        public void Part1()
        {
            int input = 5791;
            int max = int.MinValue; int xCord = 0; int yCord = 0;
            IDictionary<int, IDictionary<int, int>> fuel = new Dictionary<int, IDictionary<int, int>>();
            IDictionary<int, IDictionary<int, int>> columnsAccumulators = new Dictionary<int, IDictionary<int, int>>();
            IDictionary<int, IDictionary<int, int>> points = new Dictionary<int, IDictionary<int, int>>();
            for (int indexX = 1; indexX <= 300; indexX++)
            {
                points[indexX] = new Dictionary<int, int>();
                fuel[indexX] = new Dictionary<int, int>();
                for (int indexY = 1; indexY <= 300; indexY++)
                {
                    points[indexX][indexY] = 0;
                    fuel[indexX][indexY] = 0;
                }
            }

            for (int indexX = 1; indexX <= 300; indexX++)
            {
                for (int indexY = 1; indexY <= 300; indexY++)
                {
                    if (indexX == 21 && indexY == 61)
                    {
                        int i = 0;
                    }
                    int rackId = indexX + 10;
                    int temp = rackId * indexY;
                    temp = temp + input;
                    temp = temp * rackId;
                    temp = (temp / 100) % 10;
                    temp = temp - 5;
                    //Console.Write(temp + " "); 
                    fuel[indexX][indexY] = temp;

                    for (int areaX = -2; areaX <= 0; areaX++)
                    {
                        if (points.ContainsKey(indexX + areaX))
                        {
                            for (int areaY = -2; areaY <= 0; areaY++)
                            {
                                if (points[indexX + areaX].ContainsKey(indexY + areaY))
                                {
                                    points[indexX + areaX][indexY + areaY] = points[indexX + areaX][indexY + areaY] + temp;
                                }
                            }
                        }
                    }
                }
            }

            for (int indexX = 1; indexX <= 298; indexX++)
            {
                for (int indexY = 1; indexY <= 298; indexY++)
                {
                    if (max < points[indexX][indexY]) { max = points[indexX][indexY]; xCord = indexX; yCord = indexY; }
                }
            }

            Console.WriteLine("End result of day 11 (part 1) is " + xCord + "," + yCord);
        }

        public void Part2()
        {
            int input = 5791;
            int max = int.MinValue; int xCord = 0; int yCord = 0; int size = 0;
            IDictionary<int, IDictionary<int, int>> fuel = new Dictionary<int, IDictionary<int, int>>();
            IDictionary<int, IDictionary<int, int>> columnsAccumulators = new Dictionary<int, IDictionary<int, int>>();
            Dictionary<int, IDictionary<int, IDictionary<int, int>>> points = new Dictionary<int, IDictionary<int, IDictionary<int, int>>>();
            for (int indexX = 1; indexX <= 300; indexX++)
            {
                points[indexX] = new Dictionary<int, IDictionary<int, int>>();
                fuel[indexX] = new Dictionary<int, int>();
                columnsAccumulators[indexX] = new Dictionary<int, int>();
                for (int indexY = 1; indexY <= 300; indexY++)
                {
                    columnsAccumulators[indexX][indexY] = 0;
                    points[indexX][indexY] = new Dictionary<int, int>();
                    fuel[indexX][indexY] = 0;
                }
            }

            for (int indexX = 1; indexX <= 300; indexX++)
            {
                for (int indexY = 1; indexY <= 300; indexY++)
                {
                    int rackId = indexX + 10;
                    int temp = rackId * indexY;
                    temp = temp + input;
                    temp = temp * rackId;
                    temp = (temp / 100) % 10;
                    temp = temp - 5;

                    fuel[indexX][indexY] = temp;
                }
            }

            for (int indexX = 1; indexX <= 300; indexX++)
            {
                for (int indexY = 1; indexY <= 300; indexY++)
                {
                    int squareMaxSize = 301 - Math.Max(indexX, indexY);
                    int prevSquareValue = 0; int thisSquareSum = 0;
                    for(int squareIndex = 1; squareIndex <= squareMaxSize; squareIndex++)
                    {
                        for(int area = 0; area < squareIndex-1; area++)
                        {
                            thisSquareSum += fuel[indexX + area][indexY + squareIndex -1 ];
                            thisSquareSum += fuel[indexX + squareIndex - 1][indexY + area];
                        }

                        thisSquareSum += fuel[squareIndex][squareIndex];
                        thisSquareSum += prevSquareValue;
                        points[indexX][indexY][squareIndex] = thisSquareSum;
                        prevSquareValue = thisSquareSum; thisSquareSum = 0;
                    }
                }
            }


            for (int indexX = 1; indexX <= 300; indexX++)
            {
                for (int indexY = 1; indexY <= 300; indexY++)
                {
                    foreach(int squareSize in points[indexX][indexY].Keys)
                    if(max < points[indexX][indexY][squareSize])
                    {
                        max = points[indexX][indexY][squareSize];
                        xCord = indexX; yCord = indexY;
                        size = squareSize;
                    }
                }
            }
            int sum = 0;
            for (int indexX = 1; indexX <= size; indexX++)
            {
                for (int indexY = 1; indexY <= size; indexY++)
                {
                    Console.Write(fuel[xCord + indexY - 1][xCord + indexX - 1] + ", ");
                    sum += fuel[xCord + indexY - 1][xCord + indexX - 1];
                }
                Console.WriteLine();
            }
            Console.WriteLine(sum);

            Console.WriteLine("End result of day 11 (part 1) is " + xCord + "," + yCord + "," + size);
        }
    }
}