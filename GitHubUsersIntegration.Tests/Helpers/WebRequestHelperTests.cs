using System;
using GitHubUsersIntegration.Helpers;
using GitHubUsersIntegration.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace GitHubUsersIntegration.Tests.Helpers
{
    [TestClass]
    [TestFixture]
    public class WebRequestHelperTests
    {
        [TestCase("sohail92")]
        [TestCase("robconery")]
        [TestCase("google")]
        public void TestGetGitHubUserInfo_ReturnsData(string username)
        {
            // arrange
            string url = $"https://api.github.com/users/{username}";
            
            // act
            var result = WebRequestHelper.GetResponseAsync<UserResponse>(url);

            // assert
            NUnit.Framework.Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetGitHubUserInfo_IsExpectedType()
        {
            // arrange
            string url = "https://api.github.com/users/sohail92";

            // act
            var result = WebRequestHelper.GetResponseAsync<UserResponse>(url);

            // assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result.Result, typeof(UserResponse));
        }
    }
}
