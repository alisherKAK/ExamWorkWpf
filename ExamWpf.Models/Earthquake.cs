using System;

namespace ExamWpf.Models
{
    public class Earthquake
    {
        public double? Magnitude { get; set; }
        public double? Depth { get; set; }
        public string Place { get; set; }
        public string EventTime { get; set; }
    }
}
