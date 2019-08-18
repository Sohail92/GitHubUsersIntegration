using Newtonsoft.Json;

namespace GitHubUsersIntegration.Models.GitHub
{
    public class RepoResponse
    {
        [JsonProperty("Full_name")]
        public string FullName { get; set; }

        [JsonProperty("Html_url")]
        public string RepoUrl { get; set; }

        public string Description { get; set; }

        [JsonProperty("Stargazers_count")]
        public int StargazersCount { get; set; }
    }
}