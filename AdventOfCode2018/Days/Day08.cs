using AdventOfCode2018.Commons;
using AdventOfCode2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2018.Days
{
    class Day08
    {
        public void Part1()
        {
            List<string> fileLines = new FileRead().GetLines("../../../Inputs/Day08.txt");
            var numbers = fileLines[0].Split(' ').Select(int.Parse).ToList();
            var i = 0;
            TreeNode treeNode = ReadNode(numbers, ref i);

            Console.WriteLine("End result of day 8 (part 1) is " + this.Sum(treeNode));
        }

        public void Part2()
        {
            List<string> fileLines = new FileRead().GetLines("../../../Inputs/Day08.txt");
            var numbers = fileLines[0].Split(' ').Select(int.Parse).ToList();
            var i = 0;
            TreeNode treeNode = ReadNode(numbers, ref i);

            Console.WriteLine("End result of day 8 (part 2) is " + this.Value(treeNode));
        }

        private static TreeNode ReadNode(List<int> numbers, ref int i)
        {
            var node = new TreeNode();
            var children = numbers[i++];
            var metadata = numbers[i++];
            for (int j = 0; j < children; j++)
            {
                node.Nodes.Add(ReadNode(numbers, ref i));
            }

            for (int j = 0; j < metadata; j++)
            {
                node.Metadata.Add(numbers[i++]);
            }

            return node;
        }

        private int Sum(TreeNode treeNode)
        {
            return treeNode.Metadata.Sum() + treeNode.Nodes.Sum(x => this.Sum(x));
        }

        private int Value(TreeNode treeNode)
        {
            if (!treeNode.Nodes.Any())
            {
                return treeNode.Metadata.Sum();
            }

            var value = 0;
            foreach (var m in treeNode.Metadata)
            {
                if (m <= treeNode.Nodes.Count)
                {
                    value += this.Value(treeNode.Nodes[m - 1]);
                }
            }

            return value;
        }
    }
}