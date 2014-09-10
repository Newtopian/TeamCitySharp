using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IChanges
    {
        List<Change> All();
        Change ByChangeId(string id);
        Change ByVersion(string version);
        Change LastChangeDetailByBuildConfigId(string buildConfigId);
        List<Change> ByBuildConfigId(string buildConfigId);
    }
}