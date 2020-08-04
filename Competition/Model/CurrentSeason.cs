using System;

namespace way2.Model
{
    public class CurrentSeason
    {
        public int id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }    
        public int currentMatchday { get; set; }
        public Winner winner { get; set; }
    }
}