using GitHubUsersIntegration.Interfaces;
using GitHubUsersIntegration.Models;
using GitHubUsersIntegration.Models.GitHub;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitHubUsersIntegration.Repositories.GitHub
{
    public class GitHubConnectionMock : IConnectToGitHub
    {
        public Task<UserResponse> GetUserInformation(string username)
        {
            return Task<UserResponse>.Factory.StartNew(() => new UserResponse()
            {
                AvatarUrl = "https://avatars3.githubusercontent.com/u/10983828?v=4",
                Location = "Middlesbrough, UK",
                Name = "Sohail Rahman",
                Username = "sohail92",
                ReposUrl = "https://api.github.com/users/Sohail92/repos"
            });
        }

        public Task<List<RepoResponse>> GetUserRepoInformation(string username)
        {
            return Task<List<RepoResponse>>.Factory.StartNew(() => new List<RepoResponse>()
            {
                new RepoResponse
                {
                    FullName = "MyMockRepo1" ,
                    Description = "My description for my mock repo",
                    StargazersCount = 53,
                    RepoUrl = "https://github.com/Sohail92/ThisDoesntExist"
                },
                new RepoResponse
                {
                    FullName = "MyMockRepo2" ,
                    Description = "My description for my other mock repo",
                    StargazersCount = 53,
                    RepoUrl = "https://github.com/Sohail92/ThisDoesntExistEither"
                }
            });
        }
    }
}