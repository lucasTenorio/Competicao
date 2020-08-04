using System.Collections.Generic;

namespace way2.Model
{
    public class CompetitionStandings
    {
        public Filters filters { get; set; }
        public Competition competition { get; set; }
        public Seasons seasons { get; set; }
        public List<Standings> standings { get; set; }
        public string message { get; set; }
        public int error { get; set; }


    }
}