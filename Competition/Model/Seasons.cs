using System;

namespace way2.Model
{
    public class Seasons
    {
        public int id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public String currentMatchday { get; set; }
        public Winner winner { get; set; }
    }
}