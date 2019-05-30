using Newtonsoft.Json;
using System;

namespace ExamWpf.Models
{
    public class OriginProperty
    {
        [JsonProperty("depth")]
        public double? Depth { get; set; }
        [JsonProperty("eventtime")]
        public DateTime EventTime { get; set; }
    }
}