using System;
using System.Collections.Generic;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    public interface IBuilds
    {
        Build ById(String id);
        BuildStatistics GetStatisticsForBuild(string buildId);
        BuildStatistics GetStatisticsForBuild(BuildSumary build);
        Build GetDetailedBuild(BuildSumary buildSummary);

        void Add2QueueBuildByBuildConfigId(string buildConfigId);

        List<BuildSumary> AllSinceDate(DateTime date);
        List<BuildSumary> AllBuildsOfStatusSinceDate(DateTime date, BuildStatus buildStatus);
        List<BuildSumary> ByBuildLocator(BuildLocator locator);
        List<BuildSumary> ByConfigIdAndTag(string buildConfigId, string tag);
        List<BuildSumary> ByBuildConfigId(string buildConfigId);
        List<BuildSumary> ByUserName(string userName);
        List<BuildSumary> ByBranch(string branchName);
        List<BuildSumary> NonSuccessfulBuildsForUser(string userName);
        List<BuildSumary> SuccessfulBuildsByBuildConfigId(string buildConfigId);
        List<BuildSumary> FailedBuildsByBuildConfigId(string buildConfigId);
        List<BuildSumary> ErrorBuildsByBuildConfigId(string buildConfigId);
        BuildSumary LastBuildByAgent(string agentName);
        BuildSumary LastSuccessfulBuildByBuildConfigId(string buildConfigId);
        BuildSumary LastFailedBuildByBuildConfigId(string buildConfigId);
        BuildSumary LastBuildByBuildConfigId(string buildConfigId);
        BuildSumary LastErrorBuildByBuildConfigId(string buildConfigId);

    }
}