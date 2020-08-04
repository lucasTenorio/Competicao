using System.Collections.Generic;

namespace way2.Model
{
    public class Standings
    {
        public string stage { get; set; }
        public string type { get; set; }
        public string group { get; set; }
        public List<table> table { get; set; }
    }
}