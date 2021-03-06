﻿using AdventOfCode2018.Days;
using System;
using System.Diagnostics;

namespace AdventOfCode2018
{
    class Run
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            
            Day01 day01 = new Day01(); day01.Part1(); day01.Part2();
            Day02 day02 = new Day02(); day02.Part1(); day02.Part2();
            Day03 day03 = new Day03(); day03.Part1(); day03.Part2();
            Day04 day04 = new Day04(); day04.Part1(); day04.Part2();
            Day05 day05 = new Day05(); day05.Part1(); day05.Part2();
            Day06 day06 = new Day06(); day06.Part1(); day06.Part2();
            Day07 day07 = new Day07(); day07.Part1(); day07.Part2();
            Day08 day08 = new Day08(); day08.Part1(); day08.Part2();
            Day09 day09 = new Day09(); day09.Part1(); day09.Part2();
            Day10 day10 = new Day10(); day10.Part1(); day10.Part2();
            //Day11 day11 = new Day11(); day11.Part1(); day11.Part2();
            Day12 day12 = new Day12(); day12.Part1(); day12.Part2();
            Day13 day13 = new Day13(); day13.Part1(); day13.Part2();
            Day14 day14 = new Day14(); day14.Part1(); day14.Part2();
            
            Day15 day15 = new Day15(); day15.Part1(); day15.Part2();
            Day16 day16 = new Day16(); day16.Part1(); day16.Part2();
            Day17 day17 = new Day17(); day17.Part1(); day17.Part2();

            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}