using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWpf.Models
{
    public class EarthquakeDetail
    {
        [JsonProperty("properties")]
        public EarthquakeProperty EarthquakeProperty { get; set; }
    }
}
