using System;
using System.Collections.Generic;
using System.Linq;
using TeamCitySharp.Extentions;

namespace TeamCitySharp.DomainEntities
{
    public class BuildStatistics
    {
        public BuildStatistics()
        {
            this.Property = new List<Property>();
        }
        private List<Property> _property;

        public override string ToString()
        {
            return "statistics";
        }
        public List<Property> Property
        {
            get { return _property; }
            set
            {
                if (value == null)
                {
                    value = new List<Property>();
                }
                _property = value;
            }
        }

        public string Href { get; set; }
        public string BuildId { get; set; }

        public TimeSpan ArtifactsResolvingTime
        {
            get { return Property.FindDurationByName("ArtifactsResolvingTime"); }
        }
        public TimeSpan BuildDuration
        {
            get { return Property.FindDurationByName("BuildDuration"); }
        }
        public TimeSpan BuildDurationNetTime
        {
            get { return Property.FindDurationByName("BuildDurationNetTime"); }
        }
        public TimeSpan TimeSpentInQueue
        {
            get { return Property.FindDurationByName("TimeSpentInQueue"); }
        }
        //public long ArtifactsSize { get; set; }
        //public long BuildDuration { get; set; }
        //public long BuildDurationNetTime { get; set; }
        //public int BuildTestStatus { get; set; }
        //public int InspectionStatsE { get; set; }
        //public int InspectionStatsW { get; set; }
        //public int SuccessRate { get; set; }
        //public long TimeSpentInQueue { get; set; }
    }
}