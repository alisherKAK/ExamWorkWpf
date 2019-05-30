using Newtonsoft.Json;

namespace ExamWpf.Models
{
    public class Feature
    {
        [JsonProperty("properties")]
        public FeatureProperty FeatureProperty { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}