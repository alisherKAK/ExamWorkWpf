using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExamWpf.Models
{
    public class Origin
    {
        [JsonProperty("properties")]
        public OriginProperty OriginProperty { get; set; }
    }
}