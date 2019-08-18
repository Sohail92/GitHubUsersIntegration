using GitHubUsersIntegration.Models;
using GitHubUsersIntegration.Models.GitHub;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubUsersIntegration.Interfaces
{
    public interface IConnectToGitHub
    {
        Task<UserResponse> GetUserInformation(string username);
        Task<List<RepoResponse>> GetUserRepoInformation(string username);
    }
}
