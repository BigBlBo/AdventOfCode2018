using System;

namespace AdventOfCode2018.Models
{
    class GuardEvent
    {
        public int Minute { get; set; }
        public int Hour { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int GuardId { get; set; }
        public DateTime Date { get; set; }
        public int EventOnTime { get; set; }
        public string Line { get; set; }
    }
}