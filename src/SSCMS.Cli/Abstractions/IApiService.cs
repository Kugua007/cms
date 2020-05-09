﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SSCMS.Cli.Services;

namespace SSCMS.Cli.Abstractions
{
    public interface IApiService
    {
        (bool success, string successContent, string failureMessage) GetStatus();

        Task<(bool success, string failureMessage)> LoginAsync(string account, string password);

        (bool success, string failureMessage) Register(string userName, string mobile, string email, string password);

        (bool success, string failureMessage) PluginsPublish(string packageId, string zipPath);

        (bool success, string failureMessage) UnPluginsPublish(string packageId);

        (bool success, List<ApiService.PluginAndUser> results, string failureMessage) PluginsSearch(string word);

        (bool success, ApiService.PluginAndUser result, string failureMessage) PluginsShow(string pluginId);
    }
}
