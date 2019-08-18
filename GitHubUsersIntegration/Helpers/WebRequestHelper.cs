using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitHubUsersIntegration.Helpers
{
    public static class WebRequestHelper
    {
        /// <summary>
        /// Makes a request to the passed in url returning back the generic 'T' type requested.
        /// </summary>
        public static async Task<T> GetResponseAsync<T>(string url) where T : new()
        {
            string response = "";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    SetupHttpClient(client);
                    response = await client.GetStringAsync(new Uri(url));
                }
                catch
                {
                    /* This may occur if a user wasn't found or the API call limit was exceeded.
                     *  Could be extended to check Http Status codes in the future. */
                    return new T();
                }
            }
            return JsonConvert.DeserializeObject<T>(response);
        }

        /// <summary>
        /// This method is used to setup the http client for the requests we want to make. Here we set the security protocol and any required headers
        /// </summary>
        public static void SetupHttpClient(HttpClient client)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Accepting headers as recommended here - https://developer.github.com/v3/#current-version
            List<string> acceptHeaders = new List<string> { "application/vnd.github.v3+json", "application/vnd.github.machine-man-preview+json" };
            client.DefaultRequestHeaders.Add("Accept", acceptHeaders);
            client.DefaultRequestHeaders.Add("User-Agent", "GitHubUsersIntegration.NetApp");

            // I've gave this token very limited permissions. It's useful as it increases the api request limit from 60 to 5000.
            //client.DefaultRequestHeaders.Add("Authorization", "token 572b06124c66960cffc3efc86e0ea02115222fd7");
        }
    }
}