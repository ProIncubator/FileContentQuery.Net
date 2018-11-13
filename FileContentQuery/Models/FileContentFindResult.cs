using System;
using System.Collections.Generic;
namespace FileContentQuery.Models
{
    public class FileContentFindResult
    {
        public String FileFullName { get; set; }
        public int LineNumber { get; set; }
        public IEnumerable<String> PreLines { get; set; }
        public IEnumerable<String> NextLines { get; set; }
        public String MatchPrefix { get; set; }
        public String MatchSuffix { get; set; }
        public int MatchIndex { get; set; }
        public String MatchValue { get; set; }
    }
}