using Newtonsoft.Json;

namespace ExamWpf.Models
{
    public class FeatureProperty
    {
        [JsonProperty("mag")]
        public double? Mag { get; set; }

        [JsonProperty("place")]
        public string Place { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }
    }
}