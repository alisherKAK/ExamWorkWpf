using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExamWpf.Models
{
    public class EarthquakeData
    {
        [JsonProperty("features")]
        public IList<Feature> Features { get; set; }
    }
}
