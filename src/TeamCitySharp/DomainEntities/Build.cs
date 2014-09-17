using System;

namespace TeamCitySharp.DomainEntities
{
    public class Build : BuildSumary
    {
        public string StatusText { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public DateTime QueuedDate { get; set; }

        public Triggered Triggered { get; set; } 


        public BuildConfig BuildConfig { get; set; }
        public Agent Agent { get; set;}
        public ChangeWrapper Changes { get; set; }
        public BuildStatistics Statistics { get; set; }

        
    }

    public class BuildSumary
    {
        public string Id { get; set; }
        public string BuildTypeId { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string State { get; set; }
        public string Href { get; set; }
        public string WebUrl { get; set; }

        public override string ToString()
        {
            return Number;
        }
    }
}