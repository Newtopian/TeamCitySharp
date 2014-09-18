using System.Collections.Generic;
using TeamCitySharp.Connection;

namespace TeamCitySharp.DomainEntities
{
    public class BuildWrapper
    {
        public string Count { get; set; }
        public List<BuildSumary> Build { get; set; }
        internal void SetCaller(ITeamCityCaller caller)
        {
            if (Build != null)
            {
                foreach (BuildSumary buildSumary in Build)
                {
                    buildSumary.Build._caller = caller;
                }
            }
        }
    }
}