using System;
using System.Collections.Generic;
using System.Linq;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    internal class Builds : IBuilds
    {
        private readonly TeamCityCaller _caller;

        internal Builds(TeamCityCaller caller)
        {
            _caller = caller;
            
        }

        public List<BuildSumary> ByBuildLocator(BuildLocator locator)
        {
            var buildWrapper = _caller.GetFormat<BuildWrapper>("/app/rest/builds?locator={0}", locator);
            if (int.Parse(buildWrapper.Count) > 0)
            {
                return buildWrapper.Build;
            }
            return new List<BuildSumary>();
        }

        public Build ById(String id)
        {
            var build = _caller.GetFormat<Build>("/app/rest/builds/id:{0}", id);

            return build;
        }

        public Build GetDetailedBuild(BuildSumary buildSumary)
        {
            var build = _caller.GetFormat<Build>("/app/rest/builds/id:{0}", buildSumary.Id);

            return build;
        }

        public BuildStatistics GetStatisticsForBuild(string buildId)
        {
            var stats = _caller.GetFormat<BuildStatistics>("/app/rest/builds/id:{0}/statistics", buildId);
            stats.BuildId = buildId;
            
            return stats;
        }
        public BuildStatistics GetStatisticsForBuild(BuildSumary build)
        {
            BuildStatistics stats = GetStatisticsForBuild(build.Id);
            stats.Href = build.Href + "/statistics";
            return stats;
        }

        public BuildSumary LastBuildByAgent(string agentName)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(
                agentName: agentName,
                maxResults: 1
                                            )).SingleOrDefault();
        }

        public void Add2QueueBuildByBuildConfigId(string buildConfigId)
        {
            _caller.GetFormat("/action.html?add2Queue={0}", buildConfigId);
        }

        public List<BuildSumary> SuccessfulBuildsByBuildConfigId(string buildConfigId)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    status: BuildStatus.SUCCESS
                                            ));
        }

        public BuildSumary LastSuccessfulBuildByBuildConfigId(string buildConfigId)
        {
            var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          status: BuildStatus.SUCCESS,
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new Build();
        }

        public List<BuildSumary> FailedBuildsByBuildConfigId(string buildConfigId)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    status: BuildStatus.FAILURE
                                            ));
        }

        public BuildSumary LastFailedBuildByBuildConfigId(string buildConfigId)
        {
            var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          status: BuildStatus.FAILURE,
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new Build();
        }

        public BuildSumary LastBuildByBuildConfigId(string buildConfigId)
        {
            var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new Build();
        }

        public List<BuildSumary> ErrorBuildsByBuildConfigId(string buildConfigId)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    status: BuildStatus.ERROR
                                            ));
        }

        public BuildSumary LastErrorBuildByBuildConfigId(string buildConfigId)
        {
            var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          status: BuildStatus.ERROR,
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new Build();
        }

        public List<BuildSumary> ByBuildConfigId(string buildConfigId)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId)
                                            ));
        }

        public List<BuildSumary> ByConfigIdAndTag(string buildConfigId, string tag)
        {
            return ByConfigIdAndTag(buildConfigId, new[] { tag });
        }

        public List<BuildSumary> ByConfigIdAndTag(string buildConfigId, string[] tags)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    tags: tags
                                            ));
        }

        public List<BuildSumary> ByUserName(string userName)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(
                user: UserLocator.WithUserName(userName)
                                            ));
        }

        public List<BuildSumary> AllSinceDate(DateTime date)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(sinceDate: date));
        }

        public List<BuildSumary> ByBranch(string branchName)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(branch: branchName));
        }

        public List<BuildSumary> AllBuildsOfStatusSinceDate(DateTime date, BuildStatus buildStatus)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(sinceDate: date, status: buildStatus));
        }

        public List<BuildSumary> NonSuccessfulBuildsForUser(string userName)
        {
            var builds = ByUserName(userName);
            if (builds == null)
            {
                return null;
            }

            return builds.Where(b => b.Status != "SUCCESS").ToList();
        }
    }
}