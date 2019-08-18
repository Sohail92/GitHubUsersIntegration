using GitHubUsersIntegration.Helpers;
using GitHubUsersIntegration.Interfaces;
using GitHubUsersIntegration.Models;
using GitHubUsersIntegration.Models.GitHub;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitHubUsersIntegration.Repositories
{
    public class GitHubConnection : IConnectToGitHub
    {
        /// <summary>
        /// Get user info from GitHub based on the passed in username
        /// </summary>
        public Task<UserResponse> GetUserInformation(string username)
        {
            string url = WebConfigHelper.GetUserEndpoint(username);
            return WebRequestHelper.GetResponseAsync<UserResponse>(url);
        }

        /// <summary>
        /// Get repository info from GitHub based on the passed in username
        /// </summary>
        public async Task<List<RepoResponse>> GetUserRepoInformation(string username)
        {
            string url = WebConfigHelper.GetUsersReposEndpoint(username);
            List<RepoResponse> userRepoResponse = await WebRequestHelper.GetResponseAsync<List<RepoResponse>>(url);

            // Order by star gazers count descending then take the top [x] amount as set in the web config.
            return userRepoResponse.OrderByDescending(repo => repo.StargazersCount).Take(WebConfigHelper.GetNumberOfReposToDisplay()).ToList();
        }
    }
}