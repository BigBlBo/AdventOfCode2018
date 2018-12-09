using AdventOfCode2018.Days;
using System;
using System.Diagnostics;

namespace AdventOfCode2018
{
    class Run
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            /*
            Day1 day1 = new Day1(); day1.Part1(); day1.Part2();
            Day2 day2 = new Day2(); day2.Part1(); day2.Part2();
            Day3 day3 = new Day3(); day3.Part1(); day3.Part2();
            
            Day4 day4 = new Day4(); day4.Part1(); day4.Part2();
            Day5 day5 = new Day5(); day5.Part1(); day5.Part2();
            Day6 day6 = new Day6(); day6.Part1(); day6.Part2();
            Day7 day7 = new Day7(); day7.Part1(); day7.Part2();
            
            Day8 day8 = new Day8(); day8.Part1(); day8.Part2();
            */
            Day9 day9 = new Day9();
            day9.Part1(); Console.WriteLine(sw.ElapsedMilliseconds);
            day9.Part2();

            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}