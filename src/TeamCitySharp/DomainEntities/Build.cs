using System;
using TeamCitySharp.ModelingUtils;

namespace TeamCitySharp.DomainEntities
{
    public class Build
    {
        // --- Common with Buildsumary
        public string Id { get; set; }
        public string BuildTypeId { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string State { get; set; }
        public string WebUrl { get; set; }
        public string Href { get; set; }
        public override string ToString()
        {
            return Number;
        }

        //-- Specific to Build
        public string StatusText { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime QueuedDate { get; set; }

        //-- Other href types
        public BuildTypeSummary BuildType { get; set; }

        public Triggered Triggered { get; set; }
        public Agent Agent { get; set; }
        public ChangeWrapper Changes { get; set; }
        public BuildStatistics Statistics { get; set; }
    }

    public class BuildSumary
    {
        public BuildSumary()
        {
            Build = new ReferenceWrapper<Build>();
        }

        public string Id { get; set; }
        public string BuildTypeId { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string State { get; set; }
        public string WebUrl { get; set; }

        public string Href
        {
            get
            {
                return Build.Href;
            }
            set { Build.Href = value; }
        }

        public ReferenceWrapper<Build> Build
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return Number;
        }
    }
}