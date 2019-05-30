using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExamWpf.Models
{
    public class Products
    {
        [JsonProperty("origin")]
        public IList<Origin> Origin { get; set; }
    }
}