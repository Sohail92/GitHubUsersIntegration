using GitHubUsersIntegration.Interfaces;
using GitHubUsersIntegration.Models;
using GitHubUsersIntegration.Models.GitHub;
using GitHubUsersIntegration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GitHubUsersIntegration.Controllers
{
    public class GitHubController : Controller
    {
        private readonly ILogErrors _errorLogger;
        private readonly IConnectToGitHub _gitHubConnection;

        /// <summary>
        /// We use Ninject for Dependency Injection in to the constructor here. 
        /// There are alternative IoC Containers available such as Autofac, Castle Windsor, Unity etc.
        /// </summary>
        public GitHubController(IConnectToGitHub gitHubConnection, ILogErrors errorLogger)
        {
            _errorLogger = errorLogger;
            _gitHubConnection = gitHubConnection;
        }

        /// <summary>
        /// Called from form action when a user enters a GitHub account username to search for
        /// </summary>
        /// <param name="username">The GitHub account username to search</param>
        /// <returns>A view model containing the user data and repo data for the passed in username</returns>
        public async Task<ActionResult> SearchUsers(string username)
        {
            UserRepoVM userRepoVM = new UserRepoVM();
            try
            {
                // Fire off both tasks, one to get the user information and the other to get their repo info
                Task<UserResponse> userResponse = _gitHubConnection.GetUserInformation(username);
                Task<List<RepoResponse>> repoResponse = _gitHubConnection.GetUserRepoInformation(username);

                // Wait until both tasks are complete
                await Task.WhenAll(userResponse, repoResponse);

                // Arrange the ViewModel as required.
                userRepoVM.UserResponse = userResponse.Result;
                userRepoVM.RepoResponse = repoResponse.Result;
            }
            catch(Exception ex)
            {
                // Log the error and return the error view.
                _errorLogger.LogError(ex);
                return View("Error");
            }
            return View(userRepoVM);
        }
    }
}