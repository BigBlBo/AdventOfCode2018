namespace AdventOfCode2018.Models
{
    class OpCodeOperation
    {
        public int[] Before { get; set; } = new int[4];
        public int[] Operation { get; set; } = new int[4];
        public int[] After { get; set; } = new int[4];
    }
}