using Newtonsoft.Json;

namespace ExamWpf.Models
{
    public class EarthquakeProperty
    {
        [JsonProperty("products")]
        public Products Products { get;set; }
    }
}