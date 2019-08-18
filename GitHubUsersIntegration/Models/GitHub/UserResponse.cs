using Newtonsoft.Json;

namespace GitHubUsersIntegration.Models
{
    public class UserResponse
    {
        [JsonProperty("login")]
        public string Username { get; set; }

        public string Name { get; set; }

        [JsonProperty("bio")]
        public string Description { get; set; }

        [JsonProperty("Html_url")]
        public string PageUrl { get; set; }

        public string Location { get; set; }

        [JsonProperty("Avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("Repos_url")]
        public string ReposUrl { get; set; }
    }
}