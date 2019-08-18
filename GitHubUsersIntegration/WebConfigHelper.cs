using System.Configuration;

namespace GitHubUsersIntegration
{
    public static class WebConfigHelper
    {
        /// <summary>
        /// Gets the number of repos to display on the search result page based upon the web config value
        /// </summary>
        public static int GetNumberOfReposToDisplay()
        {
            int numberOfReposToDisplay;
            int.TryParse(ConfigurationManager.AppSettings["NumberOfReposToDisplay"], out numberOfReposToDisplay);
            return numberOfReposToDisplay;
        }

        /// <summary>
        /// Returns a URL to get the Users information based on a passed in username. 
        /// </summary>
        public static string GetUserEndpoint(string username)
        {
            return (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["GitHubUsersEndpoint"])
                ? ConfigurationManager.AppSettings["GitHubUsersEndpoint"].Replace("{username}", username)
                : $"https://api.github.com/users/{username}");
        }

        /// <summary>
        /// Returns a URL to get the Users GitHub Repo information based on a passed in username. 
        /// </summary>
        public static string GetUsersReposEndpoint(string username)
        {
            return (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["GitHubUsersReposEndpoint"]) 
                ? ConfigurationManager.AppSettings["GitHubUsersReposEndpoint"].Replace("{username}", username) 
                : $"https://api.github.com/users/{username}/repos");
        }

    }
}