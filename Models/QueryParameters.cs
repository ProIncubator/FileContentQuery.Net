namespace FileContentQuery.Models
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    public class QueryParameters
    {
        [JsonProperty("dir")]
        public String Directory { get; set; }

        public String Include { get; set; }
        public String Exclude { get; set; }
        public String Match { get; set; }
    }
}