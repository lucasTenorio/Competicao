using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace way2.Model
{
    public class Competition
    {
        public int id{get;set;}
        public Area area{get;set;}
        public string name { get; set; }
        public string code { get; set; }
        public string emblemUrl { get; set; }
        public string plan { get; set; }
        public DateTime lastUpdate { get; set; }
    }

}