using System.Collections.Generic;

namespace AdventOfCode2018.Models
{
    class TreeNode
    {
        public List<int> Metadata { get; set; } = new List<int>();
        public List<TreeNode> Nodes { get; set; } = new List<TreeNode>();
    }
}