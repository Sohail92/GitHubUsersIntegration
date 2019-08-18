using GitHubUsersIntegration.Models.GitHub;
using System.Collections.Generic;

namespace GitHubUsersIntegration.Models.ViewModels
{
    public class UserRepoVM
    {
        public UserResponse UserResponse { get; set; }
        public List<RepoResponse> RepoResponse { get; set; }
    }
}